namespace BooksSocial.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Book> books;
        private ICollection<Shelf> shelves;
        private ICollection<Author> favoriteAuthors;

        public User()
        {
            this.books = new HashSet<Book>();
            this.shelves = new HashSet<Shelf>();
            this.favoriteAuthors = new HashSet<Author>();
            this.Users = new HashSet<User>();
            this.Friends = new HashSet<User>();
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

        [InverseProperty("Friends")]
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<User> Friends { get; set; }

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
