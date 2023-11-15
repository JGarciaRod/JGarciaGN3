using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public int ClaveEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ML.Departamento Depa { get; set; }
        public DateTime FechaNacimeinto { get; set; }

        public List<object> Empleados { get; set; }
    }
}
