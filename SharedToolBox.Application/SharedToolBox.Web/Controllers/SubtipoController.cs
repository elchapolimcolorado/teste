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
    public class SubtipoController : Controller
    {
        private readonly ISubtipoAppService _subtipoApp;
        private readonly ITipoAppService _tipoApp;

        public SubtipoController(ITipoAppService TipoApp, ISubtipoAppService SubtipoApp)
        {
            _subtipoApp = SubtipoApp;
            _tipoApp = TipoApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ViewBag.Tipos = (Mapper.Map<IEnumerable<Tipo>, IEnumerable<TipoViewModel>>(_tipoApp.Find(x => x.Ativo.Equals(true))));
                var model = Mapper.Map<IEnumerable<Subtipo>, IEnumerable<SubtipoViewModel>>(_subtipoApp.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Recarregar(SubtipoViewModel model)
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
                var model = new SubtipoViewModel()
                {
                    Ativo = true
                };

                ViewBag.Tipos = (Mapper.Map<IEnumerable<Tipo>, IEnumerable<TipoViewModel>>(_tipoApp.Find(x => x.Ativo.Equals(true))));

                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Salvar(SubtipoViewModel model)
        {
            try
            {
                var Subtipo = Mapper.Map<SubtipoViewModel, Subtipo>(model);

                HttpPostedFileBase file = Request.Files["ImageData"];

                if (file.ContentLength != 0)
                {
                    if (file.IsImage())
                    {
                        Subtipo.Imagem = file.ConvertToBytes();
                        Subtipo.ContentType = file.ContentType;
                        Subtipo.NomeArquivo = file.FileName;
                    }
                    else
                    {
                        throw new Exception("Erro: Não é possível vincular arquivos que não sejam imagens.");
                    }
                }
                else if (!model.Codigo.Equals(0))
                {
                    var image = Mapper.Map<Subtipo, SubtipoViewModel>(_subtipoApp.GetById(model.Codigo));

                    Subtipo.ContentType = image.ContentType;
                    Subtipo.NomeArquivo = image.NomeArquivo;
                    Subtipo.Imagem = image.Imagem;
                }

                if (model.Codigo.Equals(0))
                    _subtipoApp.Add(Subtipo);
                else
                    _subtipoApp.Update(model.Codigo, Subtipo);

                //return Content("<script>main.showSuccessMessage('Subtipo salva com sucesso.');</script>");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Novo");
                return Content("<script>main.showErrorMessage('Ocorreu um erro ao salvar a Subtipo. (" + ex.Message + ")');return false;</script>");
            }
        }

        [HttpGet]
        public ActionResult RetrieveImage(int id)
        {
            try
            {
                var model = Mapper.Map<Subtipo, SubtipoViewModel>(_subtipoApp.GetById(id));
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
                var model = Mapper.Map<Subtipo, SubtipoViewModel>(_subtipoApp.GetById(id));
                ViewBag.Tipos = (Mapper.Map<IEnumerable<Tipo>, IEnumerable<TipoViewModel>>(_tipoApp.Find(x => x.Ativo.Equals(true))));
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
                var model = _subtipoApp.GetById(id);
                _subtipoApp.Remove(model);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
