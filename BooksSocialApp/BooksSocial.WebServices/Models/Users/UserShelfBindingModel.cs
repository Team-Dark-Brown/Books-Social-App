namespace BooksSocial.WebServices.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserShelfBindingModel
    {
        [Required]
        public string Name { get; set; }

    }
}