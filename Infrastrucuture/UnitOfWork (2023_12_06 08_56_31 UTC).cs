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
                    var types1 = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToList();
                    foreach (var t in types1)
                    {
                        if (Normalizeword.StartsWith('I') && Normalizeword.EndsWith(t.Name.ToUpper()))
                        {
                            var classtype = t.MakeGenericType(arg);
                            RepistoryCache[t.Name] = Activator.CreateInstance(classtype);
                            return RepistoryCache[t.Name] as T;
                        }
                    }
                }

                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToList();
                foreach (var t in types)
                {
                    if (Normalizeword.StartsWith('I') && Normalizeword.EndsWith(t.Name.ToUpper()))
                    {

                        RepistoryCache[t.Name] = Activator.CreateInstance(t);
                        return RepistoryCache[t.Name] as T;
                    }
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
