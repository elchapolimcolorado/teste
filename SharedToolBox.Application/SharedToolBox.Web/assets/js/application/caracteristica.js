(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        $container
            .on('click', '.inativar', function (e) {
                var id = $(this).data('id');
                window.id_caracteristica_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esta caracteristica?",
                    function () { controller.excluirCaracteristica(window.id_caracteristica_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirCaracteristica: function (idcaracteristica) {
            main.showLoading($('.main_container'));
            var model = {
                id: idcaracteristica
            };
            window.main.post(model, 'Caracteristica/Excluir?id=' + idcaracteristica, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaCaracteristica();
                main.showSuccessMessage('Caracteristica removida com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir a caracteristica, tente novamente mais tarde.');
            });
        }
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaCaracteristica: function() {
            $('a[data-id="' + window.id_caracteristica_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Caracteristica salva com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Caracteristica';
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
                text: 'Ocorreu um erro ao salvar a caracteristica, tente mais tarde.',
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