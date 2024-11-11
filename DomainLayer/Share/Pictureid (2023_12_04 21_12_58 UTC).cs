using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class Pictureid : Value<Pictureid>
    {
        protected Pictureid() { }

        public string value { get; internal set; }


        public Pictureid(string value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "productid cannot be null");
            }
            this.value = value.ToString();
        }


        public static implicit operator string(Pictureid pictureid)
        {
            return pictureid.value;
        }

        public static implicit operator Pictureid(string value) { return new Pictureid(value); }

        public static Pictureid FromId(string value) 
        {
            return new Pictureid(value);
        }
        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }

    }
}
