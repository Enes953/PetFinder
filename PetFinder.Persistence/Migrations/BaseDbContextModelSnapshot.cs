﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetFinder.Persistence.Contexts;

#nullable disable

namespace PetFinder.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaim");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaim");
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("ContactInformations", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageFiles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ImageFile");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Breed");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Color");

                    b.Property<int>("ContactInformationId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("RewardInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RewardInformation");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Species");

                    b.HasKey("Id");

                    b.HasIndex("ContactInformationId");

                    b.HasIndex("LocationId");

                    b.ToTable("Pets", (string)null);
                });

            modelBuilder.Entity("PetPetImageFile", b =>
                {
                    b.Property<int>("PetImageFilesId")
                        .HasColumnType("int");

                    b.Property<int>("PetsId")
                        .HasColumnType("int");

                    b.HasKey("PetImageFilesId", "PetsId");

                    b.HasIndex("PetsId");

                    b.ToTable("PetPetImageFile");
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.PetImageFile", b =>
                {
                    b.HasBaseType("PetFinder.Domain.Entities.ImageFile");

                    b.Property<bool>("Showcase")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("PetImageFile");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.Pet", b =>
                {
                    b.HasOne("PetFinder.Domain.Entities.ContactInformation", "ContactInformation")
                        .WithMany("Pets")
                        .HasForeignKey("ContactInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetFinder.Domain.Entities.Location", "Location")
                        .WithMany("Pets")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInformation");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PetPetImageFile", b =>
                {
                    b.HasOne("PetFinder.Domain.Entities.PetImageFile", null)
                        .WithMany()
                        .HasForeignKey("PetImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetFinder.Domain.Entities.Pet", null)
                        .WithMany()
                        .HasForeignKey("PetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.ContactInformation", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetFinder.Domain.Entities.Location", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}