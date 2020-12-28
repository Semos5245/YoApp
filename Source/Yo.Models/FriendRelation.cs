using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yo.Models
{
    public class FriendRelation
    {
        [Key]
        public string FriendRelationId { get; set; }

        public bool IsBlocked { get; set; }

        public DateTime FriendshipDate { get; set; }

        //Relation with other tables
        [Required]
        public virtual User CurrentUser { get; set; }

        [ForeignKey("CurrentUser")]
        public string CurrentUserId { get; set; }

        public virtual User FriendUser { get; set; }

        [ForeignKey("FriendUser")]
        public string FriendUserId { get; set; }

    }
}
