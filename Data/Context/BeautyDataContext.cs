using BeautyWebAPI.Authentication;
using BeautyWebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Context
{
    //public class BeautyDataContext : DbContext
    public class BeautyDataContext : IdentityDbContext<ApplicationUser>
    {
        public BeautyDataContext(DbContextOptions<BeautyDataContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //**********ExtratStyle Relation
            //Relation Between Style and ExtratStyle
            builder.Entity<ExtratStyle>()
                .HasOne(s => s.Style)
                .WithMany(ex => ex.ExtratStyles)
                .HasForeignKey(si => si.IdStyle);

            //Relation Between Extrat and ExtratStyle
            builder.Entity<ExtratStyle>()
                .HasOne(e => e.Extrat)
                .WithMany(ex => ex.ExtratStyles)
                .HasForeignKey(ei => ei.IdStyle);

            //Relation Between Size and ExtratStyle
            builder.Entity<ExtratStyle>()
                .HasOne(s => s.Size)
                .WithMany(ex => ex.ExtratStyles)
                .HasForeignKey(si => si.IdSize);
            //***************************************************


        }

        public DbSet<Extrat> Extrats { get; set; } //Lenght

        public DbSet<Color> Colors { get; set; } //color

        public DbSet<Client> Clients { get; set; } //Client

        public DbSet<Discount> Discounts { get; set; } //Discount

        public DbSet<State> States { get; set; } //State

        public DbSet<Style> Styles { get; set; } //Style

        public DbSet<Size> Sizes { get; set; } //Size

        public DbSet<User> Users { get; set; } //User

        public DbSet<Theword> Thewords { get; set; } //Theword

        public DbSet<Appointment> Appointments { get; set; } //Appointment

        //public DbSet<AppointWithLibel> AppointWithLibels { get; set; } //Appointment
        public DbSet<HistoryAppointJob> HistoryAppointJobs { get; set; } //JobHistory


        //JOIN TABLE  

        public DbSet<ExtratStyle> ExtratStyles { get; set; } //ExtratStyle

    }
}
