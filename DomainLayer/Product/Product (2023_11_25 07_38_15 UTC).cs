using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domainlayer.Share;
using Infrastrtucture;



namespace Domainlayer.Product
{
    public  class Product : AggregateRoot<Productid>
    {
        protected Product() { }

        private Product (Productid id, string name,string description, ProductAttributes productAttributes,string categoryid,string subcategoryid, Type type) 
        {
            this.Productid = id;

            this.ProductName = name;

            this.ProductDescription = description;
            
            this.ProductAttributes = productAttributes;

            this.Categoryid = categoryid;

           this.type = type;

        }
        public Productid Productid { get; private set; }

        public ProductName ProductName { get; private set; }

        public ProductDescription ProductDescription { get; private set; }
        public ProductAttributes ProductAttributes { get; private set; }
        
        public Categoryid Categoryid { get; private set; }

        public SubCategoryid SubCategoryid { get; private set; }

        public Type type { get; private set; }

        private readonly List<Picture> PictureList = new List<Picture>();

        public bool Published = false;
        public IReadOnlyCollection<Picture> Pictures => PictureList.AsReadOnly();

        public static Product createproduct(Guid id, string name, string description, string categoryid, string subcategoryid, string Attributevalue,string attributename,IfindProductAttribute findProductAttribute,byte? type) 
        {
            if(type == null) throw new ArgumentNullException("you didn't specify the type");
            return new Product(id.ToString(), name, description,ProductAttributes.createAttribute(attributename, Attributevalue, findProductAttribute), categoryid, subcategoryid, (Type)Enum.ToObject(typeof(Type), type));
        }

        
        
       
        public void Addpicture(Guid id , string url) 
        {
            if(Pictures.Any(p=> p.pictureid == id.ToString())) { throw new ArgumentException("cant insert picture with same id"); }
            PictureList.Add(new Picture(new Pictureid(id.ToString()),URL.createurl(url)));
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
