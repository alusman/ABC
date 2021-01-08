using ABC.Core.Models;
using System;

namespace ABC.Infrastructure.Entities
{
    public class AmortizationSchedule : ModelBase
    {
        public Guid PersonUnitId { get; set; }
        public decimal Principal { get; set; }
        public float Interest { get; set; }
        public decimal LoanAmount { get; set; }
        public int NoOfDays { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
    }
}
