using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWebLibrary.Models
{
    public class Author
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

        //коллекция книг, реализация связи один ко многим
        public ICollection<Book> Books { get; set; }
    }
}