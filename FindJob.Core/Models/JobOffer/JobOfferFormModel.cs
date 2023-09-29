using FindJob.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindJob.Infrastructure.Constants.ModelValidationConstants.JobOfferConstants;

namespace FindJob.Core.Models.JobOffer
{
    public class JobOfferFormModel
    {
        
        [MaxLength(TypeOfJobMaxLength)]
        public string TypeOfJob { get; set; } = null!;
      
        [MaxLength(JobDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(JobSearchedAblilitiesMaxLength)]
        public string SearchedAbilities { get; set; } = null!;
        public decimal Salary { get; set; }


    }
}
