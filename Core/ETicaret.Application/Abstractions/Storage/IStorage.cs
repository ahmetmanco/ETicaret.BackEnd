using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace _02_ETicaret.Application_.Abstractions.Storage
{
    public interface IStorage
    {
       // Task<string?> UploadAsync( IFormFile file);

        #region Table Per Hierarchy
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFile file);//IFormFileCollection file

        #endregion
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
