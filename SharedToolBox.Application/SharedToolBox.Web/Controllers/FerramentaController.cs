using AutoMapper;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Helpers;
using SharedToolBox.Web.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SharedToolBox.Web.Controllers
{
    [AllowAnonymous]
    public class FerramentaController : Controller
    {
        private readonly IFerramentaAppService _ferramentaApp;
        private readonly IMarcaAppService _marcaApp;
        private readonly ISubtipoAppService _subtipoApp;

        public FerramentaController(IMarcaAppService MarcaApp,
            ISubtipoAppService SubtipoApp,
            IFerramentaAppService FerramentaApp)
        {
            _ferramentaApp = FerramentaApp;
            _marcaApp = MarcaApp;
            _subtipoApp = SubtipoApp;
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
        public ActionResult Novo()
        {
            try
            {
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
