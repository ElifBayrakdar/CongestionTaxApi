using CongestionTaxApi.Enums;
using CongestionTaxApi.Factory.Interfaces;
using CongestionTaxApi.Services;
using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Factory
{
    /// <summary>
    /// Vehicle factory to create vehicle object with given vehicle type
    /// </summary>
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle ProduceVehicle(int vehicleType)
        {
            IVehicle vehicle = null;
            
            switch (vehicleType)
            {
                case (int)Vehicles.Motorbike:
                    vehicle = new Motorbike();
                    break;
                case (int)Vehicles.Tractor:
                    vehicle = new Tractor();
                    break;
                case (int)Vehicles.Emergency:
                    vehicle = new Emergency();
                    break;
                case (int)Vehicles.Diplomat:
                    vehicle = new Diplomat();
                    break;
                case (int)Vehicles.Foreign:
                    vehicle = new Foreign();
                    break;
                case (int)Vehicles.Military:
                    vehicle = new Military();
                    break;
                case (int)Vehicles.Car:
                    vehicle = new Car();
                    break;
            }

            return vehicle;
        }
    }
}