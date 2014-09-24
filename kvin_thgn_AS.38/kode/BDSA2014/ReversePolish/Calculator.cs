using System;
using System.Collections.Generic;
using System.Linq;

namespace PolishCalculator
{
    public class Calculator
    {
        // Dictinary used to make adding operations easier.
        private Dictionary<string, IOperation> _dictionary = new Dictionary<string, IOperation>();

        static void Main(string[] args)
        {
            //string input = "5 1 2 + 4 * + 0 /";
            Calculator td = new Calculator();
            Console.WriteLine("Result: "+td.Calc(args[0]));
        }

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
                        Console.WriteLine("too many tokens");
                        return 0;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong token: " + c + ", check input");
                    return 0;
                }
            }
            if (stack.Count() != 1)
            {
                Console.WriteLine("too many numbers");
                return 0;
            }
            return stack.Pop();
        }

    }

    /// <summary>
    /// IOperation is an interface which generalize an operation
    /// </summary>
    public interface IOperation
    {
        double Execute(double arg1, params double[] argn);
    }
        
    /// <summary>
    /// UnaryOperation generalize an operation with one parameter by using a delegate.
    /// </summary>
    public class UnaryOperation : IOperation
    {
        private Func<double, double> _operation;
        public UnaryOperation(Func<double, double> function)
        {
            _operation = function;
        }
        public double Execute(double arg1, params double[] argn)
        {
            return _operation(arg1);
        }
    }

    /// <summary>
    /// BinaryOperation generalize an operation with two parameters by using a delegate
    /// </summary>
    public class BinaryOperation : IOperation
    {
        private Func<double, double, double> _operation;
        public BinaryOperation(Func<double, double, double> function)
        {
            _operation = function;
        }
        public double Execute(double arg1, params double[] argn)
        {
            return _operation(arg1, argn[0]);
        }
    }

}
