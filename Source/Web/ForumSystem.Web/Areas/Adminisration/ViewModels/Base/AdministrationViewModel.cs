using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Adminisration.ViewModels.Base
{
    public abstract class AdministrationViewModel
    {
        [Display(Name = "Добавено на")]
        [HiddenInput(DisplayValue = false)]
        DateTime CreatedOn { get; set; }

        [Display(Name = "Променено на")]
        [HiddenInput(DisplayValue = false)]
        DateTime? ModifiedOn { get; set; }
    }
}