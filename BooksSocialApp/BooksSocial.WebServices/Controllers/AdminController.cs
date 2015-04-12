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
            var author = new Author();
            author.Information = model.Information; 
            Data.Author.Add(author);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
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
            var author = Data.Author.All().FirstOrDefault(a => a.Id == id);
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


        [Route("Books")]
        public IHttpActionResult AddBook([FromBody]AdminBookBindingModel model)
        {
            var book = new Book();
            book.Characters = model.Characters;
            book.Title = model.Title;
            foreach (var authorId in model.Authors)
            {
                var author = Data.Author.All().Where(a => a.Id == authorId).FirstOrDefault();
                book.Authors.Add(author);
            }
            Data.Book.Add(book);
            Data.SaveChanges();
            return Ok("The book is added successfully.");
        }
    }
}