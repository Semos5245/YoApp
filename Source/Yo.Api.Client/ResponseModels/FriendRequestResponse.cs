using System.Collections.Generic;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.ResponseModels
{
    public class FriendRequestResponse : Response
    {
        public IEnumerable<RequestUserViewModel> PendingUsers { get; set; }
    }
}
