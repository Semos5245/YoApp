using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yo.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string ImagePath { get; set; }

        public Location CurrentLocation { get; set; }

        public DateTime CreationDate { get; set; }

        //Relations with other tables

        public virtual List<FriendRelation> FriendRelations { get; set; }

        public virtual List<FriendsRequest> FromRequests { get; set; }

        public virtual List<FriendsRequest> ToRequests { get; set; }

        public virtual List<Yo> YosSent { get; set; }

        public virtual List<Yo> YosReceived { get; set; }

    }
}
