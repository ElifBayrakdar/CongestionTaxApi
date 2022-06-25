using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Diplomat : IVehicle
    {
        public string GetVehicleType()
        {
            return "Diplomat";
        }
    }
}