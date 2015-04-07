using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksSocial.Data.Repositories;
using BooksSocial.Models;

namespace BooksSocial.Data
{
    public interface IBooksSocialData
    {
        IRepository<User> User { get; }

        IRepository<Author> Author { get; }

        IRepository<Book> Book { get; }

        IRepository<Genre> Genre { get; }

        IRepository<Rating> Rating { get; }

        IRepository<Review> Review { get; }

        IRepository<Shelf> Shelf { get; }

        int SaveChanges();
    }
}
