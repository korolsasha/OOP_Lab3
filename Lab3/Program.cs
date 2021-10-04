using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.Unicode;

            Parser parser = new Parser();
            parser.Instructions();
            parser.Parse();
            parser.Result();

            Console.ReadKey();
        }
    }
}
