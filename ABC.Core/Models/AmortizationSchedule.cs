using System;

namespace ABC.Core.Models
{
    public class AmortizationSchedule : ModelBase
    {
        public DateTime Date { get; set; }
        public decimal Principal { get; set; }
        public float Interest { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public decimal LoanAmount { get; set; }
        public int NoOfDays { get; set; }
        public BuyerInfo BuyerInfo { get; set; }
    }
}
