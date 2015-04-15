namespace BooksSocial.WebServices.Controllers
{
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BooksSocial.Data;    
    using BooksSocial.Models;

    public abstract class BaseApiController : ApiController
    {
        private IBooksSocialData data;

        protected BooksSocialDbContext context;

        protected BaseApiController()
            : this(new BooksSocialData(new BooksSocialDbContext()))
        {
            var userManager = new UserManager<User>(new UserStore<User>((this.Data as BooksSocialData).context));
            this.CurrentUser = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());
        }

        protected BaseApiController(IBooksSocialData data)
        {
            this.data = data;
        }

        protected User CurrentUser { get; private set; }

        protected IBooksSocialData Data
        {
            get { return this.data; }
        }
    }
}