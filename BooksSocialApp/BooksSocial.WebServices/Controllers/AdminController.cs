namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using BooksSocial.WebServices.Models.Admin;

    [RoutePrefix("api/admin")]
    public class AdminController : UserController
    {
        public AdminController()
        {
        }

        public AdminController(IBooksSocialData data)
            : base(data)
        {
        }

        [Route("Authors")]
        public IHttpActionResult AddAuthor([FromBody]AdminAuthorBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Inavlid model state.");
            }
            var author = new Author();
            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.Picture = model.Picture;
            author.Website = model.Website;
            author.Information = model.Information;
            Data.Author.Add(author);
            Data.SaveChanges();
            return Ok("The author is added successfully.");
        }

        [Route("Authors/{id}")]
        public IHttpActionResult DeleteAuthor(Guid id)
        {
            var author = Data.Author.All().FirstOrDefault(a => a.Id == id);
            Data.Author.Delete(author);
            Data.SaveChanges();
            return Ok("The author is deleted successfully.");
        }

        [HttpPut]
        [Route("Authors/{id}")]
        public IHttpActionResult UpdateAuthor(Guid id, [FromBody]AdminAuthorBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Inavlid model state.");
            }
            var author = Data.Author.Find(id);
            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.Picture = model.Picture;
            author.Website = model.Website;
            author.Information = model.Information;
            Data.Author.Update(author);
            Data.SaveChanges();
            return Ok("The author is updated successfully.");
        }

        [Route("Genres")]
        public IHttpActionResult AddGenre([FromBody]AdminGenreBindingModel model)
        {
            var genre = new Genre();
            genre.Name = model.Name;
            Data.Genre.Add(genre);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [Route("Genres/{id}")]
        public IHttpActionResult deleteGenre(Guid id)
        {
            var genre = Data.Genre.Find(id);
            if (genre == null)
            {
                return Ok("Genre not found");
            }
            Data.Genre.Delete(genre);
            Data.SaveChanges();
            return Ok("Genre deleted successfully.");
        }

        [HttpPut]
        [Route("Genres/{id}")]
        public IHttpActionResult updateGenre(Guid id, [FromBody]AdminGenreBindingModel model)
        {
            var genre = Data.Genre.Find(id);
            if (genre == null)
            {
                return Ok("Genre not found");
            }
            genre.Name = model.Name;
            Data.Genre.Update(genre);
            Data.SaveChanges();
            return Ok("Genre updated successfully.");
        }

        [Route("Books")]
        public IHttpActionResult AddBook([FromBody]AdminBookBindingModel model)
        {
            var book = new Book();
            book.Title = model.Title;
            foreach (var authorId in model.Authors)
            {
                var author = Data.Author.Find(authorId);
                book.Authors.Add(author);
            }
            if (model.Characters != null)
            {
                book.Characters = model.Characters;
            }
            if (model.CoverImage != null)
            {
                book.CoverImage = model.CoverImage;
            }
            if (model.Isbn != null)
            {
                book.Isbn = model.Isbn;
            }
            if (model.Resume != null)
            {
                book.Resume = model.Resume;
            }
            if (model.Genres != null)
            {
                foreach (var genreId in model.Genres)
                {
                    var genre = Data.Genre.Find(genreId);
                    book.Genres.Add(genre);
                }
            }
            Data.Book.Add(book);
            Data.SaveChanges();
            return Ok("The book is added successfully.");
        }

        [Route("Books/{id}")]
        public IHttpActionResult deleteBook(Guid id)
        {
            var book = Data.Book.Find(id);
            if (book == null)
            {
                return Ok("Book not found");
            }
            Data.Book.Delete(book);
            Data.SaveChanges();
            return Ok("Book deleted successfully");
        }

        [HttpPut]
        [Route("Books/{id}")]
        public IHttpActionResult updateBook(Guid id, [FromBody]AdminBookBindingModel model)
        {
            var book = Data.Book.Find(id);
            if (book == null)
            {
                return Ok("Book not found");
            }
            book.Title = model.Title;
            foreach (var authorId in model.Authors)
            {
                var author = Data.Author.Find(authorId);
                book.Authors.Add(author);
            }
            if (model.Characters != null)
            {
                book.Characters = model.Characters;
            }
            if (model.CoverImage != null)
            {
                book.CoverImage = model.CoverImage;
            }
            if (model.Isbn != null)
            {
                book.Isbn = model.Isbn;
            }
            if (model.Resume != null)
            {
                book.Resume = model.Resume;
            }
            if (model.Genres != null)
            {
                foreach (var genreId in model.Genres)
                {
                    var genre = Data.Genre.Find(genreId);
                    book.Genres.Add(genre);
                }
            }
            Data.Book.Update(book);
            Data.SaveChanges();
            return Ok("The book is updated successfully.");
        }
    }
}