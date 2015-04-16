namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using BooksSocial.Data;

    public class ShelfController : BaseApiController
    {
        public ShelfController()
        {
        }

        public ShelfController(IBooksSocialData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("api/shelves/getshelvesbyuser")]
        public IHttpActionResult GetShelvesByUserId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            var shelves = Data.Shelf.All()
                .Where(s => s.User.Id == userId.ToString())
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name
                });

            return this.Ok(shelves);
        }

        [HttpGet]
        [Route("api/shelves/{id}")]
        public IHttpActionResult GetReviewsById(Guid id)
        {
            var shelf = Data.Shelf.All().Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Books = s.Books
            });

            return this.Ok(shelf);
        }
    }
}