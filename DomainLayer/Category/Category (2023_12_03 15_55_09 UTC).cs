using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Category
{
    public class Category:AggregateRoot<Categoryid>
    {
        public Categoryid Id { get; set; }

        public CategoryName Name { get; set; }

        public Category(string id, string name) 
        {
            Id = id;
            Name = name;
        }

    }
}
