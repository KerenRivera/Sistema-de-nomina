using System;


namespace Sistema_de_nómina.Models
{
    public class EmpleadoFijo : Empleado
    {
        public override decimal CalcularSueldo() => Salario;

    }
}
