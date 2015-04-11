using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BooksSocial.WebServices.Models.Admin
{
    // Models used as parameters to AccountController actions.

    public class AdminAuthorBindingModel
    {

        public AdminAuthorBindingModel()
        {
            
        }

        
        [Required]
        public string Information { get; set; }
    }

  
}
