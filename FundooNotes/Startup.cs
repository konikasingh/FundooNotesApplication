using BuisnessLayer.interfaces;
using BuisnessLayer.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Context;
using RepositoryLayer.interfaces;
using RepositoryLayer.Services;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CommonLayer.models;

namespace FundooNotes
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
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserRL, UserRL>();
            

            //var appSettingsSection = Configuration.GetSection("UserLogin");
            //services.Configure<UserLogin>(appSettingsSection);

            ////JWT Authentication
            //var appSettings = appSettingsSection.Get<UserLogin>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Key);

            //services.AddAuthentication(au =>
            //{
            //    au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(jwt =>
            //{

            //    jwt.RequireHttpsMetadata = false;
            //    jwt.SaveToken = true;
            //    jwt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
            //services.AddTransient<IUserRL, UserRL>();
            services.AddDbContext<ucontext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:UserTable"]));
            //services.AddDbContext<ucontext>(opts => opts.UseSqlServer(Configuration["UserLogin:Key"]));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FundooNotes", Version = "v1" });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FundooNotes v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
