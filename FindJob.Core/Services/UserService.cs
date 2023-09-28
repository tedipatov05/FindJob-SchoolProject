using FindJob.Core.Contracts;
using FindJob.Infrastructure.Data.Common;
using FindJob.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            var userExists = await repo.All<User>()
                .AnyAsync(u => u.Email == email && u.IsActive == true);

            return userExists;
        }

        public async Task<bool> ExistsById(string userId)
        {
            var userExists = await repo.All<User>()
                .AnyAsync(u => u.Id == userId);

            return userExists;
        }

        public async Task<bool> ExistsByPhone(string phone)
        {
            var userExists = await repo.All<User>()
                .AnyAsync(u => u.PhoneNumber == phone);

            return userExists;
        }
    }
}
