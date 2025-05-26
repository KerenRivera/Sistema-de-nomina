using System;


namespace Sistema_de_nómina
{
    public class EmpleadoFijo : Empleado
    {
        public override decimal CalcularSueldo()
        {
            return Salario;
        }
    }
}
