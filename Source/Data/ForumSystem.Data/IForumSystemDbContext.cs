using ForumSystem.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ForumSystem.Data
{
    public interface IForumSystemDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Tag> Tags { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
