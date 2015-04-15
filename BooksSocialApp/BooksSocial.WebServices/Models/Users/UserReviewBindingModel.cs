namespace BooksSocial.WebServices.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserReviewBindingModel
    {
        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public Guid BookId { get; set; }
    }
}
