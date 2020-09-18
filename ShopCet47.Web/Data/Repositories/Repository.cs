using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using ShopCet47.Web.Data.Entities;

namespace ShopCet47.Web.Data.Repositories
{

    // Sem utilização (o primeiro feito)

    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        //Método que vai buscar os produtos todos
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Name);
        }

        //Método que vai buscar um produto pelo ID

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        //Método que adiciona um produto à tabela
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        //Método que atualiza um producto à tabela
        public void UpdateProduct(Product product)
        {
            _context.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        //Método que atualiza a BD
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //Método que verifica se o produto existe
        public bool ProductExists(int Id)
        {
            return _context.Products.Any(p => p.Id == Id);
        }
    }
}
