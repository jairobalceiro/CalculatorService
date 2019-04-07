using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Server.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult<bool> GetTotalTransacctionProducto()
        {
            return true;
        }
    }
}
