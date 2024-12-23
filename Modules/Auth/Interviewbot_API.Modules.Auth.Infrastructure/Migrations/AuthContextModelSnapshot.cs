﻿// <auto-generated />
using System;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Interviewbot_API.Modules.Auth.Infrastructure.Migrations
{
    [DbContext(typeof(AuthContext))]
    partial class AuthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Interviewbot_API.Modules.Auth.Domain.Entities.Otp", b =>
                {
                    b.Property<Guid>("OtpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OtpId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code");

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpireAt");

                    b.Property<DateTime>("ExpiryAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit")
                        .HasColumnName("IsUsed");

                    b.Property<int>("OtpType")
                        .HasColumnType("int")
                        .HasColumnName("OtpType");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("OtpId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Otp", (string)null);
                });

            modelBuilder.Entity("Interviewbot_API.Modules.Auth.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TokenId");

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpireAt");

                    b.Property<DateTime>("ExpiryAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit")
                        .HasColumnName("IsUsed");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Secret");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Interviewbot_API.Modules.Auth.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2")
                        .HasColumnName("DoB");

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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Interviewbot_API.Modules.Auth.Domain.Entities.Otp", b =>
                {
                    b.HasOne("Interviewbot_API.Modules.Auth.Domain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Interviewbot_API.Modules.Auth.Domain.Entities.Otp", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Interviewbot_API.Modules.Auth.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Interviewbot_API.Modules.Auth.Domain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Interviewbot_API.Modules.Auth.Domain.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}