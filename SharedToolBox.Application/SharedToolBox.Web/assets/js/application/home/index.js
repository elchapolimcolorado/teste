//(function (container, $) {
//    var $container = $(container);
//    var inicializar = function () {

//        $container
//            .on('click',
//                '.logar',
//                function (e) {
//                    window.appId = $(this).data('app-number');
//                    var idApp = $(this).data('id-app');

//                    controller.indicarAutenticacaoAPp(idApp);
//                    e.preventDefault();
//                });
//    };

//    var controller = {
//        indicarAutenticacaoAPp: function(idApp) {
            
//            var model = {
//                idApp: idApp
//            };

//            window.main.post(
//                model,
//                'Home/IndicarAppEmAutenticacao',
//                function (ret) {
//                    console.log(ret);
//                    var url = "https://auth.mercadolivre.com.br/authorization?response_type=code&client_id=" + window.appId;
//                    window.location.href = url;
//                },
//                function (e) {
//                    console.log(e);
//                });
//            return false;
//        },
// };
//    var view = {
//        erroGenerico: function (e) { console.log(e); },
//        showLoadingForm2: function() {
//            main.showLoading($('#form-2'));
//        }
//    };
    
//    //ready
//        $(function() {
//            inicializar();

//        });

//        window.view = view;
//    window.controller = controller;

//})(document, jQuery);