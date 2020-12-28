using System.ComponentModel.DataAnnotations;

namespace Yo.Models.ViewModels
{
    public class RequestUserViewModel
    {
        public string UserId { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(256)]
        public string ImagePath { get; set; }
    }
}
