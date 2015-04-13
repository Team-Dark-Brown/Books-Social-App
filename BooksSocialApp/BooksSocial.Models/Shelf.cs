namespace BooksSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shelf
    {
        public Shelf()
        {
            this.Id = new Guid();
            this.Books = new HashSet<Book>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Book> Books { get; set; }

        [Required]
        public virtual User User { get; set; }

    }
}
