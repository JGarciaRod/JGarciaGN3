using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sueldo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.SueldoGetAll().ToList();

                    if(query!= null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Sueldo sueldo = new ML.Sueldo();
                            sueldo.Empleado = new ML.Empleado();

                            sueldo.IdSueldo = item.IdSueldos;
                            sueldo.Cantidad = float.Parse(item.Cantidad.ToString());
                            sueldo.FormaPago = item.FormaPago;
                            sueldo.Empleado.ClaveEmpleado = item.ClaveEmpleado;
                            sueldo.Empleado.NombreEmpleado = item.NombreEmpleado;

                            result.Objects.Add(sueldo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = true;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result GetById(int? idSueldo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.SueldoGetById(idSueldo).SingleOrDefault();

                    if(query != null)
                    {
                        ML.Sueldo sueldo = new ML.Sueldo();
                        sueldo.Empleado = new ML.Empleado();

                        sueldo.IdSueldo = query.IdSueldos;
                        sueldo.IdSueldo = query.IdSueldos;
                        sueldo.Cantidad = float.Parse(query.Cantidad.ToString());
                        sueldo.FormaPago = query.FormaPago;
                        sueldo.Empleado.ClaveEmpleado = query.ClaveEmpleado;
                        sueldo.Empleado.NombreEmpleado = query.NombreEmpleado;

                        result.Object = sueldo;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }


        public static ML.Result Add(ML.Sueldo sueldo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.SueldoAdd(
                        sueldo.Cantidad,
                        sueldo.FormaPago,
                        sueldo.Empleado.ClaveEmpleado
                        );

                    if ( rowAffected > 0 )
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Sueldo sueldo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.SueldoUpdate(
                        sueldo.IdSueldo,
                        sueldo.Cantidad,
                        sueldo.FormaPago,
                        sueldo.Empleado.ClaveEmpleado
                        );

                    if (rowAffected > 0)
                    {
                        result.Correct=true;
                    }
                    else
                    { 
                        result.Correct=false; 
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int idSueldo)
        {
            ML.Result result= new ML.Result();

            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.SueldoDelete(idSueldo);

                    if (rowAffected > 0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
