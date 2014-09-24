using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace PolishCalculator
{
    class ReversePolishCalc
    {
        //static void Main(string[] args)
        //{
        //    string input = "5 1 2 + 4 * + 3 -";
        //    Calc(input);
        //}

        public static int Calc(string s)
        {
            if (s == null || s.Equals(""))
            {
                Console.WriteLine("no input");
                return 0;
            }
            var stack = new Stack<int>();
            string[] units = s.Split(' ');
            foreach (var c in units)
            {
                int num;
                if (int.TryParse(c, out num))
                {
                    stack.Push(num);
                }
                else if (stack.Count >= 2)
                {
                    int one = stack.Pop();
                    int two = stack.Pop();
                    switch (c)
                    {
                        case "+":
                            stack.Push(two + one);
                            break;
                        case "-":
                            stack.Push(two - one);
                            break;
                        case "*":
                            stack.Push(two*one);
                            break;
                        case "/":
                            if (one == 0)
                            {
                                Console.WriteLine("Dividing by zero");
                                return 0;
                            }
                            stack.Push(two/one);
                            break;
                        default:
                            stack.Push(two);
                            stack.Push(one);
                            break;
                    }
                }
            }
            if (stack.Count != 1)
            {
                Console.WriteLine("Wrong amount of numbers or operators");
                return 0;
            }
            Console.WriteLine("Done");
            return stack.Pop();
        }
    }
}
