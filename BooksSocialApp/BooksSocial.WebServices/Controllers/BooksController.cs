namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using BooksSocial.Web.Models.Books;

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
        public IHttpActionResult GetAllBooks([FromUri] GetBooksBindingModel model)
        {

            var books = Data.Book.All().Select(b => new
            {
                Id = b.Id,
                CoverImage = b.CoverImage,
                Title = b.Title,
                Resume = b.Resume,
                Isbn = b.Isbn,
                NumberOfPages = b.NumberOfPages,
                Authors = b.Authors
            });

            return Ok(books);

        }

        [HttpGet]
        [Route("api/books/{id}")]
        public IHttpActionResult GetBooksById(Guid id)
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