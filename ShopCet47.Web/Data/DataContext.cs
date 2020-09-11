using ShopCet47.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShopCet47.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
    }
}
