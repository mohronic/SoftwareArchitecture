using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishCalculator
{
    /// <summary>
    /// IOperation is an interface which generalize an operation
    /// </summary>
    public interface IOperation
    {
        double Execute(double arg1, params double[] argn);
    }
}
