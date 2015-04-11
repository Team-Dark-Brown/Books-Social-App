namespace BooksSocial.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Book> books;
        private ICollection<Shelf> shelves;
        private ICollection<Author> favoriteAuthors;
        private ICollection<User> friends;

        public User()
        {
            this.books = new HashSet<Book>();
            this.shelves = new HashSet<Shelf>();
            this.favoriteAuthors = new HashSet<Author>();
            this.friends = new HashSet<User>();
        }

        //[Column(TypeName = "binary")]
        public string ProfileImage { get; set; }

        public ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public ICollection<Shelf> Shelves
        {
            get { return this.shelves; }
            set { this.shelves = value; }
        }

        public ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        public ICollection<Author> FavoriteAuthors
        {
            get { return this.favoriteAuthors; }
            set { this.favoriteAuthors = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}
