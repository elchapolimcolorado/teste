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
    public class TipoController : Controller
    {
        private readonly ITipoAppService _TipoApp;
        private readonly ICategoriaAppService _CategoriaApp;

        public TipoController(ITipoAppService TipoApp,
            ICategoriaAppService CategoriaApp)
        {
            _TipoApp = TipoApp;
            _CategoriaApp = CategoriaApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = Mapper.Map<IEnumerable<Tipo>, IEnumerable<TipoViewModel>>(_TipoApp.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Recarregar(TipoViewModel model)
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
                var model = new TipoViewModel() { Ativo = true };
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Salvar(TipoViewModel model)
        {
            try
            {
                var Tipo = Mapper.Map<TipoViewModel, Tipo>(model);

                HttpPostedFileBase file = Request.Files["ImageData"];

                if (file.IsImage())
                {
                    Tipo.Imagem = file.ConvertToBytes();
                    Tipo.ContentType = file.ContentType;
                    Tipo.NomeArquivo = file.FileName;
                }
                else
                {
                    throw new Exception("Erro: Não é possível vincular arquivos que não seja imagens.");
                }

                if (model.Codigo.Equals(0))
                    _TipoApp.Add(Tipo);
                else
                    _TipoApp.Update(model.Codigo, Tipo);

                //return Content("<script>main.showSuccessMessage('Tipo salva com sucesso.');</script>");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Novo");
                return Content("<script>main.showErrorMessage('Ocorreu um erro ao salvar a Tipo. (" + ex.Message + ")');return false;</script>");
            }
        }

        [HttpGet]
        public ActionResult RetrieveImage(int id)
        {
            try
            {
                var model = Mapper.Map<Tipo, TipoViewModel>(_TipoApp.GetById(id));
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
                var model = Mapper.Map<Tipo, TipoViewModel>(_TipoApp.GetById(id));
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
                var model = _TipoApp.GetById(id);
                _TipoApp.Remove(model);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
