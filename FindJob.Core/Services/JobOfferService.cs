using FindJob.Core.Contracts;
using FindJob.Core.Models.JobOffer;
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
    public class JobOfferService : IJobOfferService
    {
        private readonly IRepository repo;

        public JobOfferService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddJobOffer(string companyId, JobOfferFormModel jobOfferModel)
        {
            var jobOffer = new JobOffer()
            {
                TypeOfJob = jobOfferModel.TypeOfJob,
                Description = jobOfferModel.Description,
                CompanyId = companyId,
                SearchedAbilities = jobOfferModel.SearchedAbilities,
                Salary = jobOfferModel.Salary,
            };

            

            await repo.AddAsync(jobOffer);
            await repo.SaveChangesAsync();
        }

        public async Task<List<JobOfferViewModel>> GetAllJobOffers()
        {
            var jobOffers = await repo.All<JobOffer>()
                .Select(o => new JobOfferViewModel()
                {
                    TypeOfJob = o.TypeOfJob,
                    Description = o.Description,
                    SearchedAbilities = o.SearchedAbilities,
                    Salary = o.Salary,
                    CompanyName = o.Company.User.Name
                })
                .ToListAsync();

            return jobOffers;
        }
    }
}
