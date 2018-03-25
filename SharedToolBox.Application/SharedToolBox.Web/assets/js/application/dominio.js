(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        $container
            .on('click', '.inativar', function (e) {
                var id = $(this).data('id');
                window.id_dominio_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esta dominio?",
                    function () { controller.excluirDominio(window.id_dominio_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirDominio: function (iddominio) {
            main.showLoading($('.main_container'));
            var model = {
                id: iddominio
            };
            window.main.post(model, 'Dominio/Excluir?id=' + iddominio, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaDominio();
                main.showSuccessMessage('Dominio removida com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir a dominio, tente novamente mais tarde.');
            });
        },
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaDominio: function() {
            $('a[data-id="' + window.id_dominio_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Dominio salva com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Dominio';
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
                text: 'Ocorreu um erro ao salvar a dominio, tente mais tarde.',
                position: 'bottom-right',
                stack: false,
                icon: 'error'
            });
        },
        disablefield: function (e) {
            $("#txtGrupo").attr("value", "");
            $("#ddlGrupo").attr("selectedIndex", "-1");

            if (document.getElementById('novoGrupo').checked == 1) { 
                $("#txtGrupo").attr("disabled", false);
                $("#ddlGrupo").attr("disabled", true);
            } else {
                $("#txtGrupo").attr("disabled", true);
                $("#ddlGrupo").attr("disabled", false);
            }
        } 
    };
    
    //ready
    $(function () {
        inicializar();
    });

    window.view = view;
    window.controller = controller;
})(document, jQuery);