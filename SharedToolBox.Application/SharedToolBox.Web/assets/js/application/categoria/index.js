(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        $container
            .on('click', '.inativar', function (e) {
                var id = $(this).data('id');
                window.id_categoria_inativar = id;

                main.exibirDecisaoPopup("Deseja realmente excluir esta categoria?",
                    function () { controller.excluirCategoria(window.id_categoria_inativar); },
                    function() {  });
            });
    };

    var controller = {
        excluirCategoria: function(idcategoria) {
            main.showLoading($('.main_container'));
            var model = {
                id: idcategoria
            };
            window.main.post(model, 'Categoria/Excluir?id=' + idcategoria, function () {
                main.hideLoading($('.main_container'));
                view.atualizarTabelaCategoria();
                main.showSuccessMessage('Categoria removida com sucesso');
            }, function() {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir a categoria, tente novamente mais tarde.');
            });
        }
 };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        showLoadingForm2: function() {
            main.showLoading($('#form-2'));
        },
        atualizarTabelaCategoria: function() {
            $('a[data-id="' + window.id_categoria_inativar + '"]').parents('tr').remove();
        }
    };
    
    //ready
    $(function() {
        inicializar();
    });

    window.view = view;
    window.controller = controller;
})(document, jQuery);