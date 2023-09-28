using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FindJob.Core.Contracts;
using FindJob.Infrastructure.Data.Common;
using FindJob.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Services
{
    public class ImageService : IImageService
    {
        private Cloudinary cloudinary;
        private readonly IRepository repo;

        public ImageService(Cloudinary cloudinary, IRepository repo)
        {
            this.cloudinary = cloudinary;
            this.repo = repo;
        }

        public async Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user)
        {
            using var stream = imageFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(user.Id, stream),
                Folder = nameFolder
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            user.ProfilePictureUrl = uploadResult.Url.ToString();

            this.repo.Update(user);

            await repo.SaveChangesAsync();

            return user.ProfilePictureUrl;
        }
    }
}
