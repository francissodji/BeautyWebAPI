using BeautyWebAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Data.Repositories;
using BeautyWebAPI.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BeautyWebAPI.Services.PasswordHasher;
using BeautyWebAPI.Services.TokenGenrator;
using BeautyWebAPI.Services.DatabaseManagement;
using BookingLibrary.Data;
using BookingLibrary.DbAccess;
using ConnectivityLibrary.DbAccess;
using ConnectivityLibrary.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
//using ConnectionLibrary.Data.Context;
//using ConnectionLibrary.Data.Interfaces;
//using ConnectionLibrary.Data.Repositories;

namespace BeautyWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Entity Framework
            services.AddDbContext<BeautyDataContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("BeautyConnection"))); //added 12/29/2021 - Get the Connection

            //services.AddDbContext<ConnectionLibraryContext>(opt => opt.UseSqlServer
            //    (Configuration.GetConnectionString("ConnectionLibraryConnect"))); //added 8/13/2021 - Get the Connection

            //Add external dbContext
            //services.AddDbContext<ConnectionLibraryContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ConnectionLibraryConnect")));


            //Microsoft Authentication
            //For Identity - Added 1/10/2022 - Microsoft Authentication
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<BeautyDataContext>()
            //    .AddDefaultTokenProviders();



            //services.AddSingleton<ConnectionLibraryDataContext>();



            //******************* Adding Authentication- Authorization - Added 1/10/2022
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                //Addin Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };

            });

                //Authorization - 12/2/2022
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Default", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());

                options.AddPolicy("Admin", new AuthorizationPolicyBuilder()
                    .RequireRole("ADMIN", "SUPERADMIN")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());

                options.AddPolicy("Owner", new AuthorizationPolicyBuilder()
                    .RequireRole("OWNER", "ASSOCIATE")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());

            });

                //Associate the "default" authorization to all endpoint - 12/2/2022
                /*
                 * This section is commented out just to allow the testing. - 12/4/2022
                 * It can be uncomment once testing is done
            services.AddMvc()
            .AddMvcOptions(options =>
            {
                // Mark all endpoints with the default policy
                options.Filters.Add(new AuthorizeFilter("Default"));
            });
            */
            //*********** End Authentication - Authorization ***************


            services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>(); //BCrypt Hasher - 1/17/2021
            services.AddSingleton<TokenGenerator>(); //Tokwn Generator - 1/18/2021


            //Add more parameters to the controllers - Added on 12/30/2021
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });//added 12/30/2021


            //***************** Add Session - 12/2/2022
            services.AddMvc()
            .AddSessionStateTempDataProvider();
            services.AddSession();
            //*************************** End Session**********

            //*************************** CORS Service - 1/2/2022 ***************
            services.AddCors(options => 
                {
                    options.AddPolicy(name: "beautypolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
                }
            );
            //***************************** End CORS **************************

            //**************************** File transfer***********************************
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });
            //***************************Continue with file transfer in app****************


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //add 12/30/2021

            services.AddScoped<IBeautyBaseRepository, BeautyBaseRepository>();  //add 12/30/2021


            //************************** Add All the Libraries *************************************
            //Connectivity
            services.AddScoped<IConnectivitySqlDataAccess, ConnectivitySqlDataAccess>();//Added 11/13/2022
            services.AddScoped<IConnectivityData, ConnectivityData>();//Added 11/13/2022

            //Booking
            services.AddScoped<IBookingSqlDataAccess, BookingSqlDataAccess>();//Added 11/13/2022
            services.AddScoped<IBookingData, BookingData>();//Added 11/13/2022

            //services.AddScoped<IBookingData, BookingData>();//Added 11/13/2022
            //************************* End Library ***********************************************

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            DatabaseManagementService.MigrationInitialisation(app); // Add 6/14/2022 - Initilize migration on the DB

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Session 12/2/2022
            app.UseSession();
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });
            //******************

            //************************File transfer ******************************
            app.UseStaticFiles(); //For file upload when using wwwroot folder
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            //*******************************************************************

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("beautypolicy"); //CORS Service - 1/2/2022

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
