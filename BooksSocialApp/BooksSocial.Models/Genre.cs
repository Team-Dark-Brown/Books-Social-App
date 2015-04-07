namespace BooksSocial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public Genre()
        {
            this.Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
