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
                window.id_ferramenta_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esta ferramenta?",
                    function () { controller.excluirFerramenta(window.id_ferramenta_inativar); },
                    function () { });
            });
    };

    var controller = {
        excluirFerramenta: function (idferramenta) {
            main.showLoading($('.main_container'));
            var model = {
                id: idferramenta
            };
            window.main.post(model, 'Ferramenta/Excluir?id=' + idferramenta, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaFerramenta();
                main.showSuccessMessage('Ferramenta removida com sucesso');
            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir a ferramenta, tente novamente mais tarde.');
            });
        },
        salvar: function (e) {
            var model = {
                "Codigo": "1", "Nome": "teste", "NomeArquivo": "", "ContentType": "", "DataManipulacao": "", "Ativo": "", "LoginManipulacao": "", "Imagem": ""
            };
            main.post(model, 'Ferramenta/Salvar', view.sucessoAoSalvar, view.erroAoSalvar);
        },
        preencherTipo: function () {
            var codigo = $('#ddlCategoria').val();
            $.ajax({
                url: '/Ferramenta/BuscarTipo',
                type: "GET",
                dataType: "JSON",
                data: { codigoCategoria: codigo },
                success: function (tipos) {
                    $("#ddlTipo").html("");
                    $.each(tipos, function (i, tipo) {
                        $("#ddlTipo").append(
                            $('<option></option>').val(tipo.Codigo).html(tipo.Nome));
                    });
                }
            });
        },
        preencherSubTipo: function () {
            var codigo = $('#ddlTipo').val();
            $.ajax({
                url: '/Ferramenta/BuscarSubTipo',
                type: "GET",
                dataType: "JSON",
                data: { codigoTipo: codigo },
                success: function (subtipos) {
                    $("#ddlSubTipo").html("");
                    $.each(subtipos, function (i, subtipo) {
                        $("#ddlSubTipo").append(
                            $('<option></option>').val(subtipo.Codigo).html(subtipo.Nome));
                    });
                }
            });
        }
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaFerramenta: function() {
            $('a[data-id="' + window.id_ferramenta_inativar + '"]').parents('tr').remove();
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                    "Ferramenta salva com sucesso.",
                    function () {
                        window.location.href = baseUrl + 'Ferramenta';
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
                text: 'Ocorreu um erro ao salvar a ferramenta, tente mais tarde.',
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