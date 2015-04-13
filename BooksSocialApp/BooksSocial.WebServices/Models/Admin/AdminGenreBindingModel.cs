namespace BooksSocial.WebServices.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdminGenreBindingModel
    {
        public AdminGenreBindingModel()
        {
        }

        [Required]
        public string Name { get; set; }

        public ICollection<Guid> Books { get; set; } 
    }
}
