using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yo.Api.Client.ResponseModels;
using Yo.Api.Client.Services;
using Yo.Models.ViewModels;
using Yo.Models;

namespace Yo.Api.Client.Models
{
    public class FriendRequest
    {
        private static readonly FriendRequestService service = new FriendRequestService();

        public static async Task<IEnumerable<RequestUserViewModel>> GetPendingRequestsAsync(string id)
        {
            return await service.GetPendingRequestsAsync(id);
        }

        public static async Task<Response> SendRequestAsync(string requesterId, string receiverId)
        {
            return await service.SendRequestAsync(new SendRequestViewModel(requesterId, receiverId));
        }

        public static async Task<Response> AcceptRequestAsync(string accepterId, string requesterId)
        {
            return await service.AcceptRequestAsync(new AcceptRequestViewModel(accepterId, requesterId));
        }

        public static async Task<Response> RejectRequestAsync(string rejecterId, string requesterId)
        {
            return await service.RejectRequestAsync(new RejectRequestViewModel(rejecterId, requesterId));
        }

        public static async Task<Response> DeleteRequestAsync(string id)
        {
            return await service.DeleteRequestAsync(id);
        }
    }
}
