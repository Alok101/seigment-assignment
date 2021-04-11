using Data.Contracts.Models;

namespace Business.Contracts.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Discount DiscountRule { get; set; }
    }
}
