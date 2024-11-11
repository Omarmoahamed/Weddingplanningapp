using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.DomainServices
{
    public class CheckCustomerEmail : IcheckCustomerEmail
    {
        private char[] invalidchars = new char[]
        {
                    '_',
                    '=',
                    '(',
                    ')',
                    '@',
                    '#',
                    '$',
                    '%',
                    '*',
                    '^',
                    '+',
                    '|',
                    '/'
        };

        public void CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("please insert your email");
            }


            int emailafterindex = email.LastIndexOf('@');


            if (emailafterindex == -1)
            {
                throw new ArgumentException("please enter valid email address");

            }

            List<char> emailbefore = email.TakeWhile((c,n)=> ++n < emailafterindex).ToList();
            foreach(var c in emailbefore) 
            {
                if (invalidchars.Contains(c)) 
                {
                    throw new ArgumentException("please enter valid email address");
                }
            }
            List<char> emailafter = (List<char>)email.Skip(emailafterindex + 1).ToList();

            var after = emailafter[0].ToString();
            if (invalidchars.Contains(emailafter[0]))
            {
                throw new ArgumentException("please enter a valid email address");
            }

            if ((emailafter[0] == '-') || (emailafter[0] == '.'))
            {
                throw new ArgumentException("please enter a valid email address");
            }

            if ((int.TryParse(after, out int result)))
            {
                throw new ArgumentException("please enter a valid email address");
            }

            var newemailafter = emailafter.Skip(1).ToList();
            bool flag = false;
            foreach (char c in newemailafter)
            {

                if (c == '.' || int.TryParse(c.ToString(), out int re) || invalidchars.Contains(c))
                {
                    flag = true;
                    continue;
                }

                flag = false;
            }

            if (flag)
            {
                throw new ArgumentException("please enter a valid email address");
            }
        }
        
    }
}
