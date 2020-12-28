using System.Collections.Generic;
using Yo.Models;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.ResponseModels
{
    public class FriendRelationResponse : Response
    {
        public IEnumerable<FriendUserViewModel> Friends { get; set; }

        public IEnumerable<BlockedFriendViewModel> BlockedFriends { get; set; }
    }
}
