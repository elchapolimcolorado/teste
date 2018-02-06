(function(container, $) {
    var main = {
        post: function (model, url, callbackSucesso, callbackError) {
            $.ajax({
                url: container.baseUrl +  url,
                method: "POST",
                data: JSON.stringify(model),
                dataType: "json",
                success: callbackSucesso,
                error: callbackError
            });
        },
        put: function (model, url, callbackSucesso, callbackError) {
            $.ajax({
                url: container.baseUrl + url,
                method: "PUT",
                data: model,
                dataType: "json",
                success: callbackSucesso,
                error: callbackError
            });
        },
        get: function (url, callbackSucesso, callbackError) {
            $.get({
                url: container.baseUrl +  url,
                method: "GET",
                success: callbackSucesso,
                error: callbackError
            });
        },
        delete: function (url, callbackSucesso, callbackError) {
            $.ajax({
                url: container.baseUrl + url,
                method: "DELETE",
                success: callbackSucesso,
                error: callbackError
            });
        },
        showLoading: function(el) {
            
            var html = '<div class="loader-container text-center">' + 
                            '<div class="icon">' +
                                '<div class="sk-wave">' +
                                    '<div class="sk-rect sk-rect1"></div>' +
                                    '<div class="sk-rect sk-rect2"></div>' +
                                    '<div class="sk-rect sk-rect3"></div>' +
                                    '<div class="sk-rect sk-rect4"></div>' +
                                    '<div class="sk-rect sk-rect5"></div>' +
                                '</div>' +
                            '</div>' +
                            '<div class="title">Loading</div>' +
                        '</div>';

            $(el).addClass("__loading").append(html);;
        },
        hideLoading: function () {
            $('.loader-container').remove();
            $('.__loading').removeClass("__loading");
        },
        showSuccessMessage: function(message, callback) {
            $.toast({
                heading: 'Sucesso',
                text: message,
                icon: 'success',
                position: 'bottom-right',
                afterHidden: callback
            });
        },
        showErrorMessage:function(message) {
            $.toast({
                heading: 'Erro',
                text: message,
                position: 'bottom-right',
                icon: 'error'
            });
        },
        showInfoMessage: function (message) {
            $.toast({
                heading: 'Alerta',
                text: message,
                position: 'bottom-right',
                icon: 'info'
            });
        },
        exibirDecisaoPopup: function(message, resolve, reject) {
            alertify.confirm("Aviso", message, resolve, reject).set('closable', false);
        },
        somenteNumeros: function (e) {

            var tecla = (window.event) ? event.keyCode : e.which;
            if ((tecla > 47 && tecla < 58)) return true;
            else {
                if (tecla == 8 || tecla == 0) return true;
                else return false;
            }
        }
    };

    container.main = main;
    //$(document)
    //    .ajaxStart(function () {
    //        main.showLoading($('.body-container-center'));
    //    }).ajaxComplete(function () {
    //        main.hideLoading(); 
    //    });;

})(window, jQuery);