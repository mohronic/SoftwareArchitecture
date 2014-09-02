using System;

namespace BDSA12
{

    class Program
    {
        static bool IsPowerOf(int a, int b)
        {
            // Checks if b is one, and the program will get an integerOverflowException
            if (b == 1 && a != 1)
            {
                return false;
            }
            while (Math.Abs(a) > 1)
            {
                if (a % b != 0)
                {
                    return false;
                }
                else
                {
                    a /= b;
                    if (a == -1 && b != -1)
                    {
                        return false;
                    }
                    IsPowerOf(a, b);
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            bool a = IsPowerOf(Int32.Parse(args[0]), Int32.Parse(args[1]));
            Console.WriteLine(a);
        }

    }
}
