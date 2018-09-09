using ForumSystem.Data.Models;
using ForumSystem.Web.Areas.Adminisration.ViewModels.Base;
using ForumSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Adminisration.ViewModels.Posts
{
    public class PostViewModel : AdministrationViewModel, IMapFrom<Post>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Display(Name = "Заглавие")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int AuthorId { get; set; }

        //[Required]
        [Display(Name = "Автор")]
        [StringLength(100, MinimumLength = 3)]
        public virtual ApplicationUser Author { get; set; }

        [Required]
        [Display(Name = "Съдържание")]
        [StringLength(1000, MinimumLength = 2)]
        public string Content { get; set; }

        //public bool IsDeleted { get; set; }

        //public DateTime? DeletedOn { get; set; }
    }
}