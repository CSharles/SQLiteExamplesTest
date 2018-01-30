using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] diezNumeros = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //sintaxis de metodos
            //var numerosPares = diezNumeros.Where(np => np % 2 == 0);

            //sintaxis de consulta
            var numerosPares =
            from numeros in diezNumeros
            where (numeros % 2) == 0
            select numeros;

            Console.Write("los numeros pares son: \n");
            foreach (int numero in numerosPares)
            {
                Console.Write("{0} ", numero);
            }
            Console.Write("\n\n");
            Console.ReadKey();
        }
    }
}
