using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishCalculator
{
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
