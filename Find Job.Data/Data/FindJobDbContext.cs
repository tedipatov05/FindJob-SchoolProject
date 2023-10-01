using FindJob.Infrastructure.Data.Entities;
using FindJob.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Infrastructure.Data
{
    public class FindJobDbContext : IdentityDbContext<User>
    {
        public FindJobDbContext(DbContextOptions<FindJobDbContext> options)
            :base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<Programmer> Programmers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new UsersRolesConfiguration());
            builder.ApplyConfiguration(new ProgrammerConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());



            base.OnModelCreating(builder);
        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
        }
    } 
}
