using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.DepartamentosGetAll().ToList();

                    if (query != null) 
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = item.IdDepartamento;
                            departamento.DescDepartamento = item.DescDepartamento;

                            result.Objects.Add(departamento);
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

        public static ML.Result GetById(int idDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    var query = context.DepartamentosGetById(idDepartamento).SingleOrDefault();

                    result.Objects = new List<object>();
                    if (query!=null)
                    {
                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = query.IdDepartamento;
                        departamento.DescDepartamento = query.DescDepartamento;

                        result.Object = departamento;

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
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.DepartamentoAdd(
                        departamento.DescDepartamento
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

        public static ML.Result Update(ML.Departamento departamento)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.DepartamentoUpdate(
                        departamento.IdDepartamento,
                        departamento.DescDepartamento
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

        public static ML.Result Delete(int idDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciarGN3Entities context = new DL.JGarciarGN3Entities())
                {
                    int rowAffected = context.DepartamentoDelete(idDepartamento);

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
            catch( Exception ex )
            {
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
