using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class SignUpUserViewModel
    {
        [StringLength(25)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        
    }
}