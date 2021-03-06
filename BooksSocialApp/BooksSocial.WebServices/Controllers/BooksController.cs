﻿namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
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
        public IHttpActionResult GetBookById(Guid id)
        {
            var book = Data.Book.Find(id);
            if (book == null)
            {
                return this.BadRequest("Book not found!");
            }

            return this.Ok(book);
        }

        [HttpGet]
        [Route("api/books/getbyauthor/{id}")]
        public IHttpActionResult GetBooksByAuthor(Guid id)
        {
            var books = Data.Author.All()
                .Where(a => a.Id == id)
                .Select(a => a.Books
                    .Select(b => new
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Resume = b.Resume,
                        CoverImage = b.CoverImage,
                        Isbn = b.Isbn,
                        NumberOfPages = b.NumberOfPages
                    }));

            return Ok(books);
        }

        [HttpGet]
        [Route("api/books/getbygenre/{id}")]
        public IHttpActionResult GetBooksByGenre(Guid id)
        {
            var books = Data.Genre.All()
                .Where(g => g.Id == id)
                .Select(g => g.Books
                    .Select(b => new
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Resume = b.Resume,
                        CoverImage = b.CoverImage,
                        Isbn = b.Isbn,
                        NumberOfPages = b.NumberOfPages
                    }));

            return Ok(books);
        }

        [HttpGet]
        [Route("api/books/getbookrating/{id}")]
        public IHttpActionResult GetBookRating(Guid id)
        {
            var ratings = Data.Rating.All()
                .Where(r => r.Book.Id == id);
            var sum = 0;
            foreach (var rating in ratings)
            {
                sum += rating.Value;
            }
            var ratingsCount = ratings.Count();

            var bookRating = sum/(double)ratingsCount;

            return Ok(bookRating);
        }

        [HttpGet]
        [Route("api/books/getbookvotes/{id}")]
        public IHttpActionResult GetBookRatingsCount(Guid id)
        {
            var ratingsCount = Data.Rating.All().Count(r => r.Book.Id == id);

            return Ok(ratingsCount);
        }
    }
}