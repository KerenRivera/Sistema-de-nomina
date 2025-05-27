using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nómina.Models
{
    public class EmpleadoporComision : Empleado
    {
        public decimal VentasBrutas { get; set; }
        public decimal Comisión { get; set; }
        public override decimal CalcularSueldo() => VentasBrutas * Comisión;

    }
}
