using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWebLibrary.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        public string BookStyle { get; set; }
        public int BookPagesNumber { get; set; }
    }
}