using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context; 
        private readonly IUserHelper userHelper; 
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {

            this.context = context;
            this.random = new Random();
            this.userHelper = userHelper;
        }

        public UserManager<User> UserManager { get; }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("paulo.carvalho@cinel.pt"); 
            if (user == null) 
            { 
                user = new User 
                {   
                    FirstName = "Paulo", 
                    LastName = "Carvalho", 
                    Email = "paulo.carvalho@cinel.pt", 
                    UserName = "paulo.carvalho@cinel.pt", 
                }; 

                var result = await this.userHelper.AddUserAsync(user, "123456"); 
                if (result != IdentityResult.Success) 
                { 
                    throw new InvalidOperationException("Could not create the user in seeder"); 
                }
            }

            if (!this.context.Products.Any()) 
            { 
                this.AddProduct("First Product", user); 
                this.AddProduct("Second Product", user); 
                this.AddProduct("Third Product", user); 
                await this.context.SaveChangesAsync(); 
            }
        }
 

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product

            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }
}
