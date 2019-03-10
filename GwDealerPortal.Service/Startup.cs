using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GwDealerPortal.DataAccess;
using GwDealerPortal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GwDealerPortal.Service.Common;
using Microsoft.AspNetCore.Http;

namespace GwDealerPortal.Service
{
    public class Startup
    {
        public static string claimFormPath = "";
        public static string adminUserIDs = "";
        public static string Email = "";
        public static string Password = "";
        public static string ReportPath = "";
        public static int EmailFilterTypeID = 0;
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            claimFormPath = Configuration["ClaimFormPath"];
            adminUserIDs = Configuration["AdminUserIDs"];
            Email = Configuration["Email"];
            Password = Configuration["Password"];
            ReportPath = Configuration["reportPath"];
            EmailFilterTypeID = Convert.ToInt32(Configuration["EmailFilterTypeID"]);
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices( IServiceCollection services)
        {
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(540);//You can set Time   
            });
            services.AddMvc();
            
            //services.AddDbContext<GwDealerPortal.DataAccess.WMSDBContext>();
            //services.AddTransient( IGenericRepository, GenericRepository);
            services.AddTransient(typeof( DbContext),typeof( WMSDBContext));
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services.AddTransient<Microsoft.AspNetCore.Http.IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<AuthorizationFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCorsMiddleware();
            app.UseCors("AllowAllHeaders");
            app.UseAuthentication();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseCors(options => options.WithOrigins("http://localhost:58256").AllowAnyMethod());
            app.UseSession();
            app.UseMvc();
           
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap()
            //    cfg.CreateMap<UserAccessDetail, UserAccessDetailModel>();
            //    cfg.CreateMap<UserAccessDetailModel, UserAccessDetail>();

            //});
        }
    }
}
