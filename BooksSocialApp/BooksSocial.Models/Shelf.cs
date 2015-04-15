namespace BooksSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shelf
    {
        public Shelf()
        {
            this.Id = Guid.NewGuid();
            this.Books = new HashSet<Book>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [Required]
        public virtual User User { get; set; }

    }
}
