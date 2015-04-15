namespace BooksSocial.WebServices.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserRatingBindingModel
    {
        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public Guid BookId { get; set; }

    }
}