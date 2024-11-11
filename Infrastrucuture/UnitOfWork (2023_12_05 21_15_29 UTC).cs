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
            var ty = typeof(IRepoistory);
            var Normalizeword = typeof(T).Name.ToUpper();

            if (!typeof(IRepoistory).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("the base class must be Irepository");
            }

            if (typeof(T).IsGenericType)
            {
                var arg = typeof(T).GetGenericArguments();
                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(p => ty.IsAssignableFrom(p) && !p.IsInterface).ToList();
                foreach (var t in types)
                {
                    if (Normalizeword.StartsWith('I') && Normalizeword.EndsWith(t.Name.ToUpper()))
                    {
                        var classtype = t.MakeGenericType(arg);
                        RepistoryCache[t.Name] = Activator.CreateInstance(classtype,context);
                        return RepistoryCache[t.Name] as T;
                    }
                }
            }
            if (!RepistoryCache.ContainsKey(ty))
            {
                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(p => ty.IsAssignableFrom(p) && !p.IsInterface).ToList();
                foreach (var t in types)
                {
                    if (Normalizeword.StartsWith('I') && Normalizeword.EndsWith(t.Name.ToUpper()))
                    {

                        RepistoryCache[t.Name] = Activator.CreateInstance(t,context);
                        return RepistoryCache[t.Name] as T;
                    }
                }
            }
            return RepistoryCache[ty]! as T;
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
