using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report
{
    /// <summary>
    /// An object containing either a report or an ReportError.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TError"></typeparam>
    public class Report<TData, TError>
    {
        public TData Data { get; set; }
        public TError Error { get; set; }
    }
}
