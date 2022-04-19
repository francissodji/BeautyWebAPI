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
                (Configuration.GetConnectionString("BeautyConnection"))); //added 12/29/2021


            //Microsoft Authentication
            //For Identity - Added 1/10/2022 - Microsoft Authentication
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BeautyDataContext>()
                .AddDefaultTokenProviders();


            //Adding Authentication - Added 1/10/2022
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
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Security"]))
                };

            });

            //***********End Microsoft Authentication***************

            
            services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>(); //BCrypt Hasher - 1/17/2021
            services.AddSingleton<AccessTokenGenerator>(); //Tokwn Generator - 1/18/2021

            //Add more parameters to the controllers - Added on 12/30/2021
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });//added 12/30/2021




            //CORS Service - 1/2/2022
            services.AddCors(options => 
                {
                    options.AddPolicy(name: "beautypolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5000",
                                              "http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                      });

                    /*
                    //options.AddDefaultPolicy(
                    //builder => builder.WithOrigins("http://localhost:5000"));
                    options.AddPolicy("beautypolicy", builder =>
                        builder.WithOrigins("http://localhost:5000", "http://localhost:4200"));
                    */
                }
            );


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //add 12/30/2021

            services.AddScoped<IBeautyBaseRepository, BeautyBaseRepository>();  //add 12/30/2021
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
