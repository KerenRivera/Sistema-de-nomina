using System;


namespace Sistema_de_nómina
{
    public sealed class EmpleadoFijo : Empleado
    {
        public override decimal CalcularSueldo()
        {
            return Salario;
        }
    }
}
