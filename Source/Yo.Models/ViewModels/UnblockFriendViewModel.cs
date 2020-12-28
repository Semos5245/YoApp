using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yo.Models.ViewModels
{
    public class UnblockFriendViewModel
    {
        public string UnblockerId { get; set; }

        public string UnblockedId { get; set; }

        public UnblockFriendViewModel(string unblockerId, string unblockedId)
        {
            this.UnblockedId = unblockedId;
            this.UnblockerId = unblockerId;
        }
    }
}
