using System.Net;
using CongestionTaxApi.Factory;
using CongestionTaxApi.Requests;
using CongestionTaxApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CongestionTaxApi.Controllers
{
    [ApiController]
    [Route("congestion-tax")]
    public class CongestionTaxController : ControllerBase
    {
        private readonly ITaxCalculator _taxCalculator;

        public CongestionTaxController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, "returns bad request when request is not valid")]
        [SwaggerResponse((int) HttpStatusCode.OK, "returns congestion tax with given dates and vehicle type")]
        public IActionResult Get([FromQuery] TaxQueryRequest taxQueryRequest)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            var vehicle = vehicleFactory.ProduceVehicle(taxQueryRequest.VehicleType);
            var tax = _taxCalculator.GetTax(vehicle, taxQueryRequest.Dates);
            return Ok(tax);
        }
    }
}