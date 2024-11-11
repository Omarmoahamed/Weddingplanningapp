using Domainlayer.DomainInfrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class Categoryid : Value<Categoryid>
    {
        protected Categoryid() { }

        public string value { get; internal set; }
        public Categoryid(string value) 
        {
            if(value == default) 
            {
                throw new ArgumentNullException("Categoryid cannot be null");
            }
            this.value = value;
        }

        public static implicit operator string(Categoryid categoryid)
        {
            return categoryid.value;
        }

        public static implicit operator Categoryid(string value) {return new  Categoryid(value); }
        public override IEnumerable<object> Getmembers() 
        {
            yield return value;
        }

        
        
    }
}
