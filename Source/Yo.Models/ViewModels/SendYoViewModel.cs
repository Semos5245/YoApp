using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class SendYoViewModel
    {
        public string YoerId { get; set; }

        public string YoedId { get; set; }

        public bool IsYoLocation { get; set; }

        public SendYoViewModel(string yoerId, string yoedId, bool isYoLocation)
        {
            this.YoerId = yoerId;
            this.YoedId = yoedId;
            this.IsYoLocation = isYoLocation;
        }
    }
}