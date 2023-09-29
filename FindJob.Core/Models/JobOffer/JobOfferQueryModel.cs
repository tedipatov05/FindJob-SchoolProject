using FindJob.Core.Models.JobOffer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Models.JobOffer
{
    public class JobOfferQueryModel
    {
        public JobOfferQueryModel()
        {
            this.CurrentPage = 1;
            this.JobOffersPerPage = 3;

            this.TypeOfJobs = new HashSet<string>();
            this.JobOffers = new List<JobOfferViewModel>();
        }
        public string? TypeOfJob { get; set; }

        public string? SearchString { get; set; }

        public JobOfferSorting JobOffersSorting { get; set; }

        public int CurrentPage { get; set; }

        public int JobOffersPerPage { get; set; }

        public int TotalOffers { get; set; }

        public IEnumerable<string> TypeOfJobs { get; set; }

        public IEnumerable<JobOfferViewModel> JobOffers {  get; set; }


    }
}
