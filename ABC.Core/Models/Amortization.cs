using System.Collections.Generic;

namespace ABC.Core.Models
{
    public class Amortization 
    {
        public BuyerInfo BuyerInfo { get; set; }
        public List<AmortizationSchedule> AmortizationSchedule { get; set; }
    }
}
