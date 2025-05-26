using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nómina
{
    public class EmpleadoFijoDeComision : Empleado //empleado que gana salario base y aparte gana una comision por ventas
    {
        public decimal VentasBrutas { get; set; }
        public decimal Comisión { get; set; }
        public override decimal CalcularSueldo() => Salario + (VentasBrutas * Comisión);

        
    }

}
