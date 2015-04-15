namespace BooksSocial.Web.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime.Misc;

    using BooksSocial.Models;
    using BooksSocial.WebServices.Models.Books;

    public class GetShelvesBindingModel
    {
        public static Expression<Func<Shelf, GetShelvesBindingModel>> FromShelf
        {
            get
            {
                return s => new GetShelvesBindingModel()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Books = s.Books.Select(b => new BooksBindingModel()
                    {
                        Id = b.Id
                    }).ToList()
                };
            }
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<BooksBindingModel> Books { get; set; }

    }
}