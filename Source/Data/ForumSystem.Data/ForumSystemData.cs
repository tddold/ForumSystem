using System;
using System.Collections.Generic;
using ForumSystem.Data.Common.Models;
using ForumSystem.Data.Contracts;
using ForumSystem.Data.Models;
using ForumSystem.Data.Repository;

namespace ForumSystem.Data
{
    public class ForumSystemData : IForumSystemData
    {
        private readonly IForumSystemDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ForumSystemData(IForumSystemDbContext context)
        {
            this.context = context;
        }
        public IForumSystemDbContext Context => this.context;

        public IRepository<ApplicationUser> Users => this.GetRepository<ApplicationUser>();

        public IDeletableEntityRepository<Post> Posts => this.GetDeletableEntityRepository<Post>();

        public IDeletableEntityRepository<Tag> Tags => this.GetDeletableEntityRepository<Tag>();

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity, IEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
