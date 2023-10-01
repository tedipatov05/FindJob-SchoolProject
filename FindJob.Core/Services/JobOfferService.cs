using FindJob.Core.Contracts;
using FindJob.Core.Models.JobOffer;
using FindJob.Core.Models.JobOffer.Enums;
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

        public async Task DeleteJobOffer(string jobOfferId)
        {
            var jobOffer = await repo.All<JobOffer>()
                .FirstOrDefaultAsync(j => j.Id == jobOfferId && j.IsActive == true);

            jobOffer.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task EditJobOffer(string jobOfferId, JobOfferFormModel jobOfferModel)
        {
            var jobOffer = await repo.All<JobOffer>()
                .Where(j => j.IsActive == true)
                .FirstOrDefaultAsync(j => j.Id == jobOfferId);

            jobOffer.TypeOfJob = jobOfferModel.TypeOfJob;
            jobOffer.Description = jobOfferModel.Description;
            jobOffer.SearchedAbilities = jobOfferModel.SearchedAbilities;
            jobOffer.Salary = jobOfferModel.Salary;


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

        public async Task<AllJobOffersFilteredAndPaged> GetAllJobOffersFilteredAndPaged(JobOfferQueryModel model)
        {
            IQueryable<JobOffer> offersQuery = repo.All<JobOffer>()
                .Where(jo => jo.IsActive);


            if (!string.IsNullOrEmpty(model.TypeOfJob))
            {
                offersQuery = offersQuery
                    .Where(jo => jo.TypeOfJob == model.TypeOfJob);
            }

            if(!string.IsNullOrEmpty(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";

                offersQuery = offersQuery
                    .Where(jo => EF.Functions.Like(jo.TypeOfJob, wildCard) ||
                                 EF.Functions.Like(jo.Description, wildCard) ||
                                 EF.Functions.Like(jo.SearchedAbilities, wildCard)
                          );
            }

            offersQuery = model.JobOffersSorting switch
            {
                JobOfferSorting.TypeOfJob => offersQuery.OrderBy(o => o.TypeOfJob),
                JobOfferSorting.Salary => offersQuery.OrderBy(o => o.Salary),
                JobOfferSorting.CompanyNameAscending => offersQuery.OrderBy(o => o.Company.User.Name),
                JobOfferSorting.CompanyNameDescending => offersQuery.OrderByDescending(o => o.Company.User.Name)
            };


            IEnumerable<JobOfferViewModel> jobOffersViewModels = await offersQuery
                .Where(o => o.IsActive).
                Skip((model.CurrentPage - 1) * model.JobOffersPerPage)
                .Take(model.JobOffersPerPage)
                .Select(o => new JobOfferViewModel()
                {
                    Id = o.Id,
                    TypeOfJob = o.TypeOfJob,
                    Description = o.Description,
                    SearchedAbilities = o.SearchedAbilities,
                    CompanyName = o.Company.User.Name,
                    Salary = o.Salary
                })
                .ToListAsync();

            int totalOffers = offersQuery.Count();

            return new AllJobOffersFilteredAndPaged()
            {
                TotalJobOffers = totalOffers,
                JobOffers = jobOffersViewModels,
            };
        }

        public async Task<List<string>> GetAllTypeOfJobs()
        {
            return await repo.All<JobOffer>()
                .Select(j => j.TypeOfJob)
                .Distinct()
                .ToListAsync();
        }

        public async Task<AllJobOffersFilteredAndPaged> GetCompanyJobOffersFilteredAndPaged(JobOfferQueryModel model, string id)
        {
            IQueryable<JobOffer> offersQuery = repo.All<JobOffer>()
                .Where(jo => jo.IsActive);


            if (!string.IsNullOrEmpty(model.TypeOfJob))
            {
                offersQuery = offersQuery
                    .Where(jo => jo.TypeOfJob == model.TypeOfJob);
            }

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";

                offersQuery = offersQuery
                    .Where(jo => EF.Functions.Like(jo.TypeOfJob, wildCard) ||
                                 EF.Functions.Like(jo.Description, wildCard) ||
                                 EF.Functions.Like(jo.SearchedAbilities, wildCard)
                          );
            }

            offersQuery = model.JobOffersSorting switch
            {
                JobOfferSorting.TypeOfJob => offersQuery.OrderBy(o => o.TypeOfJob),
                JobOfferSorting.Salary => offersQuery.OrderBy(o => o.Salary),
                JobOfferSorting.CompanyNameAscending => offersQuery.OrderBy(o => o.Company.User.Name),
                JobOfferSorting.CompanyNameDescending => offersQuery.OrderByDescending(o => o.Company.User.Name)
            };


            IEnumerable<JobOfferViewModel> jobOffersViewModels = await offersQuery
                .Where(o => o.IsActive && o.CompanyId == id)
                .Skip((model.CurrentPage - 1) * model.JobOffersPerPage)
                .Take(model.JobOffersPerPage)
                .Select(o => new JobOfferViewModel()
                {
                    Id = o.Id,
                    TypeOfJob = o.TypeOfJob,
                    Description = o.Description,
                    SearchedAbilities = o.SearchedAbilities,
                    CompanyName = o.Company.User.Name,
                    Salary = o.Salary
                })
                .ToListAsync();

            int totalOffers = offersQuery.Count();

            return new AllJobOffersFilteredAndPaged()
            {
                TotalJobOffers = totalOffers,
                JobOffers = jobOffersViewModels,
            };
        }

        public async Task<JobOfferFormModel> GetJobOfferById(string jobOfferId)
        {
            var jobOffer = await repo.All<JobOffer>()
                .Where(j => j.Id == jobOfferId && j.IsActive == true)
                .Select(j => new JobOfferFormModel()
                {
                    TypeOfJob = j.TypeOfJob,
                    Description = j.Description,
                    Salary = j.Salary,
                    SearchedAbilities = j.SearchedAbilities,

                })
                .FirstOrDefaultAsync();

            return jobOffer!;
               
        }

        public async Task<bool> IsCompanyOwnerToOffer(string companyId, string offerId)
        {
            var offer = await repo.All<JobOffer>()
                .FirstOrDefaultAsync(j => j.Id == offerId && j.IsActive == true);

            return offer!.CompanyId == companyId;
        }

        public async Task<bool> IsJobOfferExists(string jobOfferId)
        {
            var jobOffer = await repo.All<JobOffer>()
                .FirstOrDefaultAsync(j => j.Id == jobOfferId && j.IsActive == true);

            return jobOffer != null;
        }
    }
}
