using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BooksSocial.Models;
using BooksSocial.WebServices.Models;

namespace BooksSocial.Web.Models.Books
{
    using System;

    public class GetBooksBindingModel
    {
       
        public static Expression<Func<Book, GetBooksBindingModel>> FromBook
        {
            get
            {
                return b => new GetBooksBindingModel()
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Authors = b.Authors.Select(a => new AuthorBindingModels()
                    {
                        Id = a.Id
                    }).ToList()
                };
            }
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public List<AuthorBindingModels> Authors { get; set; }

    }
}