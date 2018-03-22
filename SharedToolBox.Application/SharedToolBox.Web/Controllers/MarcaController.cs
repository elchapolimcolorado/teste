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
    public class MarcaController : Controller
    {
        private readonly IMarcaAppService _marcaApp;

        public MarcaController(IMarcaAppService marcaApp)
        {
            _marcaApp = marcaApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Recarregar(MarcaViewModel model)
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
                var model = new MarcaViewModel() { Ativo = true };
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Salvar(MarcaViewModel model)
        {
            try
            {
                var marca = Mapper.Map<MarcaViewModel, Marca>(model);

                HttpPostedFileBase file = Request.Files["ImageData"];

                if (file.ContentLength != 0)
                {
                    if (file.IsImage())
                    {
                        marca.Imagem = file.ConvertToBytes();
                        marca.ContentType = file.ContentType;
                        marca.NomeArquivo = file.FileName;
                    }
                    else
                    {
                        throw new Exception("Erro: Não é possível vincular arquivos que não sejam imagens.");
                    }
                }
                else if (!model.Codigo.Equals(0))
                {
                    var image = Mapper.Map<Marca, MarcaViewModel>(_marcaApp.GetById(model.Codigo));

                    marca.ContentType = image.ContentType;
                    marca.NomeArquivo = image.NomeArquivo;
                    marca.Imagem = image.Imagem;
                }

                if (model.Codigo.Equals(0))
                    _marcaApp.Add(marca);
                else
                    _marcaApp.Update(model.Codigo, marca);

                //return Content("<script>main.showSuccessMessage('Marca salva com sucesso.');</script>");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Novo");
                return Content("<script>main.showErrorMessage('Ocorreu um erro ao salvar a marca. (" + ex.Message + ")');return false;</script>");
            }
        }

        [HttpGet]
        public ActionResult RetrieveImage(int id)
        {
            try
            {
                var model = Mapper.Map<Marca, MarcaViewModel>(_marcaApp.GetById(id));
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
                var model = Mapper.Map<Marca, MarcaViewModel>(_marcaApp.GetById(id));
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
                var model = _marcaApp.GetById(id);
                _marcaApp.Remove(model);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
