namespace Business.Contracts.Models
{
    public class CustomerItemViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }
        public ItemModel ItemDetails { get; set; }
    }

}
