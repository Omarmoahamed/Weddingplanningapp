using Domainlayer.DomainInfrastructure;
using Infrastrucuture.WeddingDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.DataAccess
{
    public  class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private WeddingContext _context;

        public GeneralRepository(WeddingContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public async void Add(T entity) 
        {
            await this._dbSet.AddAsync(entity);
        }

        public  void Update(T entity) 
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity) 
        {
            _dbSet.Remove(entity);
        }
    }
}
