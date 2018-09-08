using ForumSystem.Data.Repository;
using ForumSystem.Data.Models;

namespace ForumSystem.Data
{
    public interface IForumSystemData
    {
        IForumSystemDbContext Context { get; }

        IDeletableEntityRepository<Post> Posts { get; }

        IDeletableEntityRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
