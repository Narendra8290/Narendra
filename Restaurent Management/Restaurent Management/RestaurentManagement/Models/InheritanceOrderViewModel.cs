namespace Restaurent_Management.RestaurentManagement.Models
{
    public class InheritanceOrderViewModel : menuItemsViewModel
    {
        public string paymentMethod { get; set; }
        public bool IsPaid { get; set; }
    }
}
