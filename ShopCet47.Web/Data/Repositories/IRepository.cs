using ShopCet47.Web.Data.Entities;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data.Repositories
{
    public interface IRepository
    {
        void AddProduct(Product product);

        Product GetProduct(int id);

        System.Collections.Generic.IEnumerable<Product> GetProducts();

        bool ProductExists(int id);

        void RemoveProduct(Product product);

        Task<bool> SaveAllAsync();

        void UpdateProduct(Product product);
    }
}