using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Model
{
    /// <summary>
    /// Class Operations
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// the Tracking­-Id
        /// </summary>
        public string Tracking­Id { get; set; }
        /// <summary>
        /// the Operation
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// The Calculation
        /// </summary>
        public string Calculation { get; set; }
        /// <summary>
        /// The Date of Operation
        /// </summary>
        public DateTime Date { get; set; }
    }
}
