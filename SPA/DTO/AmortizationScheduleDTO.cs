using System;

namespace SPA.DTO
{
    public class AmortizationScheduleDTO
    {
        public Guid Id { get; set; } 
        public Guid PersonUnitId { get; set; } // BuyerInfoId
        public string Date { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal LoanAmount { get; set; }
        public double NoOfDays { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
    }
}
