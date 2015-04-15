namespace BooksSocial.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using BooksSocial.Data;

    public class AuthorController : BaseApiController
    {
        public AuthorController()
        {
        }

        public AuthorController(IBooksSocialData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("api/authors")]
        public IHttpActionResult GetAllAuthors()
        {
            var authors = Data.Author.All().Select(a => new
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Information = a.Information,
                Picture = a.Picture,
                Website = a.Website
            });

            return Ok(authors);
        }
    }
}