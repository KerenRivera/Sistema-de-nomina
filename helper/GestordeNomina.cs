using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_nómina.Models;

namespace Sistema_de_nómina.helper
{
    public class GestordeNomina
    {
        //here relies the employee logic
        private readonly static List<Empleado> empleados = new List<Empleado>();

        public static void Menu()
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

                        EmployeeList();

                        break;
                    case 2:

                        AddPermanentEmployee();

                        break;
                    case 3:

                        AddpermanentAndCommissionEmployee();

                        break;
                    case 4:

                        AddCommissionEmployee();

                        break;
                    case 5:

                        AddHourlyEmployee();

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

        public static void AddPermanentEmployee()
        {

            Console.Clear();

            try
            {
                Console.WriteLine("Nombre:");
                string? nombre = Console.ReadLine();
                Console.WriteLine("Apellido:");
                string? apellido = Console.ReadLine();
                Console.WriteLine("Número de Seguro Social del empleado:");
                string? seguroSocial = (Console.ReadLine());
                Console.WriteLine("Salario:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salario))
                {
                    Console.WriteLine("Ingrese un número válido para el salario.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                EmpleadoFijo empleadoFijo = new()
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


        public static void AddpermanentAndCommissionEmployee()
        {

            Console.Clear();
            Console.WriteLine("Nombre:");
            string? nombre = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string? apellido = Console.ReadLine();
            Console.WriteLine("Número de Seguro Social del empleado:");
            string? seguroSocial = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Salario:");
            decimal salario = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ventas Brutas del empleado:");
            decimal ventasBrutas = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Comisión (porcentaje):");

            EmpleadoFijoDeComision empleadoComision = new()
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

        public static void AddCommissionEmployee()
        {

            Console.Clear();
            Console.WriteLine("Nombre:");
            string? nombre = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string? apellido = Console.ReadLine();
            Console.WriteLine("Número de Seguro Social del empleado:");
            string? seguroSocial = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Ventas Brutas del empleado:");
            decimal ventasBrutas = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Comisión (porcentaje):");

            EmpleadoporComision empleadoComision = new()
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

        public static void AddHourlyEmployee()
        {

            Console.Clear();
            Console.WriteLine("Nombre:");
            string? nombre = Console.ReadLine();


            Console.WriteLine("Apellido:");
            string? apellido = Console.ReadLine();


            Console.WriteLine("Número de Seguro Social del empleado:");
            string? seguroSocial = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Horas trabajadas:");
   
            if (!decimal.TryParse(Console.ReadLine(), out decimal horasTrabajadas) || horasTrabajadas < 0)
            {
                Console.WriteLine("Ingrese un número válido para las horas trabajadas.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Tarifa por hora:");
            decimal salarioPorHora;

            if (!decimal.TryParse(Console.ReadLine(), out salarioPorHora) || salarioPorHora < 0)
            {
                Console.WriteLine("Ingrese un número válido para la tarifa por hora.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }


            EmpleadoPorHora empleadoPorHoras = new()
            
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
                Console.WriteLine($"Empleado: {empleado.PrimerNombre} {empleado.ApellidoPaterno}, Salario semanal: {sueldo:C}");
            }

        }

        public static void UpdateEmployeeData()
        {

            Console.Clear();
            Console.WriteLine("Numero de seguro social del empleado:");
            string? seguroSocial = Console.ReadLine();
            Empleado? empleado = empleados.FirstOrDefault(e => e.SeguroSocial == seguroSocial);

            if (empleado != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre (Presione 'enter' si no necesita modificar este campo):");
                string? nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                    empleado.PrimerNombre = nuevoNombre;

                Console.WriteLine("Ingrese el nuevo apellido (Presione 'enter' si no necesita modificar este campo):");
                string? nuevoApellido = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoApellido))
                    empleado.ApellidoPaterno = nuevoApellido;

                if (empleado is EmpleadoFijo empleadoFijo)
                {
                    Console.WriteLine("Ingrese el nuevo salario (Presione 'enter' si no necesita modificar este campo):");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input)) return;
                    if (!decimal.TryParse(input, out decimal nuevoSalario))
                     empleadoFijo.Salario = nuevoSalario;

                }
                else if (empleado is EmpleadoFijoDeComision empleadoComision)
                {
                    Console.WriteLine("Ingrese el nuevo salario base (Presione 'enter' si no necesita modificar este campo):");
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevoSalario))
                        empleadoComision.Salario = nuevoSalario;

                    Console.WriteLine("Ingrese las nuevas ventas brutas (Presione 'enter' si no necesita modificar este campo):");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevasVentasBrutas))
                        empleadoComision.VentasBrutas = nuevasVentasBrutas;

                    Console.WriteLine("Ingrese la nueva comisión (porcentaje) (Presione 'enter' si no necesita modificar este campo):");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevaComision))
                        empleadoComision.Comisión = nuevaComision / 100;
                }
                else if (empleado is EmpleadoporComision empleadoPorComision)
                {
                    Console.WriteLine("Ingrese las nuevas ventas brutas (Presione 'enter' si no necesita modificar este campo):");
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevasventasBrutas))

                        empleadoPorComision.VentasBrutas = nuevasventasBrutas;

                    Console.WriteLine("Ingrese la nueva comisión (porcentaje) (Presione 'enter' si no necesita modificar este campo):");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevaComision))
                        empleadoPorComision.Comisión = nuevaComision / 100;
                }
                else if (empleado is EmpleadoPorHora empleadoPorHora)
                {
                    Console.WriteLine("Ingrese las nuevas horas trabajadas (Presione 'enter' si no necesita modificar este campo):");
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevasHoras))

                        empleadoPorHora.HorasTrabajadas = nuevasHoras;


                    Console.WriteLine("Ingrese la nueva tarifa por hora (Presione 'enter' si no necesita modificar este campo):");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal nuevaTarifa))
                        empleadoPorHora.Salario = nuevaTarifa;

                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            Console.WriteLine("Datos del empleado actualizados correctamente.");
            Console.ReadKey();

        }

        public static void WeeklyReport()
        {

            Console.Clear();
            Console.WriteLine("REPORTE SEMANAL DE NOMINA");

            decimal totalNomina = 0;

            foreach (var empleado in empleados)
            {
                decimal sueldo = empleado.CalcularSueldo();
                totalNomina += sueldo;

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Empleado: {empleado.PrimerNombre} {empleado.ApellidoPaterno}");
                Console.WriteLine($"Seguro social: {empleado.SeguroSocial}");
                Console.WriteLine($"Tipo: {empleado.GetType().Name}");
                Console.WriteLine($"Salario semanal: {sueldo:C}, ");

                switch (empleado)
                {
                    case EmpleadoFijo fijo:
                        Console.WriteLine($"Salario base: {fijo.Salario:C}");
                        break;
                    case EmpleadoFijoDeComision mixto:
                        Console.WriteLine($"Salario base: {mixto.Salario:C}");
                        Console.WriteLine($"Ventas brutas: {mixto.VentasBrutas:C}");
                        Console.WriteLine($"Comisión: {mixto.Comisión:P}");
                        break;
                    case EmpleadoporComision comision:
                        Console.WriteLine($"Ventas brutas: {comision.VentasBrutas:C}");
                        Console.WriteLine($"Comisión: {comision.Comisión:P}");
                        break;
                    case EmpleadoPorHora horas:
                        Console.WriteLine($"Horas trabajadas: {horas.HorasTrabajadas}");
                        Console.WriteLine($"Tarifa por hora: {horas.Salario:C}");
                        break;
                }

                Console.WriteLine("-----------------------------------------------");
            }

            Console.WriteLine($"Total de nómina semanal: {totalNomina:C}");
        }

        public static void EmployeeList()
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

            foreach (var e in empleados.Where(e => e is EmpleadoFijoDeComision))
            {
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }

            Console.WriteLine("\nEmpleados por comisión:");

            foreach (var e in empleados.Where(e => e is EmpleadoporComision))
            {
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }

            Console.WriteLine("\nEmpleados por horas:");

            foreach (var e in empleados.Where(e => e is EmpleadoPorHora))
            {
                Console.WriteLine($"Nombre: {e.PrimerNombre}, Apellido: {e.ApellidoPaterno}");

            }


        }

        public static void InicializeEmployees()
        {

            empleados.Add(new EmpleadoFijo
            {
                PrimerNombre = "Keren",
                ApellidoPaterno = "Rivera",
                SeguroSocial = "121-222-34",
                Salario = 7000
            });

            empleados.Add(new EmpleadoFijoDeComision
            {
                PrimerNombre = "Mario",
                ApellidoPaterno = "Guzmán",
                SeguroSocial = "44-44-222",
                Salario = 3000,
                VentasBrutas = 10000,
                Comisión = 0.05m
            });

            empleados.Add(new EmpleadoporComision
            {
                PrimerNombre = "Rose",
                ApellidoPaterno = "Vicini",
                SeguroSocial = "333-222-11",
                VentasBrutas = 150000,
                Comisión = 0.07m
            });

            empleados.Add(new EmpleadoPorHora
            {
                PrimerNombre = "Daniela",
                ApellidoPaterno = "Martinez",
                SeguroSocial = "209-22-398",
                HorasTrabajadas = 40,
                Salario = 3000
            });
        }

    }
}
