using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Models.JobOffer
{
    public class JobOfferViewModel
    {
        public string TypeOfJob { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string SearchedAbilities { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public decimal Salary { get; set; }
    }
}
