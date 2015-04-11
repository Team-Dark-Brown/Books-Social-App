namespace BooksSocial.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using BooksSocial.Web.Models.Ads;

    public class BooksController : BaseApiController
    {
        public BooksController()
        {

        }

        public BooksController(IBooksSocialData data)
            : base(data)
        {

        }


        [HttpGet]
        [Route("api/books")]
        public IList<Book> GetAllBooks([FromUri]GetBooksBindingModel model)
        {
            
            var books = Data.Book.All().ToList();
            if (model == null)
            {
                return books;
            }
            if (model.AuthorId.HasValue) 
            {
                var author = this.Data.Author.All().FirstOrDefault(a => a.Id == model.AuthorId);
                books = books.Where(b => b.Authors.Contains(author)).ToList();
            }
            if (model.GenreId.HasValue)
            {
                var genre = this.Data.Genre.All().FirstOrDefault(g => g.Id == model.GenreId);
                books = books.Where(b => b.Genres.Contains(genre)).ToList();
            }
            return books;

        }


        [HttpGet]
        [Route("api/books/{id}")]
        public IHttpActionResult GetBooksByID(Guid id)
        {

            var book = Data.Book.Find(id);
            if (book == null)
            {
                return this.BadRequest("Book not found!");
            }

            return this.Ok(book);
        }

    }
}