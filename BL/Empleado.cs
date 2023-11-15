using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    if(query!= null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.ClaveEmpleado = item.ClaveEmpleado;
                            empleado.NombreEmpleado = item.NombreEmpleado;
                            empleado.FechaIngreso = item.FechaIngreso.Value;
                            empleado.FechaNacimeinto = item.FechaNacimiento.Value;
                            empleado.Depa = new ML.Departamento();
                            empleado.Depa.IdDepartamento = item.IdDepartamento;
                            empleado.Depa.DescDepartamento = item.DescDepartamento;

                            result.Objects.Add(empleado);    
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetByClave(int ClaveEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.EmpleadoGetById(ClaveEmpleado).SingleOrDefault();

                    result.Objects = new List<object>();

                    if (query!= null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.ClaveEmpleado = query.ClaveEmpleado;
                        empleado.NombreEmpleado = query.NombreEmpleado;
                        empleado.FechaIngreso = query.FechaIngreso.Value;
                        empleado.Depa = new ML.Departamento();
                        empleado.Depa.IdDepartamento = query.IdDepartamento;
                        empleado.FechaNacimeinto = query.FechaNacimiento.Value;

                        result.Object = empleado;

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
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            //empleado.Depa = new ML.Departamento();

            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.EmpleadoAdd(
                        empleado.NombreEmpleado,
                        empleado.FechaIngreso,
                        empleado.Depa.IdDepartamento,
                        empleado.FechaNacimeinto
                        );

                    if (rowAffected > 0)
                    {
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
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.EmpleadoUpdate(
                        empleado.ClaveEmpleado,
                        empleado.NombreEmpleado,
                        empleado.FechaIngreso,
                        empleado.Depa.IdDepartamento,
                        empleado.FechaNacimeinto
                        );

                    if (rowAffected>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int claveEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.EmpleadoDelete(claveEmpleado);

                    if (rowAffected > 0)
                    {
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
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllDDL()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.EmpleadoDDL().ToList();

                    if(query!= null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.ClaveEmpleado = item.ClaveEmpleado;
                            empleado.NombreEmpleado = item.NombreEmpleado;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


    }
}
