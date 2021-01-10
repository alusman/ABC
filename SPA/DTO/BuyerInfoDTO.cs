using System;

namespace SPA.DTO
{
    public class BuyerInfoDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid UnitId { get; set; }
        public string ProjectName { get; set; }
        public string CondoUnit { get; set; }
        public decimal LoanAmount { get; set; }
        public int Term { get; set; }
        public string StartOfPayment { get; set; }
        public float InterestRate { get; set; }
    }
}
