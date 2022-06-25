using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Military : IVehicle
    {
        public string GetVehicleType()
        {
            return "Military";
        }
    }
}