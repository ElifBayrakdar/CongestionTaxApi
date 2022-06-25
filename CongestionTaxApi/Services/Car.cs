using System;
using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    public class Car : IVehicle
    {
        public String GetVehicleType()
        {
            return "Car";
        }
    }
}