using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Dtos
{
    /// <summary>
    /// Class Mult DTO  
    /// </summary>
    public class MultDto
    {
        /// <summary>
        /// Represents the inputs of a arithmetic operation.
        /// </summary>
        public List<int> Factors { get; set; }

    }
}
