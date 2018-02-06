(function (container, $) {
    var $container = $(container);
    var inicializar = function () {

        $container
            .on('click',
                '.atualizar',
                function (e) {
                    var idProduto = $(this).data('id-produto');
                    var title = $(this).data('nome');
                    controller.exibirModalEditarProduto(idProduto, title);
                    e.preventDefault();
                })
            .on('click', '.inativar', function (e) {
                var id = $(this).data('id');
                window.id_produto_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esse produto?",
                    function () { controller.inativarProduto(window.id_produto_inativar); },
                    function() {  });

               
            });
    };

    var controller = {
        exibirModalEditarProduto: function(idProduto, title) {
            $('#id-produto-alterar').val(idProduto);
            $('#myModalLabel').html(title);

            $('#modal-alterar-qtd').modal();
        },
        inativarProduto: function(idproduto) {
            main.showLoading($('.main_container'));

            var model = {
                IdProduto: idproduto
            };

            window.main.put(model, 'Produto/InativarProdutoPai', function () {
                main.hideLoading($('.main_container'));
                
                view.atualizarTabelaProduto();
                main.showSuccessMessage('Produto removido com sucesso');
                
            }, function() {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir o produto, tente novamente mais tarde.');
            });
        }
 };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaProduto: function() {
            $('a[data-id="' + window.id_produto_inativar + '"]').parents('tr').remove();
        }
    };
    
    //ready
        $(function() {
            inicializar();

        });

        window.view = view;
    window.controller = controller;

})(document, jQuery);