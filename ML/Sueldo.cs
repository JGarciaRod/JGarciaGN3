using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Sueldo
    {
        public int IdSueldo { get; set; }
        public float Cantidad { get; set; }
        public string FormaPago { get; set; }
        public ML.Empleado Empleado { get; set; }

        public List<object> Sueldos { get; set; }
    }
}
