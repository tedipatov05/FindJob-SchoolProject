﻿// <auto-generated />
using System;
using FindJob.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Find_Job.Data.Migrations
{
    [DbContext(typeof(FindJobDbContext))]
    [Migration("20231001191022_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Primary Key");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = "7a78216d-46b0-45ac-8318-0e0f6be26530",
                            IsActive = true,
                            UserId = "adf55d92-6d2d-459f-a628-e6d14bc3b33e"
                        });
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.JobOffer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Id of the offer");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Company Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is Active");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Salary");

                    b.Property<string>("SearchedAbilities")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Searched Abilities");

                    b.Property<string>("TypeOfJob")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Type of job");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.Programmer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Programer Id");

                    b.Property<string>("Abilities")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Abilities");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Company Id");

                    b.Property<string>("GraduationSchool")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Graduation School");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobOfferId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("UserId");

                    b.ToTable("Programmers");

                    b.HasData(
                        new
                        {
                            Id = "a2063af2-2e07-42af-8121-9dc6ec8e5ad6",
                            Abilities = "C#, ASP.NET, Entity Framework, JavaScript, Pyton, PHP",
                            GraduationSchool = "ППМГ Никола Обрешков",
                            IsActive = true,
                            UserId = "26f0964f-eb05-4a1a-b320-87ed04331d3a"
                        });
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("User Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(169)
                        .HasColumnType("nvarchar(169)")
                        .HasComment("User city");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("User country");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is active User");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the user");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User profile picture url");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                            AccessFailedCount = 0,
                            Address = "ул. Александър Батенберг 54",
                            City = "Казанлък",
                            ConcurrencyStamp = "2d2550e4-cc24-4905-b070-25c74d9a7a25",
                            Country = "България",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            Name = "IT Jobs",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ0HVDU9xvl3v5Afj3+8N2qcajU515MfVHTtdiArihK+lDDWAIWzJDvT+iEnBnZmlA==",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1695190652/Images%20Find%20Job/2606535_5870_n9zxva.jpg",
                            SecurityStamp = "590d9fb0-a2f1-4fea-8378-9e8e9ed44944",
                            TwoFactorEnabled = false,
                            UserName = "itjobs"
                        },
                        new
                        {
                            Id = "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                            AccessFailedCount = 0,
                            Address = "ул. Стара планина 32",
                            City = "Казанлък",
                            ConcurrencyStamp = "d9920d50-64c2-43bd-b6c3-9ce269664b06",
                            Country = "България",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            Name = "Ivan Ivanov",
                            PasswordHash = "AQAAAAEAACcQAAAAEO6hq8Ig0nIxjeIgROdbCZ0/AMtMn09BgxMh9N72PIt8QKfMBIYtg44ezfdIGA257g==",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1695190901/Images%20Find%20Job/person_wiajnb.jpg",
                            SecurityStamp = "85a3f023-6d72-4fcc-ace1-02244c9f8d3e",
                            TwoFactorEnabled = false,
                            UserName = "ivanivanov"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                            ConcurrencyStamp = "3748e9be-485b-42f5-b0f7-eefab46b34ca",
                            Name = "Programmer",
                            NormalizedName = "PROGRAMMER"
                        },
                        new
                        {
                            Id = "c34ebc61-94a5-40c5-a310-798532235d8e",
                            ConcurrencyStamp = "966670df-7b96-45b1-9c3a-26752d24f397",
                            Name = "Company",
                            NormalizedName = "COMPANY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                            RoleId = "c34ebc61-94a5-40c5-a310-798532235d8e"
                        },
                        new
                        {
                            UserId = "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                            RoleId = "a03f9f62-f106-4b1a-b1f9-eba622db3c92"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.Company", b =>
                {
                    b.HasOne("FindJob.Infrastructure.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.JobOffer", b =>
                {
                    b.HasOne("FindJob.Infrastructure.Data.Entities.Company", "Company")
                        .WithMany("Offers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.Programmer", b =>
                {
                    b.HasOne("FindJob.Infrastructure.Data.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.HasOne("FindJob.Infrastructure.Data.Entities.JobOffer", null)
                        .WithMany("Candidates")
                        .HasForeignKey("JobOfferId");

                    b.HasOne("FindJob.Infrastructure.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FindJob.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FindJob.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindJob.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FindJob.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.Company", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("FindJob.Infrastructure.Data.Entities.JobOffer", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}