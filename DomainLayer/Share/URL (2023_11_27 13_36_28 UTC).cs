using Domainlayer.DomainInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class URL : Value<URL>
    {
        protected URL() { }

        public string value { get; internal set; }

        public URL(string value) { this.value = value; }

        public override IEnumerable<object> Getmembers()
        {
            yield return value;
        }
        public static URL createurl(string url)
        {
            checkvalidate(url);
            return new URL(url);

        }
        public static void checkvalidate(string url)
        {
            if (url == null || !url.StartsWith("https://"))
            {
                throw new ArgumentException("Image url is not correct");
            }
        }

        public static implicit operator string(URL url) { return url.value; }

        public static implicit operator URL(string value) { return new URL(value); }

    }
}
