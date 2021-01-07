using System;

namespace ABC.Core.Models
{
    public class Unit : ModelBase
    {
        public string ProjectName { get; set; }
        public string CondoUnit { get; set; }
        public decimal LoanAmount { get; set; }
        public int Term { get; set; }
        public DateTime StartOfPayment { get; set; }
        public float InterestRate { get; set; }
    }
}
