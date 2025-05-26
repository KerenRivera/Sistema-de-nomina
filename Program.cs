using System;
using System.Collections.Generic;
using System.Linq;



namespace Sistema_de_nómina
{
    public class Program
    {

        static List<Empleado> empleados = new List<Empleado>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Sistema de nómina\n");
            Menu();
        }


       static void Menu()
       {
            bool exit = false;

            do
            {
  
                Console.WriteLine("¿Qué desea hacer?\n");
                Console.WriteLine("1. Mostrar empleados");
                Console.WriteLine("2. Añadir empleado Fijo");
                Console.WriteLine("3. Añadir empleado fijo y por comisión");
                Console.WriteLine("4. Añadir empleado por comisión");
                Console.WriteLine("5. Añadir empleado por horas");
                Console.WriteLine("6. Mostrar pago");
                Console.WriteLine("7. Actualizar datos de empleado");
                Console.WriteLine("8. Generar reporte semanal de nómina");
                Console.WriteLine("9. Salir del sistema");
                Console.Write("Seleccione una opción: ");

                int userOption;

                try
                {
                    userOption = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Número fuera de rango. Por favor, ingrese un número válido.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                    switch (userOption)
                {
                    case 1:

                        employeeList();

                        break;
                    case 2:

                        addPermanentEmployee();

                        break;
                    case 3:

                        addpermanentAndCommissionEmployee();

                        break;
                    case 4:

                        addCommissionEmployee();

                        break;
                    case 5:

                        addHourlyEmployee();

                        break;
                    case 6:

                        ShowPayment();

                        break;
                    case 7:

                        UpdateEmployeeData();

                        break;
                    case 8:

                        WeeklyReport();

                        break;
                    case 9:
                        Console.WriteLine("Saliendo del sistema");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (!exit);

       }

        public static void addPermanentEmployee()
        {

            Console.Clear();

            try
            {
                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Apellido:");
                string apellido = Console.ReadLine();
                Console.WriteLine("Número de Seguro Social del empleado:");
                string seguroSocial = (Console.ReadLine());
                Console.WriteLine("Salario:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salario))
                {
                    Console.WriteLine("Ingrese un número válido para el salario.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                EmpleadoFijo empleadoFijo = new EmpleadoFijo
                {
                    PrimerNombre = nombre,
                    ApellidoPaterno = apellido,
                    SeguroSocial = seguroSocial,
                    Salario = salario
                };
                empleados.Add(empleadoFijo);
                Console.WriteLine("Empleado Fijo añadido correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }


         public static void addpermanentAndCommissionEmployee()
         {
            
            Console.Clear();
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine("Número de Seguro Social del empleado:");
            string seguroSocial = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Salario:");
            decimal salario = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ventas Brutas del empleado:");
            decimal ventasBrutas = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Comisión (porcentaje):");

            EmpleadoComision empleadoComision = new EmpleadoComision
            {
                PrimerNombre = nombre,
                ApellidoPaterno = apellido,
                SeguroSocial = seguroSocial,
                Salario = salario,
                VentasBrutas = ventasBrutas,
                Comisión = Convert.ToDecimal(Console.ReadLine()) / 100
            };
            empleados.Add(empleadoComision);
            Console.WriteLine("Empleado Fijo y por comisión añadido correctamente.");

         }

         public static void addCommissionEmployee()
         {

            Console.Clear();
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine("Número de Seguro Social del empleado:");
            string seguroSocial = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Ventas Brutas del empleado:");
            decimal ventasBrutas = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Comisión (porcentaje):");

            EmpleadoporComisión empleadoComision = new EmpleadoporComisión
            {
                PrimerNombre = nombre,
                ApellidoPaterno = apellido,
                SeguroSocial = seguroSocial,
                VentasBrutas = ventasBrutas,
                Comisión = Convert.ToDecimal(Console.ReadLine()) / 100
            };
            empleados.Add(empleadoComision);
            Console.WriteLine("Empleado por comisión añadido correctamente.");

         }

         public static void addHourlyEmployee()
         {

            Console.Clear();
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine("Número de Seguro Social del empleado:");
            string seguroSocial = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Horas trabajadas:");
            decimal horasTrabajadas = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Tarifa por hora:");
            decimal salarioPorHora = Convert.ToDecimal(Console.ReadLine());

            EmpleadoPorHora empleadoPorHoras = new EmpleadoPorHora
            {
                PrimerNombre = nombre,
                ApellidoPaterno = apellido,
                SeguroSocial = seguroSocial,
                HorasTrabajadas = horasTrabajadas,
                Salario = salarioPorHora
            };
            empleados.Add(empleadoPorHoras);
            Console.WriteLine("Empleado por horas añadido correctamente.");

         }

         public static void ShowPayment()
         {

            Console.Clear();
            Console.WriteLine("Calculando pago...");
            foreach (var empleado in empleados)
            {
                decimal sueldo = empleado.CalcularSueldo();
                Console.WriteLine($"Empleado: {empleado.PrimerNombre} {empleado.ApellidoPaterno}, Salario: {sueldo:C}");
            }

         }

         public static void UpdateEmployeeData()
         {

            Console.Clear();
            Console.WriteLine("Numero de seguro social del empleado:");
            string seguroSocial = Convert.ToString(Console.ReadLine());
            Empleado empleado = empleados.FirstOrDefault(e => e.SeguroSocial == seguroSocial);

            if (empleado != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre (Presione 'enter' si no necesita modificar este campo):");
                empleado.PrimerNombre = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo apellido (Presione 'enter' si no necesita modificar este campo):");
                empleado.ApellidoPaterno = Console.ReadLine();

                if (empleado is EmpleadoFijo empleadoFijo)
                {
                    Console.WriteLine("Ingrese el nuevo salario (Presione 'enter' si no necesita modificar este campo):");
                    empleadoFijo.Salario = Convert.ToDecimal(Console.ReadLine());
                }
                else if (empleado is EmpleadoComision empleadoComision)
                {
                    Console.WriteLine("Ingrese el nuevo salario base (Presione 'enter' si no necesita modificar este campo):");
                    empleadoComision.Salario = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Ingrese las nuevas ventas brutas (Presione 'enter' si no necesita modificar este campo):");
                    empleadoComision.VentasBrutas = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Ingrese la nueva comisión (porcentaje) (Presione 'enter' si no necesita modificar este campo):");
                    empleadoComision.Comisión = Convert.ToDecimal(Console.ReadLine()) / 100;
                }
                else if (empleado is EmpleadoporComisión empleadoPorComision)
                {
                    Console.WriteLine("Ingrese las nuevas ventas brutas (Presione 'enter' si no necesita modificar este campo):");
                    empleadoPorComision.VentasBrutas = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Ingrese la nueva comisión (porcentaje) (Presione 'enter' si no necesita modificar este campo):");
                    empleadoPorComision.Comisión = Convert.ToDecimal(Console.ReadLine()) / 100;
                }
                else if (empleado is EmpleadoPorHora empleadoPorHora)
                {
                    Console.WriteLine("Ingrese las nuevas horas trabajadas (Presione 'enter' si no necesita modificar este campo):");
                    //empleadoPorHora.HorasTrabajadas;

                    try
                    {
                        empleadoPorHora.HorasTrabajadas = Convert.ToDecimal(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor, ingrese un número válido para las horas trabajadas.");
                        return;
                    }

                    Console.WriteLine("Ingrese la nueva tarifa por hora (Presione 'enter' si no necesita modificar este campo):");
                    empleadoPorHora.Salario = Convert.ToDecimal(Console.ReadLine());

                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            Console.WriteLine("Datos del empleado actualizados correctamente.");

         }

         public static void WeeklyReport()
         {

            Console.Clear();
            ShowPayment();
            Console.WriteLine("Generando reporte semanal de nómina.");

            foreach (var empleado in empleados)
            {
                decimal sueldo = empleado.CalcularSueldo();
                Console.WriteLine($"Empleado: {empleado.PrimerNombre} {empleado.ApellidoPaterno}, Sueldo: {sueldo:C}");

            }
         }

        //public static void employeeList()
        //{

        //    Console.Clear();
        //    if (empleados.Count == 0)
        //    {
        //        Console.WriteLine("No hay empleados registrados.");
        //        Console.ReadKey();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Empleados registrados:");

        //        for (int i = 0; i < empleados.Count; i++)
        //        {
        //            Console.WriteLine($"{i + 1}. {empleados[i].PrimerNombre} {empleados[i].ApellidoPaterno}, Seguro Social: {empleados[i].SeguroSocial}, {empleados[i].Salario}");
        //        }
        //    }

        //}

        public static void employeeList()
        {
            Console.Clear();

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Empleados Fijos:");

            foreach (var e in empleados.Where(e => e is EmpleadoFijo))
            {   
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }

            Console.WriteLine("\nEmpleados Fijos + comisión:");

            foreach (var e in empleados.Where(e => e is EmpleadoComision))
            {
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }

            Console.WriteLine("\nEmpleados por comisión:");

            foreach (var e in empleados.Where(e => e is EmpleadoporComisión))
            {
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }

            Console.WriteLine("\nEmpleados por horas:");

            foreach (var e in empleados.Where(e => e is EmpleadoPorHora))
            {
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }
           
           
        }
    }

}