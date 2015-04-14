using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BooksSocial.Models;

namespace BooksSocial.WebServices.Models.Users
{
    public class UserReviewBindingModel
    {
        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}