(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        view.ativaTab('1');

        $container
            .on('click',
                '#salvar',
                function(e) {
                    controller.salvarLugar(e);
                })
            .on('click',
                '#salvar-membro',
                function (e) {
                    controller.salvarMembro(e);
                })
            .on('click',
                '#salvar-tarefa',
                function (e) {
                    controller.salvarTarefa(e);
                })
            .on('click', '#step1-tab', function() {
                view.ativaTab(1);
                return false;
            })
            .on('click', '#step2-tab', function () {
                view.ativaTab(2);
                controller.obterListaMembros();
                return false;
            })
            .on('click', '#step3-tab', function () {
                view.ativaTab(3);
                controller.obterListaMembros();
                return false;
            })
            .on('click', '#ir-para-tarefas', function (e) {
                view.ativaTab(3);
                e.preventDefault();
                return false;
            })
            .on('click', '.excluir-membro', function (e) {
                controller.excluirMembro($(this).data('id'));
                e.preventDefault();
            })
            .on('click', '.excluir-tarefa', function (e) {
                controller.excluirTarefa($(this).data('id'));
                e.preventDefault();
            })
            .on('click', '#voltar', function (e) {
                window.location = window.baseUrl + 'lugar/meuslugares';
                e.preventDefault();
            });
        
    };

    var controller = {
        salvarLugar: function(e) {
            if (!$('#form-lugar').valid()) {
                e.preventDefault();
                return false;
            }

            var model = {
                nome: $('#nome').val(),
                descricao: $('#descricao').val(),
                id: $('#id-lugar').val()
            };
            window.main.post(
                model,
                'lugar/index',
                function (ret) {
                    view.sucessoSalvarLugar(ret);
                },
                function (e) {
                    console.log(e);
                });
            e.preventDefault();
            return false;
        },
        salvarMembro: function (e) {
            if (!$('#form-membro').valid()) {
                e.preventDefault();
                return false;
            }

            var model = {
                nome: $('#nome-membro').val(),
                email: $('#email').val(),
                idlugar: $('#id-lugar').val()
            };
            window.main.post(model, 'lugar/membro', controller.sucessoAoSalvarMembro, view.erroGenerico);
            e.preventDefault();
            return false;
        },
        salvarTarefa: function (e) {
            if (!$('#form-tarefa').valid()) {
                e.preventDefault();
                return false;
            }

            var model = {
                nome: $('#nome-tarefa').val(),
                frequencia: $('#email').val(),
                idlugar: $('#id-lugar').val()
            };
            window.main.post(model, 'lugar/tarefa', controller.sucessoAoSalvarTarefa, view.erroGenerico);
            e.preventDefault();
            return false;
        },
        sucessoAoSalvarMembro: function () {
            view.limparCamposCadastroMembros();
            controller.obterListaMembros();
        },
        sucessoAoSalvarTarefa: function () {
            view.limparCamposCadastroTarefas();
            controller.obterListaTarefas();
        },
        obterListaMembros: function () {
            view.showLoadingForm2();
            var idLugar = $('#id-lugar').val();
            var url = 'lugar/ObterMembros?idLugar=' + idLugar;
            window.main.get(url, function (ret) {
                view.carregarTable(ret);
                main.hideLoading();
            }, view.erroGenerico);


        },
        obterListaTarefas: function () {
            view.showLoadingForm2();
            var idLugar = $('#id-lugar').val();
            var url = 'lugar/ObterTarefas?idLugar=' + idLugar;
            window.main.get(url, function (ret) {
                view.carregarTableTarefas(ret);
                main.hideLoading();
            }, view.erroGenerico);


        },
        excluirMembro: function (id) {
            var idLugar = $('#id-lugar').val();
            var url = 'lugar/ExcluirMembro?idLugar=' + idLugar + '&idMembro=' + id;
            main.delete(url, controller.sucessoAoExcluirMembro, view.erroGenerico)
        },
        excluirTarefa: function (id) {
            var idLugar = $('#id-lugar').val();
            var url = 'lugar/ExcluirTarefa?idLugar=' + idLugar + '&idMembro=' + id;
            main.delete(url, controller.sucessoAoExcluirTarefa, view.erroGenerico);
        },
        sucessoAoExcluirMembro: function() {
            controller.obterListaMembros();
        },
        sucessoAoExcluirTarefa: function () {
            controller.obterListaTarefas();
        }
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        sucessoSalvarLugar: function (ret) {
            $('#id-lugar').val(ret.result);
            view.ativaTab(2);
        },
        ativaTab: function (tab) {
            $('.nav-tabs a[href="#step' + tab + '"]').tab('show');
            $('.form-lugar').hide();
            $('#form-' + tab).show();
        },
        carregarTable: function (ret) {
            var theTemplateScript = $("#lista-membros-template").html();
            var theTemplate = Handlebars.compile(theTemplateScript);

            var theCompiledHtml = theTemplate(ret.result);

            $('#container-table-membros').html(theCompiledHtml);
            
        },
        carregarTableTarefas: function (ret) {
            var theTemplateScript = $("#lista-tarefas-template").html();
            var theTemplate = Handlebars.compile(theTemplateScript);

            var theCompiledHtml = theTemplate(ret.result);

            $('#container-table-tarefas').html(theCompiledHtml);

        },
        limparCamposCadastroMembros: function () { $('.cadastro-membro').val(''); },
        limparCamposCadastroTarefas: function () { $('.cadastro-tarefa').val(''); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        }
    };
    
    //ready
        $(function() {
            inicializar();

        });

        window.view = view;
    window.controller = controller;

})(document, jQuery);