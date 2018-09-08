
using ForumSystem.Data.Common.Models;
using ForumSystem.Data.Migrations;
using ForumSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace ForumSystem.Data
{
    public class ForumSystemDbContext : IdentityDbContext<ApplicationUser>, IForumSystemDbContext
    {
        public ForumSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemDbContext, Configuration>());


        }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public DbContext DbContext => this;

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
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

        //IDbSet<T> IForumSystemDbContext.Set<T>()
        //{
        //    throw new NotImplementedException();
        //}

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
