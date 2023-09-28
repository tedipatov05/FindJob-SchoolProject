using FindJob.Core.Contracts;
using FindJob.Infrastructure.Data.Common;
using FindJob.Infrastructure.Data.Entities;
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
    }
}
