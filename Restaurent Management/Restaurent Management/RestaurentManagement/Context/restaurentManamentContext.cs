using Microsoft.EntityFrameworkCore;
using Restaurent_Management.RestaurentManagement.Entities;
using Restaurent_Management.RestaurentManagement.Mappings;

namespace Restaurent_Management.RestaurentManagement.Context
{
    public class restaurentManamentContext : DbContext
    {
        public restaurentManamentContext(DbContextOptions<restaurentManamentContext> options) : base(options) { }

        public DbSet<menuItemsEntity> menuItems { get; set; }   
        public DbSet<orderDetailsEntity> orderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new menuItemsMapping());
            modelBuilder.ApplyConfiguration(new orderDetailsMapping());

        }
    }
}
