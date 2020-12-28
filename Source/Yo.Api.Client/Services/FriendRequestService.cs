using AKSoftware.WebApi.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yo.Api.Client.Models;
using Yo.Api.Client.ResponseModels;
using Yo.Models.ViewModels;
using Yo.Models;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace Yo.Api.Client.Services
{
    public class FriendRequestService
    {
        ServiceClient client = new ServiceClient();

        string url = $@"{HttpSettings.BaseAddress}FriendRequests/";

        public async Task<IEnumerable<RequestUserViewModel>> GetPendingRequestsAsync(string id)
        {
            return (await client.GetAsync<FriendRequestResponse>(url + "GetPendingRequests/" + id)).PendingUsers;
        }

        public async Task<Response> SendRequestAsync(SendRequestViewModel model)
        {
            return await client.PostAsync<Response>(url + "SendRequest", model);
        }

        public async Task<Response> AcceptRequestAsync(AcceptRequestViewModel model)
        {
            return await client.PutAsync<Response>(url + "AcceptRequest", model);
        }

        public async Task<Response> RejectRequestAsync(RejectRequestViewModel model)
        {
            return await client.PutAsync<Response>(url + "RejectRequest", model);
        }

        public async Task<Response> DeleteRequestAsync(string id)
        {
            using (var client = new HttpClient())
            {
                var response = await (await client.DeleteAsync(url + "DeleteRequest?id=" + id)).Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Response>(response);
            }
        }
    }
}
