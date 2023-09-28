using FindJob.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindJob.Infrastructure.Constants.ModelValidationConstants.ProgrammerConstants;

namespace FindJob.Infrastructure.Data.Entities
{
    public class Programmer 
    {
        public Programmer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
           
        }

        [Comment("Programer Id")]
        [Key]
        [Required]
        public string Id { get; set; } = null!;

        [Comment("User Id")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Comment("User")]
        public User User { get; set; } = null!;

        [Comment("Company Id")]
        [ForeignKey(nameof(Company))]
        public string? CompanyId { get; set; }

        [Comment("Comment")]
        public Company? Company { get; set; }


        [Comment("Abilities")]
        [Required]
        [MaxLength(ProgrammerAbilitiesMaxLength)]
        public string Abilities { get; set; } = null!;


        [Comment("Graduation School")]
        [Required]
        [MaxLength(ProgrammerGraduationSchoolMaxLength)]
        public string GraduationSchool { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}
