using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class SueldoController : Controller
    {
        // GET: Sueldo
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Sueldo sueldo = new ML.Sueldo();

            ML.Result result = BL.Sueldo.GetAll();

            if (result.Correct)
            {
                sueldo.Sueldos = result.Objects;
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMesage;
            }

            return View(sueldo);
        }

        [HttpGet]
        public ActionResult Form(int? idSueldo) 
        {
            ML.Sueldo sueldo = new ML.Sueldo();
            sueldo.Empleado = new ML.Empleado();

            ML.Result resultEmpleado = BL.Empleado.GetAllDDL();

            if(idSueldo != 0) //update 
            {
                ML.Result result = BL.Sueldo.GetById(idSueldo.Value);

                if (result.Correct)
                {
                    sueldo = (ML.Sueldo)result.Object;
                    sueldo.Empleado.Empleados = resultEmpleado.Objects;

                }
            }
            else
            {
                sueldo.Empleado.Empleados = resultEmpleado.Objects;
            }

            return View(sueldo);
        }

        [HttpPost]
        public ActionResult Form(ML.Sueldo sueldo)
        {
            if(sueldo.IdSueldo == 0) //Add
            {
                ML.Result result = BL.Sueldo.Add(sueldo);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Exito al registrar";
                }
                else
                {
                    ViewBag.Error = result.ErrorMesage;
                }
            }
            else //Update
            {
                ML.Result result = BL.Sueldo.Update(sueldo);
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
        public ActionResult Delete(int idSueldo)
        {
            ML.Result result = BL.Sueldo.Delete(idSueldo);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Exito al Eliminar";
            }
            else
            {
                ViewBag.Error = result.ErrorMesage;
            }

            return PartialView("Model");
        }
    }
}