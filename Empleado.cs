using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nómina
{
    public abstract class Empleado
    {
        public string PrimerNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string SeguroSocial { get; set; }

        public decimal Salario { get; set; }

        public virtual decimal CalcularSueldo()
        {
            return 0; 
        }
    }
}
    
    
