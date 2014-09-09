using System;
using System.Collections.Generic;

namespace PolishCalculator
{
    public class Calculator
    {
        /// <summary>
        /// Main method. Prints the given input and the result if possible.
        /// </summary>
        /// <param name="args">List of command line arguments</param>
        private static void Main(string[] args)
        {
                Console.WriteLine("Input:");
                foreach (var t in args)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine("");
                Console.WriteLine("Result: " + DoThePolishStuff(args));
        }
        /// <summary>
        /// Polish calculator. Method calculates the result of input numbers and operators.
        /// If there are N numbers there must be N-1 operators. In case the input values will give no result e.g. 
        /// division by zero or the there are too few operators, the method will output zero and print a message 
        /// which informs the user of the mistake he/she made. If the method encounters an operator, but there only
        /// is one number available to compute with, it will ignore the operator.
        /// 
        /// Method does not track if the calculation exceeds Int32.MaxValue.
        /// </summary>
        /// <param name="args">An array of strings with given arguments</param>
        /// <returns>Result as integer</returns>
        public static int DoThePolishStuff(string[] args)
        {
            var numbers = new Stack<Int32>();

            foreach (var t in args)
            {
                if (t == null || t == "")
                {
                    Console.WriteLine("No input");
                    return 0;
                }
                int temp;
                if (int.TryParse(t, out temp))
                {
                    numbers.Push(temp);
                }
                else if (numbers.Count > 1)
                {
                    string o = t;
                    int j = numbers.Pop();
                    int k = numbers.Pop();
                    switch (o)
                    {
                        case "+":
                            numbers.Push(k + j);
                            break;
                        case "-":
                            numbers.Push(k - j);
                            break;
                        case "*":
                            numbers.Push(k * j);
                            break;
                        case "/":
                            if (j == 0)
                            {
                                Console.WriteLine("Dividing by zero, you are stupid");
                                return 0;
                            }
                            numbers.Push(k / j);
                            break;
                        default :
                            Console.WriteLine("Hmm...only use the following operators: +, -, * or /....i hate you");
                            return 0;
                    }
                }
            }
            if (numbers.Count > 1)
            {
                Console.WriteLine("You have too few operators...learn how to count...");
                return 0;
            }
            return numbers.Pop();
        }
    }
}
