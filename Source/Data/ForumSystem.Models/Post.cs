using ForumSystem.Data.Common.Models;
using ForumSystem.Data.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Data.Models
{
    public class Post : AuditInfo, IDeletableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
