using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksSocial.WebServices.Models
{
    public class GetReviewsBindingModel
    {
        public GetReviewsBindingModel()
        {
        }

        public Guid? UserId { get; set; }

        public Guid? BookId { get; set; }
    }
}