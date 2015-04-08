namespace BooksSocial.WebServices.Controllers
{
    using System.Web.Http;

    using BooksSocial.Data;

    public abstract class BaseApiController : ApiController
    {
        private IBooksSocialData data;

        protected BaseApiController()
            : this(new BooksSocialData(new BooksSocialDbContext()))
        {

        }

        protected BaseApiController(IBooksSocialData data)
        {
            this.data = data;
        }

        protected IBooksSocialData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}