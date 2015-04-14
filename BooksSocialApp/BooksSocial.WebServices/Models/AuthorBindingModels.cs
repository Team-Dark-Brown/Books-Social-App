using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BooksSocial.Models;
using BooksSocial.Web.Models.Books;

namespace BooksSocial.WebServices.Models
{
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