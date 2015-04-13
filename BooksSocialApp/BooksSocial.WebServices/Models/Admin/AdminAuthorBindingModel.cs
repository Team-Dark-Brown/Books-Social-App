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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Picture { get; set; }

        public string Website { get; set; }

        [Required]
        public string Information { get; set; }
    }
  
}
