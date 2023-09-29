using FindJob.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Infrastructure.Configurations
{
    public class ProgrammerConfiguration : IEntityTypeConfiguration<Programmer>
    {
        public void Configure(EntityTypeBuilder<Programmer> builder)
        {
            builder.HasData(new Programmer()
            {
                Id = "a2063af2-2e07-42af-8121-9dc6ec8e5ad6",
                UserId = "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                Abilities = string.Join( ", ", new List<string>() { "C#", "ASP.NET", "Entity Framework", "JavaScript", "Pyton", "PHP" }),
                CompanyId = null, 
                GraduationSchool = "ППМГ Никола Обрешков", 

            });

        }
    }
}
