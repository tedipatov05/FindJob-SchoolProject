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


    }
}
