using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWebLibrary.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        public string BookStyle { get; set; }
        public int BookPagesNumber { get; set; }
        //Внешний ключ 
        //Для удобства формы редактирования книг
        public int AuthorId { get; set; }
        //навигационное свойство
        //Ссылка на экземпляр класса Author
        public Author Author { get; set; }
    }
}