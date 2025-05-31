using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurent_Management.RestaurentManagement.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurent_Management.RestaurentManagement.Mappings
{
    public class orderDetailsMapping : IEntityTypeConfiguration<orderDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<orderDetailsEntity> builder)
        {
            builder.ToTable("OrderDetails", "Restaurent");

            builder.Property(x => x.orderDetailsId);
            builder.Property(x => x.menuItemsId);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.subTotal);
            builder.Property(x => x.preparationTime);
            builder.Property(x => x.Ingredients);
            builder.Property(x => x.Calories);
            builder.Property(x => x.ServingSize);
            builder.Property(x => x.ServingType);
            builder.Property(x => x.OrderDate);
            builder.Property(x => x.isVegan);
            builder.Property(x => x.Mobile);
            builder.Property(x => x.paymentMethod);
            builder.Property(x => x.IsPaid);
        }
    }
}
