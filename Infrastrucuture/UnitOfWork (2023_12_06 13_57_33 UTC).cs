using Infrastrucuture.DataAccess;
using Infrastrucuture.WeddingDb;
using Microsoft.Extensions.DependencyInjection;
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
        private IServiceProvider serviceProvider;
        public UnitOfWork( WeddingContext context,IServiceProvider serviceProvider) 
        {
            this.context = context;
            this.serviceProvider = serviceProvider;
        }

        public IRepoistory CreateRepository<T>() where T : class,IRepoistory 
        {
            if (RepistoryCache == null)
            {
                RepistoryCache = new Hashtable();
            }
            var type = typeof(IRepoistory);
            var Normalizeword = typeof(T).Name.ToUpper();

            if (!typeof(IRepoistory).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("the base class must be irepository");
            }
            if (!RepistoryCache.ContainsKey(type.Name))
            {
                if (typeof(T).IsGenericType)
                {
                    var arg = typeof(T).GetGenericArguments();
                    var genericType = typeof(T).MakeGenericType(arg);
                    var repo = serviceProvider.GetRequiredService(genericType);
                    RepistoryCache[genericType.Name] = repo;
                    return RepistoryCache[genericType.Name] as IRepoistory;
                }



            }

            return RepistoryCache[type.Name]! as T;
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
