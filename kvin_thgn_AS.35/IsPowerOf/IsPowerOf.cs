using System;

namespace BDSA12
{

    class Program
    {
        static bool IsPowerOf(int a, int b)
        {
            if (a == 1)
            {
                return true;
            }
            if (a%b == 0 || b == 1 || b == 0)
            {
                a /= b;
                if (a > 1 || a < 0)
                {
                    return IsPowerOf(a, b);
                }
                else
                {
                    return a == 1;
                }
            }
            else
            {
                return false;                
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(IsPowerOf(Int32.Parse(args[0]), Int32.Parse(args[1])));
            }
            catch (Exception)
            {
                Console.WriteLine("Input must be as follows: int A, int B. Where the program checks if A is a power of B.");
            }
        }
    }
}
