namespace BooksSocial.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;
    using BooksSocial.Models;
    using System;

    [RoutePrefix("api/User")]
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

        [Route("Books/review")]
        public IHttpActionResult addBookReview([FromUri]Guid bookId, [FromBody]string review)
        {
            var rate = new Review();
            rate.Book = Data.Book.Find(bookId);
            rate.User = Data.User.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
            rate.CreatedOn = new DateTime();
            //rate.text = review;
            Data.Review.Add(rate);
            Data.SaveChanges();
            return Ok("Rated successfully.");
        }

        [Route("Books/rate")]
        public IHttpActionResult addBookRating([FromUri]Guid bookId, [FromBody]int rating)
        {
            var rate = new Rating();
            rate.Book = Data.Book.Find(bookId);
            rate.User = Data.User.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
            rate.CreatedOn = new DateTime();
            //rate.value = rating;
            Data.Rating.Add(rate);
            Data.SaveChanges();
            return Ok("Rated successfully.");
        }

        //public IHttpActionResult addBookToRead()
        //{
        //    //TODO
        //}

        //public IHttpActionResult markBookAsRead()
        //{
        //    //TODO
        //}

        //public IHttpActionResult markBookAsReading()
        //{
        //    //TODO
        //}

        //public IHttpActionResult getBooks()
        //{
        //    //TODO
        //}


    }
}