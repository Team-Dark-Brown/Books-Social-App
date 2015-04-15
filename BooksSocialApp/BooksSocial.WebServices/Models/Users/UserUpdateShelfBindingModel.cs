namespace BooksSocial.WebServices.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserUpdateShelfBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}