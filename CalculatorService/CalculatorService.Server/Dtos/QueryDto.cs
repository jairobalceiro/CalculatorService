using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Dtos
{
    /// <summary>
    /// Class for Query DTO
    /// </summary>
    public class QueryDto
    {
        /// <summary>
        /// The TrackingId for which journal should be queried against.
        /// </summary>
        public string Id { get; set; }
    }
}
