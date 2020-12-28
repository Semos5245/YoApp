using System.Collections.Generic;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.ResponseModels
{
    public class YoResponse : Response
    {
        public IEnumerable<YoViewModel> Yos { get; set; }
    }
}
