namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using BooksSocial.Data;
    using BooksSocial.WebServices.Models;

    public class ReviewController : BaseApiController
    {
        public ReviewController()
        {
        }

        public ReviewController(IBooksSocialData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("api/reviews")]
        public IHttpActionResult GetAllReviews([FromUri]GetReviewsBindingModel model)
        {
            var reviews = Data.Review.All().Select(r =>  new
            {
                Id = r.Id,
                Text = r.Text,
                CreatedOn = r.CreatedOn,
                BookId = r.Book.Id,
                UserId = r.User.Id.ToString()
            });

            return this.Ok(reviews);
        }

        [HttpGet]
        [Route("api/reviews/{id}")]
        public IHttpActionResult GetReviewsById(Guid id)
        {
            var review = Data.Review.All().Select(r => new
            {
                Id = r.Id,
                Text = r.Text,
                CreatedOn = r.CreatedOn,
                BookId = r.Book.Id,
                UserId = r.User.Id.ToString()
            });

            return this.Ok(review);
        }

        [HttpGet]
        [Route("api/reviews/getreviewsbybook/{id}")]
        public IHttpActionResult GetReviewsByBook(Guid id, [FromUri]GetReviewsBindingModel model)
        {
            var reviews = Data.Book.All()
                .Where(b => b.Id == id)
                .Select(b => b.Reviews
                    .Select(r => new
                    {
                        Id = r.Id,
                        Text = r.Text,
                        CreatedOn = r.CreatedOn,
                        BookId = r.Book.Id,
                        UserId = r.User.Id.ToString()
                    }));

            return this.Ok(reviews);
        }

        
    }
}