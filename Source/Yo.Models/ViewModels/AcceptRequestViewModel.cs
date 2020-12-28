using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class AcceptRequestViewModel
    {
        public string AccepterId { get; set; }

        public string RequesterId { get; set; }

        public AcceptRequestViewModel(string accepterId, string requesterId)
        {
            this.AccepterId = accepterId;
            this.RequesterId = requesterId;
        }
    }
}