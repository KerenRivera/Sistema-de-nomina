using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nómina
{
    public class EmpleadoPorHora : Empleado
    {
        public decimal HorasTrabajadas { get; set; }
        public override decimal CalcularSueldo()
        {
            if (HorasTrabajadas < 0)
            {
                throw new ArgumentOutOfRangeException("Las horas trabajadas no pueden ser negativas.");
            }

            if (HorasTrabajadas <= 40)
            {
                return Salario * HorasTrabajadas;
            }
            else if (HorasTrabajadas > 40)
            {
                return (Salario * 40) + (Salario * 1.5m * (HorasTrabajadas - 40));
            }

            return 0;
        }
    }

}
