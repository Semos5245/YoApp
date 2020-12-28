using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yo.Models
{
    public class FriendsRequest
    {
        [Key]
        public string FriendRequestId { get; set; }
        
        [StringLength(10)]
        public string Status { get; set; }

        public DateTime RequestDate { get; set; }

        //Relations with other tables

        [Required]
        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }

        [ForeignKey("FromUser")]
        public string FromId { get; set; }

        [ForeignKey("ToUser")]
        public string ToId { get; set; }
        
    }
}
