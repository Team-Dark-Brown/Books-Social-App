namespace BooksSocial.WebServices.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BooksSocial.Models;

    public class UserShelfBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }

    }
}