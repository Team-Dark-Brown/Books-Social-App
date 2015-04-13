using System.Collections.Generic;

namespace BooksSocial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        private ICollection<Book> books;

        public Genre()
        {
            this.Id = Guid.NewGuid();
            this.books = new HashSet<Book>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books
        {
            get { return this.books; }
        }

    }
}
