namespace BooksSocial.WebServices.Models
{
    using System;
    using System.Linq.Expressions;

    using BooksSocial.Models;

    public class AuthorBindingModels
    {
        public static Expression<Func<Author, AuthorBindingModels>> FromAuthor
        {
            get
            {
                return a => new AuthorBindingModels()
                {
                    Id = a.Id
                };
            }
        }

        public Guid Id { get; set; }

    }
}