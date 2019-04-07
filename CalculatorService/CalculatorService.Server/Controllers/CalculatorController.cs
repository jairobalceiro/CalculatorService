using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Server.Dtos;
using CalculatorService.Service;
using CalculatorService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace CalculatorService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// The Service Calculators 
        /// </summary>
        private readonly IServiceCalculators serviceCalculators;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<CalculatorController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalculatorService.Server.CalculatorController"/> class.
        /// </summary>
        /// <param name="serviceCalculators">Service Calculators.</param>
        /// <param name="logger">logger.</param>
        public CalculatorController(IServiceCalculators serviceCalculators, ILogger<CalculatorController> logger)
        {
            this.serviceCalculators = serviceCalculators;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Sums> Add([FromBody] AddDto add)
        {
            try
            {
                string TrackingId = null;
                var re = Request;
                var headers = re.Headers;

                Sums sum =  this.serviceCalculators.Add(add.Addends);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                if (headers.ContainsKey("X-Evi-Tracking-Id"))
                {
                    TrackingId = headers["X-Evi-Tracking-Id"];

                    if(!string.IsNullOrEmpty(TrackingId))
                    {

                    }
                }

                return sum;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                return new Sums();
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Sub> Sub([FromBody] SubDto sub)
        {
            try
            {
                var re = Request;
                var headers = re.Headers;

                Sub Difference = this.serviceCalculators.Sub(sub.Minuend, sub.Subtrahend);

                return Difference;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                return new Sub();
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Mult> Mult([FromBody] MultDto multdto)
        {
            try
            {
                var re = Request;
                var headers = re.Headers;

                Mult Product = this.serviceCalculators.Mult(multdto.Factors);

                return Product;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                return new Mult();
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Div> Div([FromBody] DivDto divdto)
        {
            try
            {
                var re = Request;
                var headers = re.Headers;

                Div Restul = this.serviceCalculators.Div(divdto.Dividend,divdto.Divisor);

                return Restul;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                return new Div();
            }

        }

        private void SaveJournal(string TrackingId, Operations Operation)
        {

        }

    }
}
