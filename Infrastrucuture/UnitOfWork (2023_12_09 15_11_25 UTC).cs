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
            var Keyword = typeof(T).Name;

            if (!typeof(IRepoistory).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("the base class must be irepository");
            }
            if (!RepistoryCache.ContainsKey(Keyword))
            {
                if (typeof(T).IsGenericType)
                {
                    var arg = typeof(T).GetGenericArguments();
                    var genericType = typeof(T).MakeGenericType(arg);
                    var service = serviceProvider.GetRequiredService(genericType);
                    var grepo = Activator.CreateInstance(service.GetType(),context);
                    RepistoryCache[genericType.Name] = grepo;
                    return RepistoryCache[genericType.Name] as IRepoistory;
                }
                var serv = serviceProvider.GetRequiredService(typeof(T));
                var repo = Activator.CreateInstance(serv.GetType(),context);
                var reponame = typeof(T).Name;
                RepistoryCache.Add(reponame, repo);
                return RepistoryCache[reponame] as IRepoistory;
            }
            return RepistoryCache[Keyword] as T;
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
