using System;
using System.Linq;
using CongestionTaxApi.Enums;
using CongestionTaxApi.Services.Interfaces;

namespace CongestionTaxApi.Services
{
    /// <summary>
    /// Tax calculator for vehicles
    /// </summary>
    public class TaxCalculator : ITaxCalculator
    {
        public int GetTax(IVehicle vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int tempFee = GetTollFee(intervalStart, vehicle);
            
            int totalFee = 0;
            
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);

                TimeSpan ts = date - intervalStart;

                if (ts.TotalMinutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }

            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }

        private bool IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null) return false;
            String vehicleType = vehicle.GetVehicleType();
            return vehicleType.Equals(Vehicles.Motorbike.ToString()) ||
                   vehicleType.Equals(Vehicles.Tractor.ToString()) ||
                   vehicleType.Equals(Vehicles.Emergency.ToString()) ||
                   vehicleType.Equals(Vehicles.Diplomat.ToString()) ||
                   vehicleType.Equals(Vehicles.Foreign.ToString()) ||
                   vehicleType.Equals(Vehicles.Military.ToString());
        }

        public int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            var result =
                Constants.TaxRanges.FirstOrDefault(x => x.StartTime <= date.TimeOfDay && x.EndTime >= date.TimeOfDay);

            if (result != null) return result.Tax;

            return 0;
        }

        private Boolean IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}