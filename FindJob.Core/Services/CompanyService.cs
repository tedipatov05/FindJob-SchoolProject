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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repo;

        public CompanyService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task Create(string userId)
        {
            var company = new Company()
            {
                UserId = userId,
            };

            await repo.AddAsync(company);
            await repo.SaveChangesAsync();
                
        }

        public async Task<string> GetCompanyId(string userId)
        {
            var company = await repo.All<Company>()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return company.Id;

        }

        public async Task<bool> IsCompanyExist(string userId)
        {
            var company = await repo.All<Company>().FirstOrDefaultAsync(company => company.UserId == userId);

            return company != null;
        }
    }
}
