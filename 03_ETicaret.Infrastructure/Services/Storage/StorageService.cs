using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application_.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace _03_ETicaret.Infrastructure_.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public async Task DeleteAsync(string pathOrContainerName, string fileName) => await _storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName) => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName) => _storage.HasFile(pathOrContainerName,fileName);

        //public Task<string?> UploadAsync(IFormFile file) => _storage.UploadAsync(file);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFile files) => _storage.UploadAsync( pathOrContainerName, files);

    }
}
