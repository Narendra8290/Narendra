using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurent_Management.RestaurentManagement.Entities;

namespace Restaurent_Management.RestaurentManagement.Mappings
{
    public class menuItemsMapping : IEntityTypeConfiguration<menuItemsEntity>
    {
        public void Configure(EntityTypeBuilder<menuItemsEntity> builder)
        {
            builder.ToTable("MenuItems", "Restaurent");
            builder.Property(x => x.itemId);
            builder.Property(x => x.itemName);
            builder.Property(x => x.Price);
            builder.Property(x => x.Discription);
            builder.Property(x => x.availabilityStatus);
            builder.Property(x => x.manufacturedDate);
            builder.Property(x => x.expiryDate);

            builder.HasMany(x => x.orderDetailsEntity).WithOne(x => x.MenuItemsEntity).HasForeignKey(x => x.menuItemsId);

        }
    }
}
