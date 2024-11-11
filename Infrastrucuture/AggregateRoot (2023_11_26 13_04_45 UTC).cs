using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrtucture
{
    public abstract class AggregateRoot<Tid> where Tid : Value<Tid>
    {

        private readonly List<Domainevent> _events;

        public Tid id { get; protected set; }
        public AggregateRoot() {
        
            _events = new List<Domainevent>();
        
        }

        public  void ensurevalidate()
        {
            var binding = BindingFlags.Instance | BindingFlags.Public;
            var properties = this.GetType().GetProperties(binding);
            foreach (var property in properties)
            {
                if (property.GetValue(this) == default)
                {
                    throw new NullReferenceException("The value cant be nullable");
                }
                if(property.PropertyType.IsGenericType) 
                {
                   if((int)property.PropertyType.GetProperties()[0].GetValue(property.GetValue(this))! < 0) 
                    {
                        throw new ArgumentException($"The{nameof(property)} cannot be empty ");
                    }
                }
                if (property.Name.Contains("price") || property.Name.Contains("number") || property.Name.Contains("cost"))
                {
                    var type = property.PropertyType;
                    var propertyvalues = type.GetProperties();
                    foreach (var propertyvalue in propertyvalues)
                    {
                        if (propertyvalue.Name.Contains("Amount") || propertyvalue.Name.Contains("cost") )
                        {
                            if ((double)propertyvalue.GetValue(property.GetValue(this))! < 0) 
                            {
                                throw new ArgumentException("value cannot be ngative");
                            }
                        }
                    }
                }

            }
        }
        public void RaiseEvent(Domainevent @event) 
        {
            _events.Add(@event);
        }

        public void clearevents() 
        {
            _events.Clear();
        }

        

    }
}
