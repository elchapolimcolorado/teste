(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        $container
            //.on('click',
            //'.salvar',
            //function (e) {
            //    controller.salvar(e);
            //    e.preventDefault();
            //})
            .on('click', '.inativar', function (e) {
                var id = $(this).data('id');
                window.id_tipo_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir este tipo?",
                    function () { controller.excluirTipo(window.id_tipo_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirTipo: function (idtipo) {
            main.showLoading($('.main_container'));
            var model = {
                id: idtipo
            };
            window.main.post(model, 'Tipo/Excluir?id=' + idtipo, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaTipo();
                main.showSuccessMessage('Tipo removido com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir o tipo, tente novamente mais tarde.');
            });
        },
        salvar: function (e) {
            var model = {
                "Codigo": "1", "Nome": "teste", "NomeArquivo": "", "ContentType": "", "DataManipulacao": "", "Ativo": "", "LoginManipulacao": "", "Imagem": ""
            };
            main.post(model, 'Tipo/Salvar', view.sucessoAoSalvar, view.erroAoSalvar);
        }
        
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaTipo: function() {
            $('a[data-id="' + window.id_tipo_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Tipo salvo com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Tipo';
                    });
            } else {
                if (ret.result.messages) {
                    var txt = "";
                    $(ret.result.messages).each(function (i, t) {
                        txt += t;
                        txt += "<br />";
                    });
                    alertify
                        .alert("Erro", "Favor verificar os itens abaixo:<br />" + txt);
                }
            }
        },
        erroGenerico: function (e) {
            main.hideLoading();
            $.toast({
                heading: 'Erro',
                text: 'Ocorreu um erro, tente mais tarde.',
                position: 'bottom-right',
                stack: false,
                icon: 'error'
            });
        },
        erroAoSalvar: function (e) {
            main.hideLoading();
            $.toast({
                heading: 'Erro',
                text: 'Ocorreu um erro ao salvar o tipo, tente mais tarde.',
                position: 'bottom-right',
                stack: false,
                icon: 'error'
            });
        }
    };
    
    //ready
    $(function() {
        inicializar();
    });

    window.view = view;
    window.controller = controller;
})(document, jQuery);