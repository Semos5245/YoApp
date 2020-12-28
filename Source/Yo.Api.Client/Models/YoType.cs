using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using Yo.Api.Client.ResponseModels;
using Yo.Api.Client.Services;
using Yo.Models;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.Models
{
    public class YoType
    {
        private static readonly YoService service = new YoService();

        public static async Task<Response> DeleteYoAsync(string id)
        {
            return await service.DeleteYoAsync(id);
        }

        public static async Task<Response> SendYoAsync(string yoerId, string yoedId, bool isYoLocation)
        {
            return await service.SendYoAsync(new SendYoViewModel(yoerId, yoedId, isYoLocation));
        }

        public static async Task<Response> MakeYosRecieved(string yoedId)
        {
            return await service.MakeYosRecieved(yoedId);
        }

        public static async Task<YoResponse> GetYosAsync(string id)
        {
            return await service.GetYosAsnyc(id);
        }
    }
}
