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

    }
}