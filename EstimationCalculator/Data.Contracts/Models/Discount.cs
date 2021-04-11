namespace Data.Contracts.Models
{
    public class Discount
    {
        public bool ItemVisible { get; set; }
        public bool Applicable { get; set; }
        public int PricePercentage { get; set; }
    }
}
