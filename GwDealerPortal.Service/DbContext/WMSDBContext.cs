using GwDealerPortal.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GwDealerPortal.Service
{
   public class WMSDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=GWSQLSERVER\GWSQLSERVER;Initial Catalog=PR_WEMSPORTAL;Persist Security Info=True;User ID=sa;Password=gw5209");
              //  services.AddDbContext<WMSDBContext>(options => options.UseSqlServer(connection));
            }
        }
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

            return base.SaveChanges();
        }
        public virtual DbSet<Location> Locations{ get; set; }
        public virtual DbSet<Policy> Policies{ get; set; }
        public virtual DbSet<Premium> Preimiums{ get; set; }
        public virtual DbSet<Program> Programs{ get; set; }
        //public virtual DbSet<SequenceDetails> SequenceDetails { get; set; }
        public virtual DbSet<ClaimServiceDetail> ClaimServiceDetails { get; set; }
        public virtual DbSet<ClaimsStatus> ClaimsStatus { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<ProcessClaim> ProcessClaims { get; set; }
        public virtual DbSet<ProcessClaimDetail> ProcessClaimDetaisl { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDealerBranchFilter> UserDealerBranchFilters { get; set; }
        public virtual DbSet<UserDealerFilter> UserDealerFilters { get; set; }
        public virtual DbSet<UserWorkshopFilter> UserWorkshopFilters { get; set; }
        public virtual DbSet<WorkShop> WorkShops { get; set; }
        public virtual DbSet<WarrantyType> WarrantyTypes { get; set; }
    }
}
