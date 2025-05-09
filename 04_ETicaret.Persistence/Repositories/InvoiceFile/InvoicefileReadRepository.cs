using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application_.Repositories.File;
using _02_ETicaret.Application_.Repositories.InvoiceFile;
using _04_ETicaret.Persistence_.Context;

namespace _04_ETicaret.Persistence_.Repositories.InvoiceFile
{
    public class InvoicefileReadRepository : ReadRepository<_01_ETicaret.Domain_.Entities.InvoiceFile>, IinvoiceReadRepository
    {
        public InvoicefileReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
