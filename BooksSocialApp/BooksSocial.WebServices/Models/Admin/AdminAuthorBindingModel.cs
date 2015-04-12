namespace BooksSocial.WebServices.Models.Admin
{
    using System.ComponentModel.DataAnnotations;

    // Models used as parameters to AccountController actions.

    public class AdminAuthorBindingModel
    {
        public AdminAuthorBindingModel()
        {
        }

        [Required]
        public string Information { get; set; }
    }
  
}
