﻿namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using BooksSocial.WebServices.Models;
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
        public IHttpActionResult GetAllUsers()
        {
            var users = Data.User.All()
                .Select(u => new
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Phone = u.PhoneNumber,
                    ProfilePicture = u.ProfileImage
                });

            return this.Ok(users);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IHttpActionResult GetUserById(Guid id)
        {
            var user = Data.User.All()
                .Where(u => u.Id == id.ToString())
                .Select(u => new
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Phone = u.PhoneNumber,
                    ProfilePicture = u.ProfileImage
                });

            return this.Ok(user);
        }

        [HttpPost]
        [Route("api/users/reviews")]
        public IHttpActionResult AddReview([FromBody]UserReviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = Data.User.All().FirstOrDefault(u => u.Id == userId);
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

        [HttpGet]
        [Route("api/users/reviews")]
        public IHttpActionResult GetReviewsByUser([FromUri]GetReviewsBindingModel model)
        {
            var id = HttpContext.Current.User.Identity.GetUserId();

            var reviews = Data.Review.All()
                .Where(r => r.User.Id == id)
                .Select(r => new
                {
                    Id = r.Id,
                    Text = r.Text,
                    CreatedOn = r.CreatedOn,
                    BookId = r.Book.Id
                }).ToList();

            return this.Ok(reviews);
        }

        [HttpPost]
        [Route("api/users/ratings")]
        public IHttpActionResult AddRating([FromBody]UserRatingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = Data.User.All().FirstOrDefault(u => u.Id == userId);
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

            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = Data.User.All().FirstOrDefault(u => u.Id == userId);
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

        [HttpPost]
        [Route("api/users/requests/{id}")]
        public IHttpActionResult CreateFriendRequest(Guid id)
        {
            var request = new FriendRequest()
            {
                Sender = CurrentUser,
                Receiver = Data.User.All().FirstOrDefault(u => u.Id == id.ToString())
            };

            Data.FriendRequest.Add(request);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }

        [HttpGet]
        [Route("api/users/requests")]
        public IHttpActionResult GetFriendRequests()
        {
            var id = HttpContext.Current.User.Identity.GetUserId();

            var requests = Data.FriendRequest.All()
                .Where(r => r.Receiver.Id == id)
                .Select(r => new
                {
                    Id = r.Id,
                    Sender = r.Sender.Id
                });

            return Ok(requests);
        }

        [HttpPost]
        [Route("api/users/friends/{id}")]
        public IHttpActionResult AddFriend(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.Current.User.Identity.GetUserId();
            var friend = Data.User.All().FirstOrDefault(u => u.Id == id.ToString());

            if (friend == null)
            {
                return BadRequest("Friend request sender not found");
            }

            var user = Data.User.All().FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var request = Data.FriendRequest.All()
                .FirstOrDefault(fr => fr.Sender.Id == id.ToString() && fr.Receiver.Id == userId);

            user.Friends.Add(friend);
            friend.Friends.Add(user);
            Data.FriendRequest.Delete(request);
            Data.SaveChanges();
            return this.StatusCode(System.Net.HttpStatusCode.Accepted);
        }
    }
}