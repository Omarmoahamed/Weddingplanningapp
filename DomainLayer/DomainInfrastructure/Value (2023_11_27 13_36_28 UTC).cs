using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.DomainInfrastructure
{
    public abstract class Value<T> where T : Value<T>
    {

        public abstract  IEnumerable<object> Getmembers();
        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals (this, obj)) return true;
            var other = (Value<T>)obj;
            return Getmembers().SequenceEqual(other.Getmembers());
        }

        public static bool operator ==(Value<T> valueleft, Value<T> valueright) 
        {
            return valueleft.Equals(valueright);
        }

        public static bool operator !=(Value<T> valueleft, Value<T> valueright) 
        {
            return !(valueleft == valueright);
        }

        public override int GetHashCode()
        {
            return Getmembers()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
