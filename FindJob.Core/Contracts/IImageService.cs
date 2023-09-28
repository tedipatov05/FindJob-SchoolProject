using FindJob.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Contracts
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user);

        
    }
}
