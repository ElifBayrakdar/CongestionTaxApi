using System;
using System.Collections.Generic;

namespace CongestionTaxApi
{
    public class TaxTime
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Tax { get; set; }

        public string City { get; set; }  //on next task, I should move this class to a repository and use this property
    }

    public static class Constants
    {
        public static readonly List<TaxTime> TaxRanges = new()
        {
            new TaxTime()
            {
                StartTime = new TimeSpan(06, 00, 00),
                EndTime = new TimeSpan(06, 29, 59),
                Tax = 8
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(06, 30, 00),
                EndTime = new TimeSpan(06, 59, 59),
                Tax = 13
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(07, 00, 00),
                EndTime = new TimeSpan(07, 59, 59),
                Tax = 18
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(08, 00, 00),
                EndTime = new TimeSpan(08, 29, 59),
                Tax = 13
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(08, 30, 00),
                EndTime = new TimeSpan(14, 59, 59),
                Tax = 8
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(15, 00, 00),
                EndTime = new TimeSpan(15, 29, 59),
                Tax = 13
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(15, 30, 00),
                EndTime = new TimeSpan(16, 59, 59),
                Tax = 18
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(17, 00, 00),
                EndTime = new TimeSpan(17, 59, 59),
                Tax = 13
            },
            new TaxTime()
            {
                StartTime = new TimeSpan(18, 00, 00),
                EndTime = new TimeSpan(18, 29, 59),
                Tax = 8
            }
        };
    }
}