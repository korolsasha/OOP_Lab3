using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Calculations
    {
        public decimal Add(decimal op1, decimal op2)
        {
            return op1 + op2;
        }

        public decimal Substract(decimal op1, decimal op2)
        {
            return op1 - op2;
        }
        public decimal Multiply(decimal op1, decimal op2)
        {
            return op1 * op2;
        }
    }

    class Program
    {
        public static string Normalize (string operation)
        {
            return operation
                .Replace(" ", "")
                .Replace("=", "")
                .Replace(',', '.');
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.Unicode;

            Calculations calc = new Calculations();

            char[] arr;

            Console.WriteLine("Меню");
            Console.WriteLine();
            Console.WriteLine("Інструкція:");
            Console.WriteLine("Введіть у рядок нижче операцію, яку ви бажаєте винати, у вигляді: ");
            Console.WriteLine("(операнд1) + (знак операції (+, - або *), (операнд 2))");
            Console.WriteLine();
            Console.WriteLine("Введіть операцію: ");
            string operation = Convert.ToString(Console.ReadLine());

            operation = Normalize(operation);

            arr = operation.ToCharArray();

            int[] temp = new int[arr.Length];
            int k = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0 || arr[i] <=9 )
                {
                    temp[k] = arr[i];
                    k++;
                }
            }

            double op1 = 0;
            double op2 = 0;
            string opm = "+";

            Console.ReadKey();
        }
    }
}
