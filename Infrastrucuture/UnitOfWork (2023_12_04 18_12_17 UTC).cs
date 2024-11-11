using Infrastrucuture.WeddingDb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture
{
    internal class UnitOfWork : IDisposable
    {
        private WeddingContext context ;
        private Hashtable RepistoryCache;

        public UnitOfWork( WeddingContext context) 
        {
            this.context = context;
        }
    }
}
