using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Product
{
    public class Picture : AggregateRoot<Pictureid>
    {
        protected Picture() { }
        public Pictureid pictureid {  get; private set; }

        public URL url { get; private set; }

        internal Picture(Pictureid pictureid, URL url) 
        {
            this.pictureid = pictureid;
            this.url = url;
        }

       
    }
}
