using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishCalculator
{
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
}
