using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ML.Persona persona = new ML.Persona();

            Console.WriteLine("INGRESE EL NOMBRE: ");
            persona.Nombre = Console.ReadLine();

            Console.WriteLine("INGRESE EL AP: ");
            persona.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("INGRESE EL AM: ");
            persona.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("INGRESE LA FECHA DE NACIMIENTO: ");
            persona.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("INGRESE EL SEXO: ");
            persona.Sexo = Console.ReadLine();

            Console.WriteLine("INGRESE EL ESTADO: ");
            persona.EstadoNacimiento = Console.ReadLine();

            string CURP = BL.Persona.GenerarCurp(persona);

        }
    }
}
