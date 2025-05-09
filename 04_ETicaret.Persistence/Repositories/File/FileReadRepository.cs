using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application.Repositories;
using _02_ETicaret.Application_.Repositories.File;
using _04_ETicaret.Persistence_.Context;

namespace _04_ETicaret.Persistence_.Repositories.File
{
    public class FileReadRepository : ReadRepository<_01_ETicaret.Domain_.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
