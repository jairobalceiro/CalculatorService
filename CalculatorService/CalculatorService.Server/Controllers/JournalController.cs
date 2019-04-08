using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Model;
using CalculatorService.Server.Dtos;
using CalculatorService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<JournalController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalculatorService.Server.JournalController"/> class.
        /// </summary>
        /// <param name="serviceCalculators">Service Calculators.</param>
        /// <param name="logger">logger.</param>
        public JournalController(IServiceCalculators serviceCalculators, ILogger<JournalController> logger)
        {
            this.serviceCalculators = serviceCalculators;
            this._logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public IEnumerable<Operations> Query([FromBody] QueryDto querydto)
        {
            try
            {
                
                var Restul = this.serviceCalculators.Query(querydto.Id);

                return Restul;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                return new Collection<Operations>();
            }

        }
    }
}
