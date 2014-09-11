using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int count = 0;
            foreach (var arg in args)
            {
                count++;
                Console.WriteLine(arg);
            }
            Console.WriteLine("Number of arguments: "+count);
        }
    }
}
