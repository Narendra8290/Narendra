namespace Restaurent_Management.RestaurentManagement.Models
{
    public class getTotalDataViewModel
    {
        public Guid itemId { get; set; }
        public string itemName { get; set; }
        public decimal Price { get; set; }
        public string Discription { get; set; }
        public bool availabilityStatus { get; set; }
        public DateTime manufacturedDate { get; set; }
        public DateTime expiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal subTotal { get; set; }
        public int preparationTime { get; set; }
        public string Ingredients { get; set; }
        public int Calories { get; set; }
        public string ServingSize { get; set; }
        public string ServingType { get; set; }
        public DateTime OrderDate { get; set; }
        public bool isVegan { get; set; }
        public long Mobile { get; set; }
        public string paymentMethod { get; set; }
        public bool IsPaid { get; set; }
    }
}
