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
    public class ProgrammerService : IProgrammerService
    {
        private readonly IRepository repo;
        public ProgrammerService(IRepository _repo)
        {
            this.repo = _repo;
        }
        public async Task Create(string userId, string abilities, string graduationSchool)
        {
            var programmer = new Programmer()
            {
                UserId = userId,
                Abilities = abilities,
                GraduationSchool = graduationSchool
            };

            await repo.AddAsync(programmer);
            await repo.SaveChangesAsync();
        }
    }
}
