using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyWebLibrary.Models;

namespace MyWebLibrary.Controllers
{
    public class AuthorsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Authors
        public ActionResult Index()
        {
            return View(db.Authors.Include(x => x.Books).ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AuthorLastName,AuthorFirstName,AuthorPatronymic,AuthorDateOfBirth")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            AuthorViewModel authorModel = new AuthorViewModel()
            {
                Id = author.Id,
                AuthorLastName = author.AuthorLastName,
                AuthorFirstName = author.AuthorFirstName,
                AuthorPatronymic = author.AuthorPatronymic,
                AuthorDateOfBirth = author.AuthorDateOfBirth
            };
            if (author.Books != null && author.Books.Count > 0)
            {
                authorModel.Books = author.Books.Select(book => new BookViewModel()
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    BookStyle = book.BookStyle,
                    BookPagesNumber = book.BookPagesNumber
                });
            }
            return View(authorModel);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var authorPost = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == author.Id);
                if (authorPost == null)
                {
                    return HttpNotFound();  
                }

                authorPost.AuthorLastName = author.AuthorLastName;
                authorPost.AuthorFirstName = author.AuthorFirstName;
                authorPost.AuthorPatronymic = author.AuthorPatronymic;
                authorPost.AuthorDateOfBirth = author.AuthorDateOfBirth;
                
                if (author.Books != null)
                {
                    var booksId = db.Books.Where(x => x.AuthorId == author.Id).Select(x => x.Id).ToList();
                    var addBooks = author.Books.Where(x => !booksId.Contains(x.Id)).ToList();

                    addBooks.ForEach(b => db.Books.Add(new Book
                    {
                        AuthorId = author.Id,
                        BookName = b.BookName,
                        BookStyle = b.BookStyle,
                        BookPagesNumber = b.BookPagesNumber
                    }));
                }              
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}