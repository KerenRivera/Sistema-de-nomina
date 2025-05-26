using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Sistema_de_nómina.helper;
using System.Reflection.Metadata.Ecma335;



namespace Sistema_de_nómina
{
    public class Program
    {

        static bool empleadosdePrueba = false;
        public static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Sistema de nómina\n");

            Console.WriteLine("¿Le gustaria cargar empleados de prueba? (S/N)");
            string? answer = Console.ReadLine()?.Trim().ToLower();

            if ((answer == "s" || answer == "si") && !empleadosdePrueba)
            {
                GestordeNomina.InicializeEmployees();
                empleadosdePrueba = true;
                Console.WriteLine("Empleados de prueba cargados correctamente.\n");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                
            }
            Console.Clear();
            GestordeNomina.Menu();
        }
    }
     
}