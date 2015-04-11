using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BooksSocial.WebServices.Models.Admin
{
    public class AdminGenreBindingModel
    {
        public AdminGenreBindingModel()
        {

        }

        [Required]
        public string name { get; set; }
    }
}
