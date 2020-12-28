using System;
using System.ComponentModel.DataAnnotations;

namespace Yo.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string ImagePath { get; set; }
        
        public int YosCount { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
