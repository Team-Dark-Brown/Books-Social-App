namespace BooksSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        public Book()
        {
            this.Id = Guid.NewGuid();
            this.Authors = new HashSet<Author>();
            this.Reviews = new HashSet<Review>();
            this.Ratings = new HashSet<Rating>();;
            this.Shelves = new HashSet<Shelf>();
            this.Genres = new HashSet<Genre>();
            this.Readers = new HashSet<User>();
            this.Characters = new List<string>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Resume { get; set; }

        public string Isbn { get; set; }

        public List<string> Characters { get; set; }

       // [Column(TypeName = "binary")]
        public string CoverImage { get; set; }
            
        [Required]
        public ICollection<Author> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Shelf> Shelves { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<User> Readers { get; set; } 
    }
}
