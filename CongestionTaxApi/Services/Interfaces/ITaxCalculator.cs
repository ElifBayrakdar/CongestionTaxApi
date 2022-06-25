using System;

namespace CongestionTaxApi.Services.Interfaces
{
    public interface ITaxCalculator
    {
        int GetTax(IVehicle vehicle, DateTime[] dates);
    }
}