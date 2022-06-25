using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CongestionTaxApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongestionTaxController : ControllerBase
    {
        private readonly ILogger<CongestionTaxController> _logger;

        public CongestionTaxController(ILogger<CongestionTaxController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
    }
}