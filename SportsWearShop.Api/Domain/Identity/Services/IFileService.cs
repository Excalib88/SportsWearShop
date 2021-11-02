using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SportsWearShop.Api.Domain.Identity.Models;

namespace SportsWearShop.Api.Domain.Identity.Services
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile formFile);
        Task<List<string>> BulkUpload(IFormFileCollection formFileCollection);
        Task<FileDto> Download(string filename);
    }
}