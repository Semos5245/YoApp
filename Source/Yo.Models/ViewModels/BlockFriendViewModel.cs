using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class BlockFriendViewModel
    {
        public string BlockerId { get; set; }

        public string BlockedId { get; set; }

        public BlockFriendViewModel(string blockerId, string blockedId)
        {
            this.BlockedId = blockedId;
            this.BlockerId = blockerId;
        }
    }
}