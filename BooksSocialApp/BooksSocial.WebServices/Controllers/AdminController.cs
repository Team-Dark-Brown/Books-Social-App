namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using BooksSocial.WebServices.Models.Admin;

    [Authorize(Roles = "Admin")]
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

        [HttpPost]
        [Route("Authors")]
        public IHttpActionResult AddAuthor([FromBody]AdminAuthorBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Information = model.Information,
                Picture = model.Picture,
                Website = model.Website
            };

            Data.Author.Add(author);
            Data.SaveChanges();
            return Ok("The author is added successfully.");
        }

        [HttpDelete]
        [Route("Authors/{id}")]
        public IHttpActionResult DeleteAuthor(Guid id)
        {
            var author = Data.Author.Find(id);

            if (author == null)
            {
                return BadRequest("Author not found");
            }

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
                return BadRequest(ModelState);
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

        [HttpPost]
        [Route("Genres")]
        public IHttpActionResult AddGenre([FromBody]AdminGenreBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = new Genre();
            genre.Name = model.Name;

            if (model.Books != null)
            {
                foreach (var bookId in model.Books)
                {
                    var book = Data.Book.Find(bookId);
                    genre.Books.Add(book);
                }
            }

            Data.Genre.Add(genre);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [HttpDelete]
        [Route("Genres/{id}")]
        public IHttpActionResult DeleteGenre(Guid id)
        {
            var genre = Data.Genre.Find(id);

            if (genre == null)
            {
                return BadRequest("Genre not found");
            }

            Data.Genre.Delete(genre);
            Data.SaveChanges();
            return Ok("Genre deleted successfully.");
        }

        [HttpPut]
        [Route("Genres/{id}")]
        public IHttpActionResult UpdateGenre(Guid id, [FromBody]AdminGenreBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = Data.Genre.Find(id);
            if (genre == null)
            {
                return BadRequest("Genre not found");
            }

            genre.Name = model.Name;
            if (model.Books != null)
            {
                foreach (var bookId in model.Books)
                {
                    var book = Data.Book.Find(bookId);
                    genre.Books.Add(book);
                }
            }
            
            Data.Genre.Update(genre);
            Data.SaveChanges();
            return Ok("Genre updated successfully.");
        }

        [HttpPost]
        [Route("Books")]
        public IHttpActionResult AddBook([FromBody]AdminBookBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = new Book();
            book.Title = model.Title;

            foreach (var authorId in model.Authors)
            {
                var author = Data.Author.Find(authorId);
                book.Authors.Add(author);
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

            book.NumberOfPages = model.NumberOfPages;

            Data.Book.Add(book);
            Data.SaveChanges();
            return Ok("The book is added successfully.");
        }

        [HttpDelete]
        [Route("Books/{id}")]
        public IHttpActionResult DeleteBook(Guid id)
        {
            var book = Data.Book.Find(id);
            if (book == null)
            {
                return BadRequest("Book not found");
            }

            Data.Book.Delete(book);
            Data.SaveChanges();
            return Ok("Book deleted successfully");
        }

        [HttpPut]
        [Route("Books/{id}")]
        public IHttpActionResult UpdateBook(Guid id, [FromBody]AdminBookBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = Data.Book.Find(id);
            if (book == null)
            {
                return BadRequest("Book not found");
            }

            book.Title = model.Title;
            foreach (var authorId in model.Authors)
            {
                var author = Data.Author.Find(authorId);
                book.Authors.Add(author);
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