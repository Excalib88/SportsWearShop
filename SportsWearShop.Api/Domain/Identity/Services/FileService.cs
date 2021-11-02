using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SportsWearShop.Api.Domain.Identity.Models;

namespace SportsWearShop.Api.Domain.Identity.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Upload(IFormFile formFile)
        {
            if (formFile.Length <= 0) throw new Exception("File invalid");
            
            var filename = $"{Guid.NewGuid()}_{formFile.FileName}";
            var filePath = Path.Combine(_configuration["BasePicturePath"], filename);
            
            await using var fs = File.Create(filePath);
            await formFile.CopyToAsync(fs);

            return filename;
        }

        public async Task<List<string>> BulkUpload(IFormFileCollection formFileCollection)
        {
            var filenames = new List<string>();
            
            foreach (var file in formFileCollection)
            {
                var filename = await Upload(file);
                filenames.Add(filename);
            }

            return filenames;
        }

        public async Task<FileDto> Download(string filename)
        {
            var filePath = Path.Combine(_configuration["BasePicturePath"], filename);
            await using var fs = System.IO.File.OpenRead(filePath);
            await using var ms = new MemoryStream();
            await fs.CopyToAsync(ms);
            var data = ms.ToArray();

            return new FileDto
            {
                Data = data,
                Filename = filename
            };
        }
    }
}