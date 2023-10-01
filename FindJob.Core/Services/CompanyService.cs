using FindJob.Core.Contracts;
using FindJob.Core.Models.Programmer;
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

        public async Task AcceptProgrammer(string id, string offerId, string companyId)
        {
            var programmer = await repo.All<Programmer>()
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            var offer = await repo.All<JobOffer>()
                .FirstOrDefaultAsync(o => o.Id == offerId && o.IsActive == true);

            var company = await repo.All<Company>()
                .FirstOrDefaultAsync(f => f.Id == companyId && f.IsActive);



            offer.Candidates.Remove(programmer);
            company.Employees.Add(programmer);
            
            await repo.SaveChangesAsync();

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

        public async Task<List<ProgrammerViewModel>> GetCandidatesToOffer(string offerId)
        {
            var offer = await repo.All<JobOffer>()
                .Include(j => j.Candidates)
                .FirstOrDefaultAsync(j => j.Id == offerId && j.IsActive == true);


            return offer.Candidates
                .Select(c => new ProgrammerViewModel()
                {
                    Id = c.Id,
                    Name = c.User.Name,
                    Address = c.User.Address,
                    Abilities = c.Abilities,
                    Email = c.User.Email,
                    PhoneNumber = c.User.PhoneNumber,
                    GraduationSchool = c.GraduationSchool,
                    ProfilePicture = c.User.ProfilePictureUrl,
                    OfferId = offerId

                })
                .ToList();


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

        public async Task RejectProgrammer(string id, string offerId)
        {
            var programmer = await repo.All<Programmer>()
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            var offer = await repo.All<JobOffer>()
                .FirstOrDefaultAsync(o => o.Id == offerId && o.IsActive == true);

            offer.Candidates.Remove(programmer);

            await repo.SaveChangesAsync();


        }
    }
}
