using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Models.Programmer
{
    public class ProgrammerViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Abilities { get; set; } = null!;

        public string GraduationSchool { get; set; } = null!;

        public string ProfilePicture { get; set; } = null!;

        public string OfferId { get; set; } = null!;
    }
}
