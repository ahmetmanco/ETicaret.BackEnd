using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application_.Repositories.InvoiceFile;
using _04_ETicaret.Persistence_.Context;

namespace _04_ETicaret.Persistence_.Repositories.InvoiceFile
{
    public class InvoicefileWriteRepository : WriteRepository<_01_ETicaret.Domain_.Entities.InvoiceFile>, IinvoiceWriteRepository
    {
        public InvoicefileWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
