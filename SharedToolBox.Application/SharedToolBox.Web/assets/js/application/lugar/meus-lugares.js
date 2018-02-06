(function (container, $) {
    var $container = $(container);
    var inicializar = function () {
        $container
            .on('click',
                '#cadastrar-novo',
                function(e) {
                    window.location = window.baseUrl + 'lugar/index';
                })
            .on('click',
                '.editar',
                function (e) {
                    var id = $(this).data('id-lugar');
                    window.location = window.baseUrl + 'lugar/index?idlugar=' + id;
                    e.preventDefault();
                });
       // controller.obterListaMeusLugares();
    };

    var controller = {
        obterListaMeusLugares: function () {
            view.showLoadingForm();
            var url = 'lugar/ObterMeusLugares';
            window.main.get(url, function (ret) {
                view.carregarTable(ret);
                main.hideLoading();
            }, view.erroGenerico);


        }
    };
    var view = {
        erroGenerico: function (e) { console.log(e); },
        carregarTable: function (ret) {
            var theTemplateScript = $("#lista-lugares-template").html();
            var theTemplate = Handlebars.compile(theTemplateScript);

            var theCompiledHtml = theTemplate(ret.result);

            $('#lista-lugares').html(theCompiledHtml);
            
        },
        showLoadingForm: function() {
            main.showLoading($('#container-lista-meus-lugares'));
        }
    };
    
    //ready
        $(function() {
            inicializar();
        });

        window.view = view;
    window.controller = controller;

})(document, jQuery);