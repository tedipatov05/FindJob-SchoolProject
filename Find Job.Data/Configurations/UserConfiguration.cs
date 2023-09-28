using FindJob.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        public List<User> CreateUsers()
        {
            List<User> users = new List<User>();
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                UserName = "itjobs",
                Name = "IT Jobs",
                Address = "ул. Александър Батенберг 54",
                City = "Казанлък",
                Country = "България",
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1695190652/Images%20Find%20Job/2606535_5870_n9zxva.jpg",

            };

            user.PasswordHash = passwordHasher.HashPassword(user, "123456");
            users.Add(user);

            var user2 = new User()
            {
                Id = "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                UserName = "ivanivanov",
                Name = "Ivan Ivanov",
                Address = "ул. Стара планина 32",
                City = "Казанлък",
                Country = "България",
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1695190901/Images%20Find%20Job/person_wiajnb.jpg",

            };

            user2.PasswordHash = passwordHasher.HashPassword(user2, "100722");
            users.Add(user2);

            return users;

        }
    }
}
