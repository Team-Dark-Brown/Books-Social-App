namespace BooksSocial.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BooksSocial.Data;
    using BooksSocial.WebServices.Models;

    public class GenresController : BaseApiController
    {
        public GenresController()
        {
        }

        public GenresController(IBooksSocialData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("api/genres")]
        public IHttpActionResult GetAllGenres([FromUri] GetGenresBindingModel model)
        {

            var genres = Data.Genre.All().Select(g => new
            {
                Id = g.Id,
                Name = g.Name
            });

            return Ok(genres);
        }
    }
}