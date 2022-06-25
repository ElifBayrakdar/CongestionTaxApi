using System;
using CongestionTaxApi.Services;
using CongestionTaxApi.Services.Interfaces;
using Xunit;

namespace CongestionTaxApi.UnitTest
{
    public class TaxCalculatorTests
    {
        [Theory]
        [ClassData(typeof(TimeIsFreeTaxTimeCalculatorTestData))]
        public void GetTax_WhenTimeIsFreeTaxTime_ResultShouldBeZero(IVehicle vehicle, DateTime[] dates, int expectedTax)
        {
            //Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            //Act
            var tax = taxCalculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(expectedTax, tax);
        }


        [Theory]
        [ClassData(typeof(NotPassedWithinSixtyMinutesCalculatorTestData))]
        public void GetTax_WhenNotPassedWithinSixtyMinutes_ResultShouldBeSum(IVehicle vehicle, DateTime[] dates)
        {
            //Arrange
            TaxCalculator taxCalculator = new TaxCalculator();
            DateTime nw = DateTime.Now;

            //Act
            var tax = taxCalculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(21, tax);
        }


        [Theory]
        [ClassData(typeof(PassesWithinSixtyMinutesCalculatorTestData))]
        public void GetTax_WhenPassesWithinSixtyMinutes_ResultShouldBeHighestOne(IVehicle vehicle, DateTime[] dates,
            int expectedTax)
        {
            //Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            //Act
            var tax = taxCalculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(expectedTax, tax);
        }


        [Theory]
        [ClassData(typeof(SomePassesWithinSixtyMinutesAndSomePassesNotWithinSameSixtyMinutesCalculatorTestData))]
        public void
            GetTax_WhenSomePassesWithinSixtyMinutesAndSomePassesNotWithinSameSixtyMinutes_ResultShouldBeHighestOnePlusSum(
                IVehicle vehicle, DateTime[] dates,
                int expectedTax)
        {
            //Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            //Act
            var tax = taxCalculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(expectedTax, tax);
        }


        [Theory]
        [ClassData(typeof(DateIsFreeTaxDateCalculatorTestData))]
        public void GetTax_WhenItIsHoliday_ResultShouldBeZero(IVehicle vehicle, DateTime[] dates, int expectedTax)
        {
            //Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            //Act
            var tax = taxCalculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(expectedTax, tax);
        }
    }
}