using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Infrastructure.Configurations
{
    public class UsersRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GetUserRoles());
        }

        public List<IdentityUserRole<string>> GetUserRoles()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    UserId = "adf55d92-6d2d-459f-a628-e6d14bc3b33e", 
                    RoleId = "c34ebc61-94a5-40c5-a310-798532235d8e"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "26f0964f-eb05-4a1a-b320-87ed04331d3a", 
                    RoleId = "a03f9f62-f106-4b1a-b1f9-eba622db3c92"
                }
            };
        }
    }
}
