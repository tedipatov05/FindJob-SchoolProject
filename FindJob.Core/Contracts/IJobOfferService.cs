using FindJob.Core.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Contracts
{
    public interface IJobOfferService
    {
        Task AddJobOffer(string companyId, JobOfferFormModel jobOffer);

        Task<List<JobOfferViewModel>> GetAllJobOffers();

        Task<AllJobOffersFilteredAndPaged> GetAllJobOffersFilteredAndPaged(JobOfferQueryModel model);

        Task<AllJobOffersFilteredAndPaged> GetCompanyJobOffersFilteredAndPaged(JobOfferQueryModel model, string id);

        Task<List<string>> GetAllTypeOfJobs();

        Task<bool> IsCompanyOwnerToOffer(string companyId, string offerId);

        Task<bool> IsJobOfferExists(string jobOfferId);

        Task<JobOfferFormModel> GetJobOfferById(string jobOfferId);

        Task EditJobOffer(string jobOfferId, JobOfferFormModel jobOfferModel);

        Task DeleteJobOffer(string jobOfferId);


    }
}
