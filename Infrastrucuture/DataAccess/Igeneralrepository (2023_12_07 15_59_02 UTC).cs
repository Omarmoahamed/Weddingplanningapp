using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.DataAccess
{
     interface IGeneralRepository<T> : IRepoistory where T :  AggregateRoot
    {
      
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity);

        
       
    }
}
