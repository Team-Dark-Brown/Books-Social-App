namespace BooksSocial.WebServices.Models.Books
{
    using System;
    using System.Linq.Expressions;
    using BooksSocial.Models;

    public class BooksBindingModel
    {
        public static Expression<Func<Book, BooksBindingModel>> FromBook
        {
            get
            {
                return a => new BooksBindingModel()
                {
                    Id = a.Id
                };
            }
        }

        public Guid Id { get; set; }
    }
}