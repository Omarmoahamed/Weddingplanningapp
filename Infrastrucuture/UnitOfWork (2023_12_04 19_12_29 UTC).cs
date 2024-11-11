using Infrastrucuture.DataAccess;
using Infrastrucuture.WeddingDb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture
{
    internal class UnitOfWork :IUnitOfWork, IDisposable
    {
        private WeddingContext context ;
        private Hashtable RepistoryCache;

        public UnitOfWork( WeddingContext context) 
        {
            this.context = context;
        }

        public IRepoistory CreateRepository<T>() where T : class,IRepoistory 
        {
            if(RepistoryCache == null) 
            {
                RepistoryCache = new Hashtable();
            }

            var repostype = typeof(T);
            if(!repostype.IsAssignableTo(typeof(IRepoistory))) 
            {
                throw new ArgumentException("The type must be assignable to IRepository");
            }
            if(!RepistoryCache.ContainsKey(repostype)) 
            {
                var repo = Activator.CreateInstance(repostype);
                RepistoryCache.Add(repostype, repo);
            }
            return RepistoryCache[typeof(T)] as IRepoistory;
            
        }

        public async Task save() 
        {
            await context.SaveChangesAsync();
        }
        public void Dispose() 
        {
            context.Dispose();
        }
    }
}
