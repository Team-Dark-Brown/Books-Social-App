namespace BooksSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {
        private ICollection<Book> books;
        private ICollection<User> fans; 

        public Author()
        {
            this.Id = Guid.NewGuid();
            this.books = new HashSet<Book>();
            this.fans = new HashSet<User>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Picture { get; set; }

        public string Website { get; set; }

        [Column(TypeName = "ntext")]
        public string Information { get; set; }

        public ICollection<Book> Books
        {
            get { return this.books; }
        }

        public ICollection<User> Fans
        {
            get { return this.fans; }
        }
    }
}
