namespace BooksSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {
        public Author()
        {
            this.Id = new Guid();
            this.Books = new HashSet<Book>();
        }

        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "ntext")]
        public string Information { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
