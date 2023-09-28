using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Infrastructure.Constants
{
    public abstract class ModelValidationConstants
    {
        public static class UserConstants
        {
            public const int UserNameMaxLength = 50;
            public const int UserNameMinLength = 2;

            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 5;

            public const int PasswordMinLength = 3;
            public const int PasswordMaxLength = 16;

            public const int CityMaxLength = 169;
            public const int CityMinLength = 1;

            public const int CountryMaxLength = 56;
            public const int CountryMinLength = 4;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 10;

        }

        public static class ProgrammerConstants
        {
            public const int ProgrammerAbilitiesMaxLength = 150;
            public const int ProgrammerAbilitiesMinLength = 7;

            public const int ProgrammerGraduationSchoolMaxLength = 100;
            public const int ProgrammerGraduationSchoolMinLength = 10;
        }

        public static class JobOfferConstants
        {
            public const int TypeOfJobMaxLength = 70;

            public const int JobDescriptionMaxLength = 500;

            public const int JobSearchedAblilitiesMaxLength = 150;


        }
    }
}
