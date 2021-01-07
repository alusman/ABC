namespace ABC.Core.Models
{
    public class BuyerInfo : ModelBase
    {
        public Person buyer { get; set; }
        public Unit unit { get; set; }
    }
}
