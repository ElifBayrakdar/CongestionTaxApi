using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Motorbike : IVehicle
    {
        public string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}