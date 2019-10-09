using CalculatorService.Model;
using CalculatorService.Server.Dtos;
using CalculatorService.Server.Response;
using CalculatorService.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

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
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalculatorService.Server.CalculatorController"/> class.
        /// </summary>
        /// <param name="serviceCalculators">Service Calculators.</param>
        /// <param name="logger">logger.</param>
        public CalculatorController(IServiceCalculators serviceCalculators, ILogger logger)
        {
            this.serviceCalculators = serviceCalculators;
            this._logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public Response<Sums> Add([FromBody] AddDto add)
        {
            return Extension.Try<Sums>(() =>
            {

                string TrackingId = null;
                string calculations = null;

                Sums sum = this.serviceCalculators.Add(add.Addends);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.

                TrackingId = ValidateTrackingId();

                if (!string.IsNullOrEmpty(TrackingId))
                {
                    foreach (int num in add.Addends)
                    {
                        calculations += num + "+";
                    }

                    Operations operation = new Operations()
                    {
                        Id = TrackingId,
                        Operation = "Sum",
                        Date = DateTime.UtcNow.ToString("s") + "Z",
                        Calculation = string.Format("{0}", calculations + "=" + sum.Sum).Replace("+=", "=")
                    };

                    this.serviceCalculators.SaveJournal(operation);
                }
                return sum;
            }, _logger);

        }

        [HttpPost]
        [Route("[action]")]
        public Response<Sub> Sub([FromBody] SubDto sub)
        {
            return Extension.Try<Sub>(() =>
            {
                string TrackingId = null;
                var re = Request;
                var headers = re.Headers;

                Sub Difference = this.serviceCalculators.Sub(sub.Minuend, sub.Subtrahend);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.

                TrackingId = ValidateTrackingId();

                if (!string.IsNullOrEmpty(TrackingId))
                {

                    Operations operation = new Operations()
                    {
                        Id = TrackingId,
                        Operation = "Sub",
                        Date = DateTime.UtcNow.ToString("s") + "Z",
                        Calculation = sub.Minuend + "-" + sub.Subtrahend + "=" + Difference.Difference
                    };

                    this.serviceCalculators.SaveJournal(operation);
                }
                
                return Difference;
            }, _logger);

        }

        [HttpPost]
        [Route("[action]")]
        public Response<Mult> Mult([FromBody] MultDto multdto)
        {
            return Extension.Try<Mult>(() =>
            {
                string TrackingId = null;
                string Factors = null;
                
                Mult Product = this.serviceCalculators.Mult(multdto.Factors);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.

                TrackingId = ValidateTrackingId();

                if (!string.IsNullOrEmpty(TrackingId))
                {
                    foreach (int num in multdto.Factors)
                    {
                        Factors += num + "*";
                    }

                    Operations operation = new Operations()
                    {
                        Id = TrackingId,
                        Operation = "Mult",
                        Date = DateTime.UtcNow.ToString("s") + "Z",
                        Calculation = string.Format("{0}", Factors + "=" + Product.Product).Replace("*=", "=")
                    };

                    this.serviceCalculators.SaveJournal(operation);
                }
                return Product;
            }, _logger);

        }

        [HttpPost]
        [Route("[action]")]
        public Response<Div> Div([FromBody] DivDto divdto)
        {
            return Extension.Try<Div>(() =>
            {
                string TrackingId = null;
              
                Div Restul = this.serviceCalculators.Div(divdto.Dividend,divdto.Divisor);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                TrackingId = ValidateTrackingId();

                if (!string.IsNullOrEmpty(TrackingId))
                {

                    Operations operation = new Operations()
                    {
                        Id = TrackingId,
                        Operation = "Div",
                        Date = DateTime.UtcNow.ToString("s") + "Z",
                        Calculation = divdto.Dividend + "/" + divdto.Divisor + "=" + Restul.Quotient + "." + Restul.Remainder
                    };

                    this.serviceCalculators.SaveJournal(operation);
                }

                return Restul;
            }, _logger);

        }

        [HttpPost]
        [Route("[action]")]
        public Response<Sqrt> Sqrt([FromBody] SqrtDto sqrtdto)
        {
            return Extension.Try<Sqrt>(() =>
            {
                string TrackingId = null;
              

                Sqrt Restul = this.serviceCalculators.Sqrt(sqrtdto.Number);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
               TrackingId = ValidateTrackingId();

                if (!string.IsNullOrEmpty(TrackingId))
                {

                    Operations operation = new Operations()
                    {
                        Id = TrackingId,
                        Operation = "Sqrt",
                        Date = DateTime.UtcNow.ToString("s") + "Z",
                        Calculation = sqrtdto.Number + " square " + "=" + Restul.Square
                    };

                    this.serviceCalculators.SaveJournal(operation);
                }

                return Restul;
            }, _logger);
        }

        private string ValidateTrackingId()
        {
            string TrackingId = null;

            var re = Request;
            var headers = re.Headers;

            if (headers.ContainsKey("X-Evi-Tracking-Id"))
            {
                TrackingId = headers["X-Evi-Tracking-Id"];
            }

            return TrackingId;
        }
    }
}
