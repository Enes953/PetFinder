using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Pet> pets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<PetImageFile> PetImageFiles { get; set; }
        

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("PetFinderConnectionString")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                p.HasMany(p => p.UserOperationClaims);
                p.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pets");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Species).HasColumnName("Species");
                entity.Property(e => e.Breed).HasColumnName("Breed");
                entity.Property(e => e.Color).HasColumnName("Color");
                entity.Property(e => e.Gender).HasColumnName("Gender");
                entity.Property(e => e.BirthDate).HasColumnName("BirthDate");
                entity.Property(e => e.RewardInformation).HasColumnName("RewardInformation");

                // İlişkiler
                entity.HasOne(e => e.Location)
                      .WithMany(l => l.Pets)
                      .HasForeignKey(e => e.LocationId);

                entity.HasOne(e => e.ContactInformation)
                      .WithMany(c => c.Pets)
                      .HasForeignKey(e => e.ContactInformationId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.City).HasColumnName("City");
                entity.Property(e => e.Country).HasColumnName("Country");
            });

            modelBuilder.Entity<ContactInformation>(entity =>
            {
                entity.ToTable("ContactInformations");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.FirstName).HasColumnName("FirstName");
                entity.Property(e => e.LastName).HasColumnName("LastName");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
            });
        }


    }

}
