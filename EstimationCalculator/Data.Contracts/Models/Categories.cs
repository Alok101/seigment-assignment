namespace Data.Contracts.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryType { get; set; }
        public Discount Discounts { get; set; }
    }
}
