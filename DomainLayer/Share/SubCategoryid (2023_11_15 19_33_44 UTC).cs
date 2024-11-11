using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class SubCategoryid : Value<SubCategoryid>
    {
        protected SubCategoryid() { }

        public string value { get; internal set; }

        public SubCategoryid(Guid value) 
        {
            if(value == default) 
            {
                throw new ArgumentNullException("subcategoryid must not be null");
            }
            this.value = value.ToString();
        }

        public static implicit operator string(SubCategoryid subCategoryid) {  return subCategoryid.value; }

        public static implicit operator SubCategoryid(Guid value) { return new SubCategoryid(value); }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
    }
}
