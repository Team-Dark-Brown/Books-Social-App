namespace BooksSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Review> reviews;
        private ICollection<Rating> ratings;
        private ICollection<Shelf> shelves;
        private ICollection<Genre> genres;
        private ICollection<User> readers;

        public Book()
        {
            this.Id = Guid.NewGuid();
            this.authors = new HashSet<Author>();
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
            this.shelves = new HashSet<Shelf>();
            this.genres = new HashSet<Genre>();
            this.readers = new HashSet<User>();
            this.Characters = new List<string>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Resume { get; set; }

        public string Isbn { get; set; }

        public int NumberOfPages { get; set; }

        public List<string> Characters { get; set; }

        // [Column(TypeName = "binary")]
        public string CoverImage { get; set; }

        [Required]
        public ICollection<Author> Authors
        {
            get { return this.authors; }
        }

        public ICollection<Review> Reviews
        {
            get { return this.reviews; }
        }

        public ICollection<Rating> Ratings
        {
            get { return this.ratings; }
        }

        public ICollection<Shelf> Shelves
        {
            get { return this.shelves; }
        }

        public ICollection<Genre> Genres
        {
            get { return this.genres; }
        }

        public ICollection<User> Readers
        {
            get { return this.readers; }
        }
    }
}
