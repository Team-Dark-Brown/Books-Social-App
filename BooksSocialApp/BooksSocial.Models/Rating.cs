namespace BooksSocial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public Rating()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(1,5)]
        public int Value { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
