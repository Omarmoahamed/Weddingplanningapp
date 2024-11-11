using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.DomainServices
{
    public class Phonecompanycheck: Iphonecompanycheck
    {
        private string[] PhoneNumbersStart = new string[] 
        {
            "011",
            "012",
            "010",
            "015"
        };

        public bool Phonecombanynumberscheck(string value) 
        {
            if(PhoneNumbersStart.Contains(value)) 
            {
                return true;

            }

            return false;
        }
    }
}
