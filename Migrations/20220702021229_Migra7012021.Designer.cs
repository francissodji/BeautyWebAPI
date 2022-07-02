﻿// <auto-generated />
using System;
using BeautyWebAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeautyWebAPI.Migrations
{
    [DbContext(typeof(BeautyDataContext))]
    [Migration("20220702021229_Migra7012021")]
    partial class Migra7012021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeautyWebAPI.Authentication.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Appointment", b =>
                {
                    b.Property<int>("IDAppoint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AddTakeOffAppoint")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateAppoint")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("IDBraiderAppoint")
                        .HasColumnType("int");

                    b.Property<int>("IDClientAppoint")
                        .HasColumnType("int");

                    b.Property<int>("IDLenghtAppoint")
                        .HasColumnType("int");

                    b.Property<int>("IDStyleAppoint")
                        .HasColumnType("int");

                    b.Property<int?>("IdBraiderOwner")
                        .HasColumnType("int");

                    b.Property<int>("IdSizeAppoint")
                        .HasColumnType("int");

                    b.Property<int?>("NumberTrack")
                        .HasColumnType("int");

                    b.Property<string>("StateAppoint")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Typeservice")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("clientIDClient")
                        .HasColumnType("int");

                    b.Property<int?>("lengthIdExtrat")
                        .HasColumnType("int");

                    b.Property<int?>("sizeIdSize")
                        .HasColumnType("int");

                    b.Property<int?>("styleIdStyle")
                        .HasColumnType("int");

                    b.HasKey("IDAppoint");

                    b.HasIndex("clientIDClient");

                    b.HasIndex("lengthIdExtrat");

                    b.HasIndex("sizeIdSize");

                    b.HasIndex("styleIdStyle");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Client", b =>
                {
                    b.Property<int>("IDClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CelClient")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("CountyClient")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("DOBClient")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailClient")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FnameClient")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IDUser")
                        .HasColumnType("int");

                    b.Property<string>("LnameClient")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MnameClient")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneClient")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("SexClient")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("StateClient")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("StreetClient")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UserIDUser")
                        .HasColumnType("int");

                    b.Property<string>("ZipCodeClient")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IDClient");

                    b.HasIndex("UserIDUser");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Color", b =>
                {
                    b.Property<int>("IdColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RefColor")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TitleColor")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdColor");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Discount", b =>
                {
                    b.Property<int>("IDDiscount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CostDiscount")
                        .HasColumnType("float");

                    b.Property<float>("RateDiscount")
                        .HasColumnType("real");

                    b.Property<string>("TitleDiscount")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDDiscount");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Extrat", b =>
                {
                    b.Property<int>("IdExtrat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TitleExtrat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdExtrat");

                    b.ToTable("Extrats");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.ExtratStyle", b =>
                {
                    b.Property<int>("IdExtratStyle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CostBusyExtra")
                        .HasColumnType("float");

                    b.Property<double>("CostExtra")
                        .HasColumnType("float");

                    b.Property<double>("CostExtraSize")
                        .HasColumnType("float");

                    b.Property<double>("CostHairDeductExtra")
                        .HasColumnType("float");

                    b.Property<double>("CostTouchUpExtra")
                        .HasColumnType("float");

                    b.Property<int>("IDExtrat")
                        .HasColumnType("int");

                    b.Property<int>("IdSize")
                        .HasColumnType("int");

                    b.Property<int>("IdStyle")
                        .HasColumnType("int");

                    b.HasKey("IdExtratStyle");

                    b.HasIndex("IdSize");

                    b.HasIndex("IdStyle");

                    b.ToTable("ExtratStyles");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.HistoryAppointJob", b =>
                {
                    b.Property<int>("IdJHistoryAppointJob")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AddTakeOffAppoint")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateJobHistory")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDAppoint")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int?>("IdLenght")
                        .HasColumnType("int");

                    b.Property<int?>("IdSize")
                        .HasColumnType("int");

                    b.Property<int?>("IdStyle")
                        .HasColumnType("int");

                    b.Property<int?>("NumberTrack")
                        .HasColumnType("int");

                    b.Property<string>("StateJobHistory")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Typeservice")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("IdJHistoryAppointJob");

                    b.ToTable("HistoryAppointJobs");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Size", b =>
                {
                    b.Property<int>("IdSize")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TitleSize")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSize");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.State", b =>
                {
                    b.Property<string>("CodeState")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("DesignState")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CodeState");

                    b.ToTable("States");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Style", b =>
                {
                    b.Property<int>("IdStyle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("CostStyle")
                        .HasColumnType("float");

                    b.Property<double?>("CostTouchUp")
                        .HasColumnType("float");

                    b.Property<string>("DescriptStyle")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("DesigStyle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("HairProvStyle")
                        .HasColumnType("bit");

                    b.Property<string>("PictureStyle")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double?>("PriceTakeOffHair")
                        .HasColumnType("float");

                    b.HasKey("IdStyle");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Theword", b =>
                {
                    b.Property<int>("IDPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateBeginPw")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEndPw")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDUser")
                        .HasColumnType("int");

                    b.Property<int>("NumConnection")
                        .HasColumnType("int");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("IDPassword");

                    b.ToTable("Thewords");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.User", b =>
                {
                    b.Property<int>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Connectstate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Dateuserexpire")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProfil")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDUser");

                    b.ToTable("Users");
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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Appointment", b =>
                {
                    b.HasOne("BeautyWebAPI.Models.Client", "client")
                        .WithMany("Appointment")
                        .HasForeignKey("clientIDClient");

                    b.HasOne("BeautyWebAPI.Models.Extrat", "length")
                        .WithMany("Appointment")
                        .HasForeignKey("lengthIdExtrat");

                    b.HasOne("BeautyWebAPI.Models.Size", "size")
                        .WithMany("Appointment")
                        .HasForeignKey("sizeIdSize");

                    b.HasOne("BeautyWebAPI.Models.Style", "style")
                        .WithMany("Appointment")
                        .HasForeignKey("styleIdStyle");

                    b.Navigation("client");

                    b.Navigation("length");

                    b.Navigation("size");

                    b.Navigation("style");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Client", b =>
                {
                    b.HasOne("BeautyWebAPI.Models.User", "User")
                        .WithMany("Clients")
                        .HasForeignKey("UserIDUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.ExtratStyle", b =>
                {
                    b.HasOne("BeautyWebAPI.Models.Size", "Size")
                        .WithMany("ExtratStyles")
                        .HasForeignKey("IdSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautyWebAPI.Models.Extrat", "Extrat")
                        .WithMany("ExtratStyles")
                        .HasForeignKey("IdStyle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautyWebAPI.Models.Style", "Style")
                        .WithMany("ExtratStyles")
                        .HasForeignKey("IdStyle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extrat");

                    b.Navigation("Size");

                    b.Navigation("Style");
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
                    b.HasOne("BeautyWebAPI.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeautyWebAPI.Authentication.ApplicationUser", null)
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

                    b.HasOne("BeautyWebAPI.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BeautyWebAPI.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Client", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Extrat", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("ExtratStyles");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Size", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("ExtratStyles");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.Style", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("ExtratStyles");
                });

            modelBuilder.Entity("BeautyWebAPI.Models.User", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
