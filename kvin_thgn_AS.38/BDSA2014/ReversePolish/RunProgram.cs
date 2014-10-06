using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishCalculator
{
    public class RunProgram
    {
        static void Main(string[] args)
        {
            //string input = "5 1 2 + 4 * + 0 /";
            Calculator td = new Calculator();
            try
            {
                Console.WriteLine("Result: " + td.Calc(args[0]));
            }
            catch (Exception e)
            {
                Console.WriteLine("A problem orccured:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
