using System;
using System.Collections.Generic;
using System.Linq;

namespace PolishCalculator
{
    public class Calculator
    {
        // Dictinary used to make adding operations easier.
        private Dictionary<string, IOperation> _dictionary = new Dictionary<string, IOperation>();

        public Calculator()
        {
            _dictionary.Add("+", new BinaryOperation((x,y)=> x+y));
            _dictionary.Add("-", new BinaryOperation((x, y) => x - y));
            _dictionary.Add("*", new BinaryOperation((x, y) => x * y));
            _dictionary.Add("/", new BinaryOperation((x, y) => x / y));
            _dictionary.Add("^", new BinaryOperation((x, y) => Math.Pow(x, y)));

            _dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
            _dictionary.Add("abs", new UnaryOperation(x => Math.Abs(x)));

        }

        /// <summary>
        /// Calc is the method used to read the input and calculate it
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double Calc(string s) 
        {
             if (s == null || s.Equals(""))
            {
                Console.WriteLine("no input");
                return 0;
            }
            var stack = new Stack<double>();
            string[] units = s.Split(' ');
            foreach (var c in units)
            {
                double num;
                if (double.TryParse(c, out num))
                {
                    stack.Push(num);
                }
                else if (_dictionary.ContainsKey(c))
                {
                    IOperation operation = _dictionary[c];
                    if (operation is UnaryOperation && stack.Count > 0)
                    {
                        stack.Push(operation.Execute(stack.Pop()));
                    }
                    else if (operation is BinaryOperation && stack.Count > 1)
                    {
                        double one = stack.Pop();
                        double two = stack.Pop();
                        double res = operation.Execute(two, one);
                        stack.Push(res);
                    }
                    else
                    {
                        throw new Exception("too many tokens");
                    }

                }
                else
                {
                    throw new Exception("Wrong token: " + c + ", check input");
                }
            }
            if (stack.Count() != 1)
            {
                throw new Exception("too many numbers");
            }
            return stack.Pop();
        }

    }

}
