using FindJob.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindJob.Infrastructure.Constants.ModelValidationConstants.JobOfferConstants;

namespace FindJob.Infrastructure.Data.Entities
{
    public class JobOffer
    {
        public JobOffer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Candidates = new HashSet<Programmer>();
            this.IsActive = true;
        }

        [Comment("Id of the offer")]
        [Key]
        public string Id { get; set; } = null!;

        [Comment("Type of job")]
        [MaxLength(TypeOfJobMaxLength)]
        public string TypeOfJob { get; set; } = null!;

        [Comment("Description")]
        [MaxLength(JobDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Searched Abilities")]
        [MaxLength(JobSearchedAblilitiesMaxLength)]
        public string SearchedAbilities { get; set; } = null!;

        public virtual ICollection<Programmer> Candidates { get; set; }

        [Comment("Company Id")]
        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;

        [Comment("Company")]
        public virtual Company Company { get; set; } = null!;

        [Comment("Salary")]
        public decimal Salary { get; set; }

        [Comment("Is Active")]
        public bool IsActive { get; set; } 



    }
}
