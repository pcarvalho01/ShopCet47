using ShopCet47.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopCet47.Web.Data
{
    public class DataContext : IdentityDbContext<User>

    {
        public DbSet<Product> Products { get; set; }


        public DbSet<Order> Orders { get; set; }


        public DbSet<OrderDetail> OrderDetails { get; set; }


        public DbSet<OrderDetailTemp> OrderDetailTemps { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBbuilder)
        {
            modelBbuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            //Habilitar a cascade delete rule
            var cascadeFKS = modelBbuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach(var fk in cascadeFKS)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBbuilder);
        }
    }
    
}
