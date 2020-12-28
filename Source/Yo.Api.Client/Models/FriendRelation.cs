using System.Collections.Generic;
using System.Threading.Tasks;
using Yo.Api.Client.ResponseModels;
using Yo.Api.Client.Services;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.Models
{
    public class FriendRelation
    {
        private static readonly FriendRelationService service = new FriendRelationService();
        
        public static async Task<IEnumerable<FriendUserViewModel>> GetFriendsAsync(string id)
        {
            return await service.GetFriendsAsync(id);
        }

        public static async Task<IEnumerable<BlockedFriendViewModel>> GetBlockedFriendsAsync(string id)
        {
            return await service.GetBlockedFriendsAsync(id);
        }

        public static async Task<Response> UnblockFriendAsync(string unblockerId, string unblockedId)
        {
            return await service.UnblockFriendAsync(new UnblockFriendViewModel(unblockerId, unblockedId));
        }

        public static async Task<Response> BlockFriendAsync(string blockerId, string blockedId)
        {
            return await service.BlockFriendAsync(new BlockFriendViewModel(blockerId, blockedId));
        }

        public static async Task<Response> UnFriendAsync(string unfrienderId, string unfriendedId)
        {
            return await service.UnFriendAsync(new UnFriendViewModel(unfrienderId, unfriendedId));
        }
    }
}
