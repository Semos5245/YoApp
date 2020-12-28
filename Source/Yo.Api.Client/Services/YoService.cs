using System.Threading.Tasks;
using Yo.Api.Client.ResponseModels;
using AKSoftware.WebApi.Client;
using Yo.Api.Client.Models;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.Services
{
    public class YoService
    {
        ServiceClient client = new ServiceClient();

        string url = $@"{HttpSettings.BaseAddress}Yos/";

        public async Task<Response> DeleteYoAsync(string id)
        {
            return await client.DeleteAsync<Response>(url + "DeleteYo/" + id, null);
        }

        public async Task<Response> SendYoAsync(SendYoViewModel model)
        {
            return await client.PostAsync<Response>(url + "SendYo", model);
        }

        public async Task<Response> MakeYosRecieved(string yoedId)
        {
            return await client.PutAsync<Response>(url + "MakeYosRecieved?yoedId=" + yoedId, null);
        }

        public async Task<YoResponse> GetYosAsnyc(string id)
        {
            return await client.GetAsync<YoResponse>(url + "GetYos/" + id);
        }
    }
}
