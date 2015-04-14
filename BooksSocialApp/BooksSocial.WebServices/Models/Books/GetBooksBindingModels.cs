namespace BooksSocial.Web.Models.Books
{
    using System;

    public class GetBooksBindingModel
    {
        public GetBooksBindingModel()
        {
        }

        public Guid? AuthorId { get; set; }

        public Guid? GenreId { get; set; }

    }
}