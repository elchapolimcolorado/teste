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
    public class DominioController : Controller
    {
        private readonly IDominioAppService _dominioApp;

        public DominioController(IDominioAppService dominioApp)
        {
            _dominioApp = dominioApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = Mapper.Map<IEnumerable<Dominio>, IEnumerable<DominioViewModel>>(_dominioApp.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Recarregar(DominioViewModel model)
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
                ViewBag.Grupos = (Mapper.Map<IEnumerable<Dominio>, IEnumerable<DominioViewModel>>(_dominioApp.GetAll()));
                var model = new DominioViewModel() { Ativo = true };
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Salvar(DominioViewModel model)
        {
            try
            {
                var dominio = Mapper.Map<DominioViewModel, Dominio>(model);

                if (model.Codigo.Equals(0))
                    _dominioApp.Add(dominio);
                else
                    _dominioApp.Update(model.Codigo, dominio);

                //return Content("<script>main.showSuccessMessage('Dominio salva com sucesso.');</script>");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Novo");
                return Content("<script>main.showErrorMessage('Ocorreu um erro ao salvar a dominio. (" + ex.Message + ")');return false;</script>");
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                ViewBag.Grupos = (Mapper.Map<IEnumerable<Dominio>, IEnumerable<DominioViewModel>>(_dominioApp.GetAll()));
                var model = Mapper.Map<Dominio, DominioViewModel>(_dominioApp.GetById(id));
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
                var model = _dominioApp.GetById(id);
                _dominioApp.Remove(model);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
