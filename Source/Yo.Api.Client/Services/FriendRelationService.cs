using AKSoftware.WebApi.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Yo.Api.Client.Models;
using Yo.Api.Client.ResponseModels;
using Yo.Models.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Text;

namespace Yo.Api.Client.Services
{
    public class FriendRelationService
    {
        private static readonly ServiceClient client = new ServiceClient();

        string url = $@"{HttpSettings.BaseAddress}FriendRelations/";

        public async Task<IEnumerable<FriendUserViewModel>> GetFriendsAsync(string id)
        {
            var response = (await client.GetAsync<FriendRelationResponse>(url + "GetFriends/" + id));

            return response.Friends;
        }

        public async Task<Response> BlockFriendAsync(BlockFriendViewModel model)
        {
            return await client.PutAsync<Response>(url + "BlockFriend", model);
        }

        public async Task<Response> UnFriendAsync(UnFriendViewModel model)
        {
            using(HttpClient myClient = new HttpClient())
            {
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url + "DeleteFriend"),
                    Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                };

                var response = await (await myClient.SendAsync(request)).Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Response>(response);
            }
        }

        public async Task<IEnumerable<BlockedFriendViewModel>> GetBlockedFriendsAsync(string id)
        {
            var response = (await client.GetAsync<FriendRelationResponse>(url + "GetBlockedFriends/" + id));

            return response.BlockedFriends;
        }

        public async Task<Response> UnblockFriendAsync(UnblockFriendViewModel model)
        {
            return await client.PutAsync<FriendRelationResponse>(url + "UnBlockFriend", model);
        }
    }
}
