using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class UnFriendViewModel
    {
        public string UnFrienderId { get; set; }

        public string UnFriendedId { get; set; }

        public UnFriendViewModel(string unfrienderId, string unfriendedId)
        {
            this.UnFriendedId = unfriendedId;
            this.UnFrienderId = unfrienderId;
        }
    }
}