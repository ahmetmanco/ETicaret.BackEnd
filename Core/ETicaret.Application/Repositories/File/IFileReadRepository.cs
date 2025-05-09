using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain_.Entities;
using _02_ETicaret.Application.Repositories;

namespace _02_ETicaret.Application_.Repositories.File
{
    public interface IFileReadRepository : IReadRepository<_01_ETicaret.Domain_.Entities.File>
    {
    }
}
