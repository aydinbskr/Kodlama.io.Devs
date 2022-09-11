using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Social> Socials { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });
            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.FirstName).HasColumnName("FirstName");
                a.Property(a => a.LastName).HasColumnName("LastName");
                a.Property(a => a.Email).HasColumnName("Email");
                a.Property(a => a.PasswordHash).HasColumnName("PasswordHash");
                a.Property(a => a.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(a => a.Status).HasColumnName("Status").HasDefaultValue(true);
                a.Property(a => a.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(a => a.UserOperationClaims);
                a.HasMany(a => a.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(p => p.OperationClaim);
                p.HasOne(p => p.User);
            });

         
            modelBuilder.Entity<Social>(a =>
            {
                a.ToTable("Socials").HasKey(t => t.Id);
                a.Property(t => t.Id).HasColumnName("Id");
                a.Property(t => t.UserId).HasColumnName("UserId");
                a.Property(t => t.SocialUrl).HasColumnName("SocialUrl");
                a.HasOne(t => t.User);
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1, 1, "ASP.NET"), new(2, 1, "WPF"),
                new(3, 2, "Spring"), new(4, 2, "JSP") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            OperationClaim[] operationClaimSeeds = { new(1, "Admin"), new(2, "User") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeeds);


        }
    }
}
