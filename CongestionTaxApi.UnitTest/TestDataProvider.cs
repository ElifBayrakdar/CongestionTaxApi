using System;
using System.Collections;
using System.Collections.Generic;
using CongestionTaxApi.Services;

namespace CongestionTaxApi.UnitTest
{
    public class TimeIsFreeTaxTimeCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Car(), new[] { new DateTime(2013, 01, 14, 21, 00, 00) }, 0 };
            yield return new object[] { new Car(), new[] { new DateTime(2013, 01, 15, 21, 00, 00) }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class NotPassedWithinSixtyMinutesCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Car(), new[]
                {
                    new DateTime(2013, 02, 07, 06, 23, 27),
                    new DateTime(2013, 02, 07, 15, 27, 00)
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PassesWithinSixtyMinutesCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Car(), new[]
                {
                    new DateTime(2013, 02, 08, 06, 20, 00),
                    new DateTime(2013, 02, 08, 06, 27, 27)
                },
                8
            };
            yield return new object[]
            {
                new Car(), new[]
                {
                    new DateTime(2013, 02, 08, 14, 35, 00),
                    new DateTime(2013, 02, 08, 15, 29, 00)
                },
                13
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class
        SomePassesWithinSixtyMinutesAndSomePassesNotWithinSameSixtyMinutesCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Car(), new[]
                {
                    new DateTime(2013, 02, 08, 15, 47, 00),
                    new DateTime(2013, 02, 08, 16, 01, 00),
                    new DateTime(2013, 02, 08, 16, 48, 00)
                },
                36
            };

            yield return new object[]
            {
                new Car(), new[]
                {
                    new DateTime(2013, 02, 08, 16, 48, 00),
                    new DateTime(2013, 02, 08, 17, 49, 00),
                    new DateTime(2013, 02, 08, 18, 29, 00),
                    new DateTime(2013, 02, 08, 18, 35, 00)
                },
                39
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DateIsFreeTaxDateCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Car(), new[] { new DateTime(2013, 03, 02, 21, 00, 00) }, 0 };
            yield return new object[] { new Car(), new[] { new DateTime(2013, 03, 03, 21, 00, 00) }, 0 };
            yield return new object[] { new Car(), new[] { new DateTime(2013, 06, 05, 21, 00, 00) }, 0 };
            yield return new object[] { new Car(), new[] { new DateTime(2013, 07, 03, 21, 00, 00) }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}