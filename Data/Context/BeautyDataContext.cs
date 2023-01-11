using BeautyWebAPI.Authentication;
using BeautyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Context
{
    public class BeautyDataContext : DbContext
    {
        public BeautyDataContext(DbContextOptions<BeautyDataContext> opt) : base(opt)
        {

        }

        /*
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


            
            
            //************************LIBRARY***************************
            //**********CompanyClient Relation
            //Relation Between Company and CompanyClient
            builder.Entity<CompanyClientLibrary>()
                .HasOne(c => c.Company)
                .WithMany(cc => cc.CompanyClient)
                .HasForeignKey(ci => ci.IdCompany);

            //Relation Between Client and CompanyClient
            builder.Entity<CompanyClientLibrary>()
                .HasOne(cl => cl.Client)
                .WithMany(cc => cc.CompanyClient)
                .HasForeignKey(clI => clI.IdClient);

            //**********CompanyAssociate Relation
            //Relation Between Company and CompanyAssociate
            builder.Entity<CompanyAssociateLibrary>()
                .HasOne(c => c.Company)
                .WithMany(cc => cc.CompanyAssociate)
                .HasForeignKey(ci => ci.IdCompany);

            //Relation Between Associate and CompanyAssociate
            builder.Entity<CompanyAssociateLibrary>()
                .HasOne(a => a.Associate)
                .WithMany(ca => ca.CompanyAssociate)
                .HasForeignKey(ai => ai.IdAssociate);


            //**********CompanyAccount Relation
            //Relation Between Company and CompanyAccount
            builder.Entity<CompanyAccountLibrary>()
                .HasOne(c => c.Company)
                .WithMany(cc => cc.CompanyAccount)
                .HasForeignKey(ci => ci.IdCompany);

            //Relation Between Associate and CompanyAssociate
            builder.Entity<CompanyAccountLibrary>()
                .HasOne(a => a.Account)
                .WithMany(ca => ca.CompanyAccount)
                .HasForeignKey(ai => ai.IdAccount);


            //Relation between Account and Souscription <=> One to many
            builder.Entity<AccountLibrary>()
                .HasMany(a => a.Suscriptions)// An account can have many suscrption
                .WithOne(s => s.Account); //One souscription has only One Account


            //Relation between User and Client <=> One to many
            builder.Entity<UserLibrary>()
                .HasMany(u => u.Clients)// An user can have many client
                .WithOne(cl => cl.User); //One client is refere to only One user


            //Relation between User and Associate <=> One to many
            builder.Entity<UserLibrary>()
                .HasMany(u => u.Associates)// An user can have many associate
                .WithOne(ass => ass.User); //One Associate is refere to only One user

           
        }
        //**********************************************************
        //********************************************************
        

        public DbSet<Length> Extrats { get; set; } //Lenght

        public DbSet<Color> Colors { get; set; } //color

        //public DbSet<Client> Clients { get; set; } //Client

        public DbSet<Discount> Discounts { get; set; } //Discount

        public DbSet<State> States { get; set; } //State

        public DbSet<Style> Styles { get; set; } //Style

        public DbSet<Size> Sizes { get; set; } //Size


        public DbSet<Appointment> Appointments { get; set; } //Appointment

        //public DbSet<AppointWithLibel> AppointWithLibels { get; set; } //Appointment
        public DbSet<HistoryAppointJob> HistoryAppointJobs { get; set; } //JobHistory


        public DbSet<ExtratStyle> ExtratStyles { get; set; } //ExtratStyle



        //*********************************LIBRARY******************
        
        public DbSet<AccountLibrary> Accounts { get; set; } //Account

        public DbSet<AssociateLibrary> Associates { get; set; } //Associate


        public DbSet<ClientLibrary> Clients { get; set; } //Client

        public DbSet<CompanyLibrary> Companies { get; set; } //Company

        public DbSet<CompanyAccountLibrary> CompaniesAccounts { get; set; } //CompanyAccount

        public DbSet<CompanyAssociateLibrary> CompaniesAssociates { get; set; } //CompanyAssociate

        public DbSet<CompanyClientLibrary> CompaniesClients { get; set; } //CompanyClient

        public DbSet<SubscriptionLibrary> Subscriptions { get; set; } //CompanyClient

        public DbSet<UserLibrary> Users { get; set; } //User


       //**************************************************************
       
        */
    }

    
}

