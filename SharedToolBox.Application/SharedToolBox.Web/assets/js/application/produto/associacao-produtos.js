(function (container, $) {
    var $container = $(container);
    var view = {
        inicializarMascaras: function () {
            //$('select').select2();
        },
        sucessoAoBuscarDetalhePai: function (ret) {
            var source = $("#detalhe-produto-pai-template").html();
            var template = Handlebars.compile(source);
            $('#place-produto-pai-detalhe').html(template(ret.result));
            view.desbloquearArea($('#form-filho'));
            view.bloquearArea($('#form-pai'), true);
            $('#erro-pai').addClass('hide');
            $('#url-pai').val('');
        },
        sucessoAoBuscarDetalheAssociado: function (ret) {
            var existeProduto = $('tr[data-id-produto-mercadolivre="' + ret.result.idMercadoLivre + '"]').length > 0;
            if (existeProduto)
                $.toast({
                    heading: 'Ops!',
                    text: 'Este produto já está na lista!',
                    position: 'bottom-right',
                    stack: false,
                    icon: 'info'
                });
            else {
                var source = $("#item-produto-associado-template").html();
                var template = Handlebars.compile(source);
                $('#place-item-detalhe-produto-associado').append(template(ret.result));
                $('#erro-filho').addClass('hide');
            }
            $('#url-filho').val('');
        },
        sucessoAoSalvar: function (ret) {
            main.hideLoading();
            if (ret.success) {
                alertify
                    .alert("Mensagem",
                        "Produtos associados com sucesso",
                        function() {
                            window.location.href = baseUrl + 'Produto';
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
        bloquearArea: function (el, exibirBotaoEditar) {
            $(el).wrap('<div class="container-step-white"></div>');
            $('.container-step-white').wrap('<div class="parent-step-white"></div>');
            if (exibirBotaoEditar)
                $('.parent-step-white').prepend('<input class="btn-container-step-white" type="button" value="Editar">');
            $(el).find('.form-control').attr('readonly', 'readonly');
        },
        desbloquearArea: function(el) {
            $(el).unwrap('container-step-white');
            $(el).unwrap('parent-step-white');
            $('.btn-container-step-white').remove();
            $(el).find('.form-control').removeAttr('readonly');
        },
        erroAoSalvar: function (e) {
            main.hideLoading();
                $.toast({
                    heading: 'Erro',
                    text: 'Ocorreu um erro ao tentar associar os usuarios, tente mais tarde.',
                    position: 'bottom-right',
                    stack: false,
                    icon: 'error'
                });
        },
        atualizarTabelaProduto: function () {
            $('tr[data-id="' + window.id_produto_inativar + '"]').remove();
        }
    };

    var controller = {
        buscarDetalhesPai: function () {
            var form = $('#form-pai');
            if (validator.checkAll(form)) {
                var url = $('#url-pai').val();
                var completeUrl = 'Produto/ObterDetalhesProdutoMercadoLivre?url=' + url;
                main.get(completeUrl, view.sucessoAoBuscarDetalhePai, view.erroGenerico);
            }
        },
        buscarDetalhesFilho: function () {
            var form = $('#form-filho');
            if (validator.checkAll(form)) {
                var url = $('#url-filho').val();
                var completeUrl = 'Produto/ObterDetalhesProdutoMercadoLivre?url=' + url;
                main.get(completeUrl, view.sucessoAoBuscarDetalheAssociado, view.erroGenerico);
            }
        },
        salvar: function (e) {
            var possuiPai = $('#id-produto-mercadolivre-pai').val() != undefined &&
                $('#id-produto-mercadolivre-pai').val() !== "";

            var possuiFilho = $('#place-item-detalhe-produto-associado tr').length > 0;

            if (!possuiPai)
                $('#erro-pai').removeClass('hide');
            if (!possuiFilho)
                $('#erro-filho').removeClass('hide');


            var valid = possuiPai && possuiFilho;

            if (valid) {

                main.showLoading($('.tela'));
                var filhos = [];

                $('.item-produto-filho').each(function(i, e) {
                    var item = {
                        UrlProduto: $(e).data('id-produto-mercadolivre')
                    };
                    filhos.push(item);
                });

                var model = {
                    Pai: {
                        UrlProduto: $('#id-produto-mercadolivre-pai').val()
                    },
                    Filhos: filhos
                };
                main.post(model, 'produto/AssociacaoProdutos', view.sucessoAoSalvar, view.erroAoSalvar);
            } else
                e.preventDefault();
        },
        desbloquear: function (btn) {
            var form = $(btn).parents('.parent-step-white').find('form');
            view.desbloquearArea(form);
            if ($(form).data('tipo') == "pai")
                view.bloquearArea($('#form-filho'), true);
            else
                view.bloquearArea($('#form-pai'), true);
        },
        excluirProdutoAssociado: function(tr) {
            if (!$(tr).data('is-edicao'))
                $(tr).remove();
            else {
                window.id_produto_inativar = $(tr).data('id');

                main.exibirDecisaoPopup("Deseja realmente excluir esse produto?",
                    function () { controller.inativarProduto(window.id_produto_inativar); },
                    function () { });
            }
        },
        inativarProduto: function (idproduto) {
            main.showLoading($('.main_container'));

            var model = {
                IdProduto: idproduto
            };

            window.main.put(model, 'Produto/InativarAssociacaoProdutoFilho', function () {
                main.hideLoading($('.main_container'));

                view.atualizarTabelaProduto();
                main.showSuccessMessage('Produto removido com sucesso');

            }, function () {
                main.hideLoading($('.main_container'));
                main.showErrorMessage('Ocorreu um erro ao excluir o produto, tente novamente mais tarde.');
            });
        }
    };


    var inicializar = function () {
        view.inicializarMascaras();

        $container
            .on('click', '#adicionar-pai', function (e) {
                controller.buscarDetalhesPai();
                e.preventDefault();
            })
            .on('click', '#adicionar-filho', function (e) {
                controller.buscarDetalhesFilho();
                e.preventDefault();
            })
            .on('click', '#salvar', function (e) {
                controller.salvar(e);
                e.preventDefault();
            })
            .on('click', '.excluir-item', function (e) {
                var tr = $(this).parents('tr');
                controller.excluirProdutoAssociado(tr);
                e.preventDefault();
            })
        .on('click', '.btn-container-step-white', function (e) {
                controller.desbloquear(this);
                e.preventDefault();
            });
    };
    var inicializarValidacoes = function() {
        $container
            .on('blur', 'input[required], input.optional, select.required', validator.checkField)
            .on('change', 'select.required', validator.checkField);
        if (!main.isEdicao) {
            view.bloquearArea($('#form-filho'), false);
        } else {
            view.bloquearArea($('#form-pai'), false);
        }
    };
    window.bloq = view.bloquearArea;
    //ready
        $(function() {
            inicializar();
            inicializarValidacoes();
            
        });

        window.view = view;
    window.controller = controller;

})(document, jQuery);