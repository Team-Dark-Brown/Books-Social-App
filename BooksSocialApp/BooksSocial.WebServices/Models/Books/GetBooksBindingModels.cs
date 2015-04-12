namespace BooksSocial.Web.Models.Books
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GetBooksBindingModel
    {
        public GetBooksBindingModel()
        {
        }

        public Guid? AuthorId { get; set; }

        public Guid? GenreId { get; set; }

    }
}