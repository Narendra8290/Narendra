using System.ComponentModel.DataAnnotations;

namespace Restaurent_Management.RestaurentManagement.Entities
{
    public class menuItemsEntity
    {
        [Key]
        public Guid itemId { get; set; }
        public string itemName { get; set; }
        public decimal Price { get; set; }
        public string Discription { get; set; }
        public bool availabilityStatus { get; set; }
        public DateTime manufacturedDate { get; set; }
        public DateTime expiryDate { get; set; }

        public virtual ICollection<orderDetailsEntity> orderDetailsEntity { get; set; }
    }
}
