(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        $container
            .on('click', '.inativar', function (e) {
                var id = $(this).data('id');
                window.id_subtipo_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir este subtipo?",
                    function () { controller.excluirSubtipo(window.id_subtipo_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirSubtipo: function (idsubtipo) {
            main.showLoading($('.main_container'));
            var model = {
                id: idsubtipo
            };
            window.main.post(model, 'Subtipo/Excluir?id=' + idsubtipo, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaSubtipo();
                main.showSuccessMessage('Subtipo removido com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir o subtipo, tente novamente mais tarde.');
            });
        },
        salvar: function (e) {
            var model = {
                "Codigo": "1", "Nome": "teste", "NomeArquivo": "", "ContentType": "", "DataManipulacao": "", "Ativo": "", "LoginManipulacao": "", "Imagem": ""
            };
            main.post(model, 'Subtipo/Salvar', view.sucessoAoSalvar, view.erroAoSalvar);
        }
        
    };
    var view = {
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaSubtipo: function() {
            $('a[data-id="' + window.id_subtipo_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Subtipo salvo com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Subtipo';
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
                text: 'Ocorreu um erro ao salvar o subtipo, tente mais tarde.',
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