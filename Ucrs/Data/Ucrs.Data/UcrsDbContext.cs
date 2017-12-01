namespace Ucrs.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    using Ucrs.Data.Common.Models.Contracts;
    using Ucrs.Data.Models;

    public class UcrsDbContext : IdentityDbContext<User>
    {
        public UcrsDbContext(DbContextOptions<UcrsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // set additional settings if needed
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            var auditInfoEntries = this.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in auditInfoEntries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
