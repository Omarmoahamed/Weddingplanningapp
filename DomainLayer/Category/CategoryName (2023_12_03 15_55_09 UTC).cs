using Domainlayer.DomainInfrastructure;
using Domainlayer.EventCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Category
{
    public class CategoryName:Value<CategoryName>
    {
        protected CategoryName() { }

        public CategoryName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Please enter event category name");
            }

            if (name.Length > 128)
            {
                throw new ArgumentOutOfRangeException("Exceeded the limited number of words");
            }

            this.value = name;
        }
        public string value { get; internal set; }

        public static implicit operator CategoryName(string name) { return new CategoryName(name); }

        public static implicit operator string(CategoryName name) { return name.value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
