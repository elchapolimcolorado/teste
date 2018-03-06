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
                window.id_categoria_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esta categoria?",
                    function () { controller.excluirCategoria(window.id_categoria_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirCategoria: function (idcategoria) {
            main.showLoading($('.main_container'));
            var model = {
                id: idcategoria
            };
            window.main.post(model, 'Categoria/Excluir?id=' + idcategoria, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaCategoria();
                main.showSuccessMessage('Categoria removida com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir a categoria, tente novamente mais tarde.');
            });
        },
        salvar: function (e) {
            var model = {
                "Codigo": "1", "Nome": "teste", "NomeArquivo": "", "ContentType": "", "DataManipulacao": "", "Ativo": "", "LoginManipulacao": "", "Imagem": ""
            };
            main.post(model, 'Categoria/Salvar', view.sucessoAoSalvar, view.erroAoSalvar);
        }
        
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaCategoria: function() {
            $('a[data-id="' + window.id_categoria_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Categoria salva com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Categoria';
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
                text: 'Ocorreu um erro ao salvar a categoria, tente mais tarde.',
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