using Domainlayer.Share;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int emailafterindex = email.LastIndexOf('@');
            int charbefore = emailafterindex - 1;
            List<char> emailbefore = email.TakeWhile((c, n) => ++n < emailafterindex).ToList();
            List<char> emailafter = email.Skip(emailafterindex + 1).ToList();
            var after = emailafter[0].ToString();
            var newemailafter = emailafter.Skip(1).ToList();
            var dot = newemailafter.Contains('.') ? true : false;

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("please insert your email");
            }

            if (dot == false || charbefore == '.')
            {
                throw new DomainExceptions.EmailInvalidException();

            }

            if (emailafterindex == -1)
            {
                throw new DomainExceptions.EmailInvalidException();

            }

            foreach (var c in emailbefore)
            {
                if (invalidchars.Contains(c) || checkarabicletter(c))
                {
                    throw new DomainExceptions.EmailInvalidException();
                }
            }

            if (invalidchars.Contains(emailafter[0]))
            {
                throw new DomainExceptions.EmailInvalidException();
            }

            if ((emailafter[0] == '-') || (emailafter[0] == '.'))
            {
                throw new DomainExceptions.EmailInvalidException();
            }

            if ((int.TryParse(after, out int result)))
            {
                throw new DomainExceptions.EmailInvalidException();
            }
            bool flag = false;
            foreach (char c in newemailafter)
            {

                if (c == '.' || int.TryParse(c.ToString(), out int re) || invalidchars.Contains(c) || checkarabicletter(c))
                {
                    flag = true;
                    continue;
                }

                flag = false;
            }

            if (flag)
            {
                throw new DomainExceptions.EmailInvalidException();
            }         
        }



        private static bool checkarabicletter(char charchter)
        {
            if (int.TryParse(charchter.ToString(), out _))
            {
                return false;

            }

            if (!char.IsAscii(charchter))
            {
                return true;
            }

            return false;
        }

    }
}
