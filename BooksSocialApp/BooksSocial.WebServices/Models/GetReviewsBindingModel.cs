namespace BooksSocial.WebServices.Models
{
    using System;

    public class GetReviewsBindingModel
    {
        public GetReviewsBindingModel()
        {
        }

        public Guid? UserId { get; set; }

        public Guid? BookId { get; set; }
    }
}