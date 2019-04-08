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
            this._logger = logger;
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
                string calculations = null;

                if (add.Addends == null)
                    return BadRequest("invalid request/arguments");

                Sums sum =  this.serviceCalculators.Add(add.Addends);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                if (headers.ContainsKey("X-Evi-Tracking-Id"))
                {
                    TrackingId = headers["X-Evi-Tracking-Id"];

                    if(!string.IsNullOrEmpty(TrackingId))
                    {
                        foreach(int num in add.Addends)
                        {
                            calculations +=  num + "+";
                        }

                        Operations operation = new Operations()
                        {
                            Id = TrackingId,
                            Operation = "Sum",
                            Date = DateTime.UtcNow.ToString("s") + "Z",
                            Calculation = string.Format("{0}",calculations + "=" + sum.Sum).Replace("+=","=")
                        };

                        this.serviceCalculators.SaveJournal(operation);
                    }
                }

                return sum;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Sub> Sub([FromBody] SubDto sub)
        {
            try
            {
                string TrackingId = null;
                var re = Request;
                var headers = re.Headers;

                if (sub.Minuend == 0 && sub.Subtrahend == 0 )
                    return BadRequest("invalid request/arguments");

                Sub Difference = this.serviceCalculators.Sub(sub.Minuend, sub.Subtrahend);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                if (headers.ContainsKey("X-Evi-Tracking-Id"))
                {
                    TrackingId = headers["X-Evi-Tracking-Id"];

                    if (!string.IsNullOrEmpty(TrackingId))
                    {
                       
                        Operations operation = new Operations()
                        {
                            Id = TrackingId,
                            Operation = "Sub",
                            Date = DateTime.UtcNow.ToString("s") + "Z",
                            Calculation = sub.Minuend + "-" +  sub.Subtrahend + "=" + Difference.Difference
                        };

                        this.serviceCalculators.SaveJournal(operation);
                    }
                }
                return Difference;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Mult> Mult([FromBody] MultDto multdto)
        {
            try
            {
                string TrackingId = null;
                var re = Request;
                var headers = re.Headers;
                string Factors = null;
                if (multdto.Factors == null)
                    return BadRequest("invalid request/arguments");

                Mult Product = this.serviceCalculators.Mult(multdto.Factors);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                if (headers.ContainsKey("X-Evi-Tracking-Id"))
                {
                    TrackingId = headers["X-Evi-Tracking-Id"];

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
                }
                return Product;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Div> Div([FromBody] DivDto divdto)
        {
            try
            {
                string TrackingId = null;
                var re = Request;
                var headers = re.Headers;

                if (divdto.Divisor == 0)
                    return BadRequest("invalid request/arguments");

                Div Restul = this.serviceCalculators.Div(divdto.Dividend,divdto.Divisor);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                if (headers.ContainsKey("X-Evi-Tracking-Id"))
                {
                    TrackingId = headers["X-Evi-Tracking-Id"];

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
                }

                return Restul;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Sqrt> Sqrt([FromBody] SqrtDto sqrtdto)
        {
            try
            {
                string TrackingId = null;
                var re = Request;
                var headers = re.Headers;

                if (sqrtdto.Number == 0)
                    return BadRequest("invalid request/arguments");

                Sqrt Restul = this.serviceCalculators.Sqrt(sqrtdto.Number);

                //If a 'TrackingId’ was provided, the server should store this request’s details inside it’s 
                //journal, indexed by the given Id.
                if (headers.ContainsKey("X-Evi-Tracking-Id"))
                {
                    TrackingId = headers["X-Evi-Tracking-Id"];

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
                }

                return Restul;
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }


    }
}
