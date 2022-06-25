using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Factory.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle ProduceVehicle(int vehicleType);
    }
}