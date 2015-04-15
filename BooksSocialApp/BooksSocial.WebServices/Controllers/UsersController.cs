namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using BooksSocial.WebServices.Models.Users;

    public class UserController : BaseApiController
    {
        public UserController()
        {
        }

        public UserController(IBooksSocialData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsersCount()
        {
            var count = this.Data.User.All().Count();

            return this.Ok(count);
        }

        [HttpPost]
        [Route("api/users/reviews")]
        public IHttpActionResult AddReview([FromBody]UserReviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Data.User.All().FirstOrDefault(u => u.Id == model.UserId.ToString());
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var book = Data.Book.All().FirstOrDefault(b => b.Id == model.BookId);
            if (book == null)
            {
                return BadRequest("Book not found.");
            }

            var review = new Review()
            {
                Book = book,
                User = user,
                CreatedOn = DateTime.Now,
                Text = model.Text
            };

            Data.Review.Add(review);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [HttpPost]
        [Route("api/users/ratings")]
        public IHttpActionResult AddRating([FromBody]UserRatingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Data.User.All().FirstOrDefault(u => u.Id == model.UserId.ToString());
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var book = Data.Book.All().FirstOrDefault(b => b.Id == model.BookId);
            if (book == null)
            {
                return BadRequest("Book not found.");
            }

            var rating = new Rating()
            {
                Book = book,
                User = user,
                CreatedOn = DateTime.Now,
                Value = model.Value
            };

            Data.Rating.Add(rating);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [HttpPost]
        [Route("api/users/shelves")]
        public IHttpActionResult AddShelf([FromBody]UserShelfBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Data.User.All().FirstOrDefault(u => u.Id == model.UserId.ToString());
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var shelf = new Shelf()
            {
                User = user,
                Name = model.Name
            };

            Data.Shelf.Add(shelf);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [HttpPut]
        [Route("api/users/shelves/{id}")]
        public IHttpActionResult UpdateShelf(Guid id, [FromBody]UserUpdateShelfBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shelf = Data.Shelf.Find(id);
            if (shelf == null)
            {
                return BadRequest("Shelf not found.");
            }

            shelf.Name = model.Name;

            Data.Shelf.Update(shelf);
            Data.SaveChanges();
            return Ok("Shelf updated successfully.");
        }

        [HttpDelete]
        [Route("api/users/shelves/{id}")]
        public IHttpActionResult DeleteShelf(Guid id)
        {
            var shelf = Data.Shelf.Find(id);
            if (shelf == null)
            {
                return BadRequest("Shelf not found.");
            }

            Data.Shelf.Delete(shelf);
            Data.SaveChanges();
            return Ok("Shelf deleted successfully.");
        }

        [HttpPost]
        [Route("api/users/shelves/{id}")]
        public IHttpActionResult AddBookToShelf(Guid id, [FromBody] UserShelfBookBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shelf = Data.Shelf.Find(id);
            if (shelf == null)
            {
                return BadRequest("Shelf not found");
            }

            var book = Data.Book.Find(model.BookId);
            if (book == null)
            {
                return BadRequest("Book not found");
            }

            shelf.Books.Add(book);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [HttpDelete]
        [Route("api/users/shelves/deletebook/{id}")]
        public IHttpActionResult DeleteBookFromShelf(Guid id, [FromBody] UserShelfBookBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shelf = Data.Shelf.Find(id);
            if (shelf == null)
            {
                return BadRequest("Shelf not found");
            }

            var book = shelf.Books.FirstOrDefault(b => b.Id == model.BookId);
            if (book == null)
            {
                return BadRequest("Book not found");
            }

            shelf.Books.Remove(book);
            book.Shelves.Remove(shelf);

            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }
    }
}