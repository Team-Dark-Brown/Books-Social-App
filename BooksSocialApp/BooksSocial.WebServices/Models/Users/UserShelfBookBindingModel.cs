namespace BooksSocial.WebServices.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserShelfBookBindingModel
    {
        [Required]
        public Guid BookId { get; set; }

    }
}