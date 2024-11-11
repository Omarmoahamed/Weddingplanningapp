using Domainlayer.Product;
using Infrastrucuture.WeddingDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Repositories
{
      public class ProductRepository : IProductRepository
    {
        private WeddingContext _context;

        public ProductRepository(WeddingContext context) 
        {
            _context = context;
        }

        public async Task<Product> GetbyId(string id) 
        {
            var product = await _context.products.Include(p=>p.Pictures).Where(p=>p.Productid==id).SingleAsync();
            return product!;
        }

        public async Task<Product> GetbyIdNoInclude(string id) 
        {
            var product = await _context.products.FindAsync(id);

            return product!;
        }

        public async void AddProduct(Product product)
        {
           await _context.products.AddAsync(product);
        }

        public void update(Product product) 
        {
            _context.products.Update(product);
        }

        public void delete(Product product) 
        {
            _context.products.Remove(product);
        }
    }
}
