using System.ComponentModel.DataAnnotations;

namespace Yo.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string ChangerId { get; set; }

        [StringLength(50)]
        public string NewPassword { get; set; }

        public ChangePasswordViewModel(string changerId, string newPassword)
        {
            this.ChangerId = changerId;
            this.NewPassword = newPassword;
        }
    }
}
