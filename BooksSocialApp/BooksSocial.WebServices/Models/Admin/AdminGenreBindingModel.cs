namespace BooksSocial.WebServices.Models.Admin
{
    using System.ComponentModel.DataAnnotations;

    public class AdminGenreBindingModel
    {
        public AdminGenreBindingModel()
        {
        }

        [Required]
        public string Name { get; set; }
    }
}
