using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Departamento departamento = new ML.Departamento();

            ML.Result result = BL.Departamento.GetAll();

            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMesage;
            }
            return View(departamento);
        }

        [HttpGet]
        public ActionResult Form(int? idDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();

            if (idDepartamento != 0) //update
            {
                ML.Result result = BL.Departamento.GetById(idDepartamento.Value);
                if (result.Correct)
                {
                    departamento = (ML.Departamento)result.Object;
                }
            }
            else //add
            {

            }
            return View(departamento);
        }

        [HttpPost]
        public ActionResult Form(ML.Departamento departamento)
        {
            if(departamento.IdDepartamento == 0) //add
            {
                ML.Result result = BL.Departamento.Add(departamento);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Exito al Registrar";
                }
                else
                {
                    ViewBag.Error = result.ErrorMesage;
                }
            }
            else //update
            {
                ML.Result result = BL.Departamento.Update(departamento);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Exito al actualizar";
                }
                else
                {
                    ViewBag.Error = result.ErrorMesage;
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Deelete(int idDepartamento)
        {
            ML.Result result = BL.Departamento.Delete(idDepartamento);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Error al eliminar";
            }
            else
            {
                ViewBag.Error = result.ErrorMesage;
            }

            return PartialView("Model");
        }
    }
}