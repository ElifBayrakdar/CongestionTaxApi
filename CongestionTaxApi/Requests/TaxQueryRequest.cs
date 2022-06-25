using System;

namespace CongestionTaxApi.Requests
{
    public class TaxQueryRequest
    {
        public DateTime[] Dates { get; set; }
        public int VehicleType { get; set; }
    }
}