using System;

namespace ABC.Core.Models
{
    public class AmortizationSchedule : ModelBase
    {
        public Guid PersonUnitId { get; set; }
        public DateTime Date { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal LoanAmount { get; set; }
        public double NoOfDays { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
    }
}
