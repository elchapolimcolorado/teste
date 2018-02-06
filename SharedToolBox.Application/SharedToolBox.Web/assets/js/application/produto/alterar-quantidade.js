(function (container, $) {
    var $container = $(container);
    var inicializar = function () {

        $container
            .on('click', '#salvar', function(e) {
                controller.salvarModificados();

                e.preventDefault();
            });
    };

    var controller = {
        alterarQtdProduto: function () {
            main.showLoading($('.main_container'));
            window.main.post(model, 'Produto/AtualizarQuantidadeVariacao', function () {
                main.hideLoading($('.main_container'));
                $('#modal-alterar-qtd').modal('toggle');
                view.atualizarTabelaQuantidade();
                main.showSuccessMessage('Quantidade alterada com sucesso');
                view.limparCamposModal();
            }, function() {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao atualizar quantidade, tente novamente mais tarde.');
                view.limparCamposModal();
            });
        },
        adicionarIdsVariacoesASeremAlteradas: function(variacoes) {
            window.idsVariacoes = variacoes;
        },
        salvarModificados: function() {
            var preenchidos = $('.txt-alterar').filter(function () { return $(this).val() != ""; });
            if (preenchidos.length == 0)
                main.showInfoMessage('Preencha ao menos um campo a ser alterado');
            else {
                main.showLoading($('.main_container'));

                var model = [];

                $(preenchidos).each(function(i, e) {
                    model.push({
                        id: $(e).data('id-ml'),
                        qtd: $(e).val()
                    });
                });

                window.main.post(model, 'Produto/AtualizarQuantidadeVariacao', view.sucessoAoSalvar, view.erroAoSalvar);

            }

        }
 };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        sucessoAoSalvar: function () {
            
            
            main.hideLoading($('.main_container'));
            main.showSuccessMessage('Quantidade alterada com sucesso', function() { window.location.reload(); });
        },
        erroAoSalvar: function() {
            

            main.hideLoading($('.main_container'));
            main.showErrorMessage('Ocorreu um erro ao atualizar quantidade, tente novamente mais tarde.');
        }
    };
    
    //ready
        $(function() {
            inicializar();

        });

        window.view = view;
    window.controller = controller;

})(document, jQuery);