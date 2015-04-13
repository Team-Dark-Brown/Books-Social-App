namespace BooksSocial.WebServices.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BooksSocial.Models;

    public class AdminBookBindingModel
    {
        public AdminBookBindingModel()
        {
        }

        [Required]
        public string Title { get; set; }

        public string Resume { get; set; }

        public string Isbn { get; set; }

        public int NumberOfPages { get; set; }

        public List<string> Characters { get; set; }

        // [Column(TypeName = "binary")]
        public string CoverImage { get; set; }

        [Required]
        public ICollection<Guid> Authors { get; set; }

        public ICollection<Guid> Genres { get; set; }

    }
}
