using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();

            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMesage;
            }

            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(int? claveEmpleado) 
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Depa = new ML.Departamento();

            //agregar Result para ddl de departamentos
            ML.Result resultDepa = BL.Departamento.GetAll();

            if(claveEmpleado != 0) //update
            {
                ML.Result result = BL.Empleado.GetByClave(claveEmpleado.Value);

                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object;
                    empleado.Depa.Departamentos = resultDepa.Objects;
                }
            }
            else //add
            {
                empleado.Depa.Departamentos = resultDepa.Objects;
            }

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            if(empleado.ClaveEmpleado == 0) //add
            {
                ML.Result result = BL.Empleado.Add(empleado);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Exito al registrar";
                }
                else
                {
                    ViewBag.Error = result.ErrorMesage;
                }
            }
            else //update
            {
                ML.Result result = BL.Empleado.Update(empleado);
                if(result.Correct)
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
        public ActionResult Delete(int claveEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(claveEmpleado);
            if(result.Correct)
            {
                ViewBag.Mensaje = "Exito al eliminar";
            }
            else
            {
                ViewBag.Error = result.ErrorMesage;
            }
            return PartialView("Modal");
        }
    }
}