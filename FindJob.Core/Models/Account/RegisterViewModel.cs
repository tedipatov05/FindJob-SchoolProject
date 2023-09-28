using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindJob.Infrastructure.Constants.ModelValidationConstants.UserConstants;
using static FindJob.Infrastructure.Constants.ModelValidationConstants.ProgrammerConstants;

namespace FindJob.Core.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string PasswordRepeat { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [StringLength(ProgrammerAbilitiesMaxLength, MinimumLength = ProgrammerAbilitiesMinLength)]
        public string? GraduationSchool { get; set; }

        [StringLength(ProgrammerGraduationSchoolMaxLength, MinimumLength = ProgrammerGraduationSchoolMinLength)]
        public string? Abilities { get; set; }

        public IFormFile? ProfilePicture { get; set; }
    }
}
