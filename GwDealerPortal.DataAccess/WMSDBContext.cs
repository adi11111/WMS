using GwDealerPortal.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;

namespace GwDealerPortal.DataAccess
{
   public class WMSDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

                //var configurationBuilder = new ConfigurationBuilder();
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                //configurationBuilder.AddJsonFile(path, false);

                //// Use configuration as in every web project
                ////var myOptions = configuration.GetSection("MyOptions").Get<MyOptions>();
                //optionsBuilder.UseSqlServer(@"Data Source=GWSQLSERVER\GWSQLSERVER;Initial Catalog=PR_WEMSPORTAL;Persist Security Info=True;User ID=sa;Password=gw5209;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer(DbAccess.GetConfig("WMSDBConnection"));
              //  services.AddDbContext<WMSDBContext>(options => options.UseSqlServer(connection));
            }
        }
        //public static IConfiguration GetConfig(string key)
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(System.AppContext.BaseDirectory).add("appSetings.js", optional: true, reloadOnChange: true); return builder.Build();
        //}
       


public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            return 0;
        }
        public virtual DbSet<Location> Location{ get; set; }
        public virtual DbSet<Policy> Policy{ get; set; }
        public virtual DbSet<Premium> Premium{ get; set; }
        public virtual DbSet<Program> Program{ get; set; }
        //public virtual DbSet<SequenceDetails> SequenceDetails { get; set; }
        //public virtual DbSet<ClaimServiceDetail> ClaimServiceDetail { get; set; }
        public virtual DbSet<ClaimsStatus> ClaimsStatus { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<ProcessClaim> ProcessClaim { get; set; }
        public virtual DbSet<ProcessClaimDetail> ProcessClaimDetail { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Filter> Filter { get; set; }
        public virtual DbSet<FilterType> FilterType { get; set; }
        public virtual DbSet<EventAccess> EventAccess { get; set; }
        public virtual DbSet<Interface> Interface { get; set; }
        // public virtual DbSet<UserDealerBranchFilter> UserDealerBranchFilters { get; set; }
        // public virtual DbSet<UserDealerFilter> UserDealerFilters { get; set; }
        // public virtual DbSet<UserWorkshopFilter> UserWorkshopFilters { get; set; }
        //public virtual DbSet<WorkShop> WorkShops { get; set; }
        public virtual DbSet<WarrantyType> WarrantyType { get; set; }
        public virtual DbSet<BWDealerPolicy> BWDealerPolicy { get; set; }
        public virtual DbSet<ModelYear> ModelYear { get; set; }
        public virtual DbSet<CCRange> CCRange { get; set; }
        public virtual DbSet<DealerBranch> DealerBranch { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<OtherService> OtherService { get; set; }
        public virtual DbSet<PolicyService> PolicyService { get; set; }
        public virtual DbSet<Duration> Duration { get; set; }
        public virtual DbSet<EntryEligibility> EntryEligibility { get; set; }
        public virtual DbSet<ClaimLimit> ClaimLimit { get; set; }
        public virtual DbSet<PolicyStatus> PolicyStatus { get; set; }
    }
}
