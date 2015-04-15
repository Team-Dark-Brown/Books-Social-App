namespace BooksSocial.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

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
        [Route("api/shelves/getshelvesbyuser/{id}")]
        public IHttpActionResult GetShelvesByUserId(Guid id)
        {
            var shelves = Data.Shelf.All()
                .Where(s => s.User.Id == id.ToString())
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