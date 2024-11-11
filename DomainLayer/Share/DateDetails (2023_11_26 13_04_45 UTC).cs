using Infrastrtucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Share
{
    public class DateDetails : Value<DateDetails>
    {
        protected DateDetails() { }

        public DateDetails(DateTime date)
        {
             Date = date;
            
        }

        public DateTime Date { get; internal set; }

        public static DateDetails CreateDate(DateTime date) 
        {
            Check(date);
            int remainig_days = date.Day - DateTime.Now.Day;
            return new DateDetails(date);
        }

        public static void Check(DateTime date) 
        {
            if(DateTime.Compare(date, DateTime.Now) <= 0 || date == default) 
            {
                throw new ArgumentException("please enter valid date");
            }
        }

        public static implicit operator DateTime(DateDetails date) { return date.Date; }
        public static implicit operator DateDetails(DateTime date) { return new DateDetails(date); }
        public override IEnumerable<object> Getmembers()
        {
            yield return Date;
            
        }
    }
}
