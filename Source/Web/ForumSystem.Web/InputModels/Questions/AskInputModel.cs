﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.InputModels.Questions
{
    public class AskInputModel
    {
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Content")]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        // TODO: Create custom validation for the tags
        [Required]
        [Display(Name = "Tag")]
        public string Tags { get; set; }
    }
}