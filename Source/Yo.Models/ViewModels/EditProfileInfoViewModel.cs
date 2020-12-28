using System.ComponentModel.DataAnnotations;

namespace Yo.Models.ViewModels
{
    public class EditProfileInfoViewModel
    {
        public string UserId { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
    }
}
