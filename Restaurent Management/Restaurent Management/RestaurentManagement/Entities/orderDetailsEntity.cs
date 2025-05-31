using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurent_Management.RestaurentManagement.Entities
{
    public class orderDetailsEntity
    {
        [Key]
        public Guid orderDetailsId { get; set; }
        public Guid menuItemsId { get; set; }
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

        public virtual menuItemsEntity MenuItemsEntity { get; set; }    
    }
}
