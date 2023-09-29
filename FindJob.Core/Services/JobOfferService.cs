using FindJob.Core.Contracts;
using FindJob.Core.Models.JobOffer;
using FindJob.Infrastructure.Data.Common;
using FindJob.Infrastructure.Data.Entities;
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
    }
}
