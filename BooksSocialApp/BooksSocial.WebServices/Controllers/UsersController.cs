﻿using System;
using BooksSocial.WebServices.Models.Users;

namespace BooksSocial.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;

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
    }
}