using AutoMapper;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SharedToolBox.Web.Controllers
{
    [AllowAnonymous]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaApp;

        public CategoriaController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.GetAll());
            return View(model);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            var model = new CategoriaViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Salvar(CategoriaViewModel model)
        {
            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(model);

            if (model.Codigo.Equals(0))
                _categoriaApp.Add(categoria);
            else
                _categoriaApp.Update(categoria);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var model = Mapper.Map<Categoria, CategoriaViewModel>(_categoriaApp.GetById(id));
            return View(model);
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            try
            {
                //var categoria = Mapper.Map<CategoriaViewModel, Categoria>(model);
                var model = _categoriaApp.GetById(id);
                _categoriaApp.Remove(model);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
