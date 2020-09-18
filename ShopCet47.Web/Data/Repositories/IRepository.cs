using ShopCet47.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data.Repositories
{

    // Sem utilização (o primeiro feito)
    public interface IRepository
    {
        void AddProduct(Product product);


        Product GetProduct(int id);


        IEnumerable<Product> GetProducts();


        bool ProductExists(int id);


        void RemoveProduct(Product product);


        Task<bool> SaveAllAsync();


        void UpdateProduct(Product product);
    }
}