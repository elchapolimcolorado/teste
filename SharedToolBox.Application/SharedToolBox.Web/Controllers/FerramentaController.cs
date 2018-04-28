using AutoMapper;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Helpers;
using SharedToolBox.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedToolBox.Web.Controllers
{
    [AllowAnonymous]
    public class FerramentaController : Controller
    {
        private readonly IFerramentaAppService _ferramentaApp;
        private readonly IMarcaAppService _marcaApp;
        private readonly ICategoriaAppService _categoriaApp;
        private readonly ITipoAppService _tipoApp;
        private readonly ISubtipoAppService _subtipoApp;

        public FerramentaController(IMarcaAppService MarcaApp,
            ISubtipoAppService SubtipoApp,
            IFerramentaAppService FerramentaApp,
            ICategoriaAppService CategoriaApp,
            ITipoAppService TipoApp)
        {
            _ferramentaApp = FerramentaApp;
            _marcaApp = MarcaApp;
            _subtipoApp = SubtipoApp;
            _categoriaApp = CategoriaApp;
            _tipoApp = TipoApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ViewBag.Marcas = (Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.Find(x => x.Ativo.Equals(true))));
                ViewBag.Subtipos = (Mapper.Map<IEnumerable<Subtipo>, IEnumerable<SubtipoViewModel>>(_subtipoApp.Find(x => x.Ativo.Equals(true))));
                var model = Mapper.Map<IEnumerable<Ferramenta>, IEnumerable<FerramentaViewModel>>(_ferramentaApp.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Recarregar(FerramentaViewModel model)
        {
            try
            {
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult BuscarTipo(int codigoCategoria)
        {
            try
            {
                var tipos = _tipoApp.Find(x => x.CodigoCategoria.Equals(codigoCategoria));
                tipos.ToList().Insert(0, new Tipo() { Codigo = 0, Ativo = true, Nome = "Selecione" });
                return Json(tipos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult BuscarSubTipo(int codigoTipo)
        {
            try
            {
                var subtipos = _subtipoApp.Find(x => x.CodigoTipo.Equals(codigoTipo));
                subtipos.ToList().Add(new Subtipo() { Codigo = 0, Ativo = true, Nome = "Selecione" });
                return Json(subtipos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Novo()
        {
            try
            {
                ViewBag.Categorias = (Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.Find(x => x.Ativo.Equals(true))));
                ViewBag.Marcas = (Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.Find(x => x.Ativo.Equals(true))));
                ViewBag.Tipos = (Mapper.Map<IEnumerable<Tipo>, IEnumerable<TipoViewModel>>(_tipoApp.Find(x => x.Ativo.Equals(true))));
                ViewBag.Subtipos = (Mapper.Map<IEnumerable<Subtipo>, IEnumerable<SubtipoViewModel>>(_subtipoApp.Find(x => x.Ativo.Equals(true))));

                var model = new FerramentaViewModel()
                {
                    Ativo = true
                };

                ViewBag.Marcas = (Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.Find(x => x.Ativo.Equals(true))));

                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Salvar(FerramentaViewModel model)
        {
            try
            {
                var Ferramenta = Mapper.Map<FerramentaViewModel, Ferramenta>(model);

                HttpPostedFileBase file = Request.Files["ImageData"];

                if (file.ContentLength != 0)
                {
                    if (file.IsImage())
                    {
                        Ferramenta.Imagem = file.ConvertToBytes();
                        Ferramenta.ContentType = file.ContentType;
                        Ferramenta.NomeArquivo = file.FileName;
                    }
                    else
                    {
                        throw new Exception("Erro: Não é possível vincular arquivos que não sejam imagens.");
                    }
                }
                else if (!model.Codigo.Equals(0))
                {
                    var image = Mapper.Map<Ferramenta, FerramentaViewModel>(_ferramentaApp.GetById(model.Codigo));

                    Ferramenta.ContentType = image.ContentType;
                    Ferramenta.NomeArquivo = image.NomeArquivo;
                    Ferramenta.Imagem = image.Imagem;
                }

                if (model.Codigo.Equals(0))
                    _ferramentaApp.Add(Ferramenta);
                else
                    _ferramentaApp.Update(model.Codigo, Ferramenta);

                //return Content("<script>main.showSuccessMessage('Ferramenta salva com sucesso.');</script>");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Novo");
                return Content("<script>main.showErrorMessage('Ocorreu um erro ao salvar a Ferramenta. (" + ex.Message + ")');return false;</script>");
            }
        }

        [HttpGet]
        public ActionResult RetrieveImage(int id)
        {
            try
            {
                var model = Mapper.Map<Ferramenta, FerramentaViewModel>(_ferramentaApp.GetById(id));
                byte[] cover = model.Imagem;

                if (cover != null)
                    return File(cover, model.ContentType);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                ViewBag.Marcas = (Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.Find(x => x.Ativo.Equals(true))));
                ViewBag.Subtipos = (Mapper.Map<IEnumerable<Subtipo>, IEnumerable<SubtipoViewModel>>(_subtipoApp.Find(x => x.Ativo.Equals(true))));

                var model = Mapper.Map<Ferramenta, FerramentaViewModel>(_ferramentaApp.GetById(id));
                ViewBag.Marcas = (Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.Find(x => x.Ativo.Equals(true))));
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            try
            {
                var model = _ferramentaApp.GetById(id);
                _ferramentaApp.Remove(model);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
