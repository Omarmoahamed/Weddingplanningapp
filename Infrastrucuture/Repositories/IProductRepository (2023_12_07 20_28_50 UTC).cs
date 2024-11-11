using Domainlayer.Event;
using Domainlayer.Product;
using Infrastrucuture.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Repositories
{
     public interface IProductRepository : IRepoistory
    {
        Task<Product> GetbyId(string id);
        Task<Product> GetbyIdNoInclude(string id);

        void AddProduct(Product product);

        void update(Product product);

        void delete(Product product);






    }
}
