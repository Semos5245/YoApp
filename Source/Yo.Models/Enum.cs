using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yo.Models
{
    public enum Status
    {
        Success,
        Failure
    }

    public enum FriendRequestStatus
    {
        Accepted,
        Rejected,
        Blocked,
        Pending
    }
}
