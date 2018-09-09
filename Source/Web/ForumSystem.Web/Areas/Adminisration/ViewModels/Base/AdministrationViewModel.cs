using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Adminisration.ViewModels.Base
{
    public abstract class AdministrationViewModel
    {
        [Display(Name = "Добавено на")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Променено на")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? ModifiedOn { get; set; }
    }
}