
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindJob.Infrastructure.Constants.ModelValidationConstants.UserConstants;

namespace FindJob.Infrastructure.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.IsActive = true;
                
        }

        [Comment("Name of the user")]
        [Required]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("User Address")]
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Comment("User city")]
        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [Comment("User country")]
        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Comment("User profile picture url")]
        public string? ProfilePictureUrl { get; set; }

        [Comment("Is active User")]
        public bool IsActive { get; set; }
        
    }
}
