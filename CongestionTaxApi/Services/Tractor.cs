using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Tractor : IVehicle
    {
        public string GetVehicleType()
        {
            return "Tractor";
        }
    }
}