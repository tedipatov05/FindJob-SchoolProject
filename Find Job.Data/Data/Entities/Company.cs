
using FindJob.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Infrastructure.Data.Entities
{
    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.Employees = new HashSet<Programmer>();
            this.Offers = new HashSet<JobOffer>();
        }

        [Comment("Primary Key")]
        [Key]
        public string Id { get; set; }

        [Comment("User Id")]
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Comment("User")]
        public virtual User User { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual ICollection<Programmer> Employees { get; set; }

        public virtual ICollection<JobOffer> Offers { get; set; }

    }
}
