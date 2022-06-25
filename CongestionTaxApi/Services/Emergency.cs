using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Emergency : IVehicle
    {
        public string GetVehicleType()
        {
            return "Emergency";
        }
    }
}