using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Foreign : IVehicle
    {
        public string GetVehicleType()
        {
            return "Foreign";
        }
    }
}