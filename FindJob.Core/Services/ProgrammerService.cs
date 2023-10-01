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
    public class ProgrammerService : IProgrammerService
    {
        private readonly IRepository repo;
        public ProgrammerService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task Candidate(string userId, string offerId)
        {
            var programmer = await repo.All<Programmer>()
                .FirstOrDefaultAsync(p => p.UserId == userId && p.IsActive == true);

            var offer = await repo.All<JobOffer>()
                .FirstOrDefaultAsync(j => j.Id == offerId && j.IsActive == true);

            offer.Candidates.Add(programmer);

            await repo.SaveChangesAsync();
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

        public async Task<bool> IsCandidateToOffer(string userId, string offerId)
        {
            var offer = await repo.All<JobOffer>()
                .Include(j => j.Candidates)
                .FirstOrDefaultAsync(j => j.Id == offerId && j.IsActive == true);

            return offer.Candidates.Any(c => c.UserId == userId);
        }

        public async Task<bool> IsExists(string userId)
        {
            var programmer = await repo.All<Programmer>()
                .FirstOrDefaultAsync(p => p.UserId == userId && p.IsActive == true);

            return programmer != null;
        }
    }
}
