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
        private readonly DataContext _context; 
        private readonly IUserHelper _userHelper; 
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {

            _context = context;
            _random = new Random();
            _userHelper = userHelper;
        }

        public UserManager<User> UserManager { get; }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("rafael.santos@cinel.pt"); 
            if (user == null) 
            { 
                user = new User 
                {   
                    FirstName = "Rafael", 
                    LastName = "Santos", 
                    Email = "rafael.santos@cinel.pt", 
                    UserName = "rafael.santos@cinel.pt", 
                }; 

                var result = await _userHelper.AddUserAsync(user, "123456"); 
                if (result != IdentityResult.Success) 
                { 
                    throw new InvalidOperationException("Could not create the user in seeder"); 
                }
            }

            if (!_context.Products.Any()) 
            { 
                this.AddProduct("First Product", user); 
                this.AddProduct("Second Product", user); 
                this.AddProduct("Third Product", user); 
                await _context.SaveChangesAsync(); 
            }
        }
 

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product

            {
                Name = name,
                Price = _random.Next(100),
                IsAvailabe = true,
                Stock = _random.Next(100)
            });
        }
    }
}
