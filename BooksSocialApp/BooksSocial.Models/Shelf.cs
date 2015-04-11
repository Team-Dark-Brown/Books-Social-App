namespace BooksSocial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Shelf
    {
        public Shelf()
        {
            this.Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public virtual User User { get; set; }

    }
}
