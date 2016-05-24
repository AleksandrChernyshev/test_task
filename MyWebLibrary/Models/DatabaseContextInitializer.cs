using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyWebLibrary.Models
{
    public class DatabaseContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Authors.Add(new Author()
            {
                Id = 1,
                AuthorLastName = "Nikolaev",
                AuthorPatronymic = "Nikolaevich",
                AuthorFirstName = "Alexandr",
                AuthorDateOfBirth = DateTime.Parse("1982/03/24"),
                Books = new List<Book> { new Book { Id = 1, BookName = "QQQ", BookPagesNumber = 100, BookStyle = "Style1", AuthorId = 1 } }
            });
            context.Authors.Add(new Author()
            {
                Id = 2, AuthorLastName = "Ivanov", AuthorPatronymic = "Ivanovich", AuthorFirstName = "Ivan", AuthorDateOfBirth = DateTime.Parse("1980/01/01")
            });
            base.Seed(context);
        }
    }
}