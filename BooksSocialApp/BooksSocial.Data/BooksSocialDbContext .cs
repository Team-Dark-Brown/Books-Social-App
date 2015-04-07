namespace BooksSocial.Data
{
    using System.Data.Entity;

    using BooksSocial.Data.Migrations;

    using BooksSocial.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BooksSocialDbContext : IdentityDbContext<User>
    {
        public BooksSocialDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BooksSocialDbContext, Configuration>());
        }

        public static BooksSocialDbContext Create()
        {
            return new BooksSocialDbContext();
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Shelf> Shelves { get; set; }

    }
}
