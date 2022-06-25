using System;
using CongestionTaxApi.Services;
using CongestionTaxApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongestionTaxController : ControllerBase
    {
        private readonly ITaxCalculator _taxCalculator;

        public CongestionTaxController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Car car = new Car();
            var date = DateTime.Now.AddYears(-9);
            var dates = new [] { date };
            var tax = _taxCalculator.GetTax(car, dates);
            return Ok(tax);
        }
    }
}