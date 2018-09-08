using ForumSystem.Data.Common.Models;
using ForumSystem.Data.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Data.Models
{
    public class Tag: AuditInfo,  IDeletableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
