using System;

namespace ABC.Core.Models
{
    public class BuyerInfo : ModelBase
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid UnitId { get; set; }
        public string ProjectName { get; set; }
        public string CondoUnit { get; set; }
        public decimal LoanAmount { get; set; }
        public int Term { get; set; }
        public DateTime StartOfPayment { get; set; }
        public float InterestRate { get; set; }
    }
}
