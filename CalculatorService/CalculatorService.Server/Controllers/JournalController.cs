using CalculatorService.Model;
using CalculatorService.Server.Dtos;
using CalculatorService.Server.Response;
using CalculatorService.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace CalculatorService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        /// <summary>
        /// The Service Calculators 
        /// </summary>
        private readonly IServiceCalculators serviceCalculators;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalculatorService.Server.JournalController"/> class.
        /// </summary>
        /// <param name="serviceCalculators">Service Calculators.</param>
        /// <param name="logger">logger.</param>
        public JournalController(IServiceCalculators serviceCalculators, ILogger logger)
        {
            this.serviceCalculators = serviceCalculators;
            this._logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public Response<IEnumerable<Operations>> Query([FromBody] QueryDto querydto)
        {
            return Extension.Try<IEnumerable<Operations>>(() =>
            {
                
                var Restul = this.serviceCalculators.Query(querydto.Id);

                return Restul;
            }, _logger);

        }
    }
}
