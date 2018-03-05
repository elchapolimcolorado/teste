﻿using AutoMapper;
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
            try
            {
                var model = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Novo()
        {
            try
            { 
                var model = new CategoriaViewModel();
                model.Ativo = true;
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Erro: {0}", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Salvar(CategoriaViewModel model)
        {
            try
            {
                throw new Exception();

                var categoria = Mapper.Map<CategoriaViewModel, Categoria>(model);

                HttpPostedFileBase file = Request.Files["ImageData"];

                if (file.IsImage())
                {
                    categoria.Imagem = file.ConvertToBytes();
                    categoria.ContentType = file.ContentType;
                    categoria.NomeArquivo = file.FileName;
                }
                else
                {
                    return Json("Erro: Não é possível vincular arquivos que não seja imagens.", JsonRequestBehavior.AllowGet);
                }

                if (model.Codigo.Equals(0))
                    _categoriaApp.Add(categoria);
                else
                    _categoriaApp.Update(model.Codigo, categoria);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return Json(new { status = "error", message = ex.Message }, JsonRequestBehavior.AllowGet);
                //throw new StatusException("Your error message here");
                return erro
            }
        }

        [HttpGet]
        public ActionResult RetrieveImage(int id)
        {
            try
            {
                var model = Mapper.Map<Categoria, CategoriaViewModel>(_categoriaApp.GetById(id));
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
                var model = Mapper.Map<Categoria, CategoriaViewModel>(_categoriaApp.GetById(id));
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
