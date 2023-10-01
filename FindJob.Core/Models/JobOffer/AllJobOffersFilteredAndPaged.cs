using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Models.JobOffer
{
    public class AllJobOffersFilteredAndPaged
    {
        public AllJobOffersFilteredAndPaged()
        {
            this.JobOffers = new HashSet<JobOfferViewModel>();
        }
        public int TotalJobOffers { get; set; }

        public IEnumerable<JobOfferViewModel> JobOffers { get; set; }
    }
}
