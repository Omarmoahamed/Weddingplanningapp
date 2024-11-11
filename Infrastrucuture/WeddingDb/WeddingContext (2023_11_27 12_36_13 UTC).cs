using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.WeddingDb
{
    public class WeddingContext:DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> dboptions):base(dboptions) 
        {

        }
    }
}
