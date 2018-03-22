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
                window.id_marca_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esta marca?",
                    function () { controller.excluirMarca(window.id_marca_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirMarca: function (idmarca) {
            main.showLoading($('.main_container'));
            var model = {
                id: idmarca
            };
            window.main.post(model, 'Marca/Excluir?id=' + idmarca, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaMarca();
                main.showSuccessMessage('Marca removida com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir a marca, tente novamente mais tarde.');
            });
        },
        salvar: function (e) {
            var model = {
                "Codigo": "1", "Nome": "teste", "NomeArquivo": "", "ContentType": "", "DataManipulacao": "", "Ativo": "", "LoginManipulacao": "", "Imagem": ""
            };
            main.post(model, 'Marca/Salvar', view.sucessoAoSalvar, view.erroAoSalvar);
        }
        
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaMarca: function() {
            $('a[data-id="' + window.id_marca_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Marca salva com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Marca';
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
                text: 'Ocorreu um erro ao salvar a marca, tente mais tarde.',
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