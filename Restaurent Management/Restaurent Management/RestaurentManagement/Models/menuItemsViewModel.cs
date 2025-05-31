namespace Restaurent_Management.RestaurentManagement.Models
{
    public class menuItemsViewModel
    {
        public Guid itemId { get; set; }
        public string itemName { get; set; }
        public decimal Price { get; set; }
        public string Discription { get; set; }
        public bool availabilityStatus { get; set; }
        public DateTime manufacturedDate { get; set; }
        public DateTime expiryDate { get; set; }

        public virtual IList<orderDetailsViewModel> orderDetailsViewModel { get; set; }
    }
}
