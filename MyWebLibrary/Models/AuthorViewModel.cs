using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWebLibrary.Models
{
    public class AuthorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string AuthorLastName { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string AuthorFirstName { get; set; }

        [Required]
        [Display(Name = "Patronymic")]
        public string AuthorPatronymic { get; set; }

        [Display(Name = "DateOfBirth")]
        [DisplayFormat(DataFormatString = "{0:yyyy'/'MM'/'dd}", ApplyFormatInEditMode = true)]
        public DateTime AuthorDateOfBirth { get; set; }
        
        public virtual IEnumerable<BookViewModel> Books { set; get; }
    }
}