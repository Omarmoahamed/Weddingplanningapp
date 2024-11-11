using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domainlayer.DomainInfrastructure;
using Domainlayer.Share;




namespace Domainlayer.Product
{
    public  class Product : AggregateRoot
    {
        protected Product() { }

        private Product (ID id, string name,string description, ProductAttributes productAttributes,string categoryid,string subcategoryid, Type type, double cost) 
        {
            this.Productid = id;

            this.ProductName = name;

            this.ProductDescription = description;
            
            this.ProductAttributes = productAttributes;

            this.Categoryid = categoryid;

           this.type = type;

            this.ProductCost = cost;

        }
        public ID Productid { get; private set; }

        public ProductName ProductName { get; private set; }

        public ProductDescription ProductDescription { get; private set; }
        public ProductAttributes ProductAttributes { get; private set; }
                  
        public ProductCost ProductCost { get; private set; }
        public ID Categoryid { get; private set; }

        public ID SubCategoryid { get; private set; }

        public Type type { get; private set; }

        private readonly List<Picture> PictureList = new List<Picture>();

        public bool Published = false;
        public IReadOnlyCollection<Picture> Pictures => PictureList.AsReadOnly();

        public static Product createproduct(Guid id, string name, string description, string categoryid, string subcategoryid, string Attributevalue,string attributename,IfindProductAttribute findProductAttribute,byte? type,double cost) 
        {
            if(type == null) throw new ArgumentNullException("you didn't specify the type");
            return new Product(id.ToString(), name, description,ProductAttributes.createAttribute(attributename, Attributevalue, findProductAttribute), categoryid, subcategoryid, (Type)Enum.ToObject(typeof(Type), type),cost);
        }

        
        
       
        public void Addpicture(string id , string url,string productid) 
        {
            if(Pictures.Any(p=> p.pictureid == id)) { throw new ArgumentException("cant insert picture with same id"); }
            PictureList.Add(new Picture(new ID(id),URL.createurl(url)));
        }

        public void RequestToPublish() 
        {
            ensurevalidate();
            this.Published = true;
        }

        public enum Type 
        {
            closed = 0,
           
             open =1,

             both =2

            

        }

        


        

    }
}
