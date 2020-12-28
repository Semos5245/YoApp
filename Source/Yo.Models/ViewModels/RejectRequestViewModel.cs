using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class RejectRequestViewModel
    {
        public string RejecterId { get; set; }

        public string RequesterId { get; set; }

        public RejectRequestViewModel(string rejecterId, string requesterId)
        {
            this.RejecterId = rejecterId;
            this.RequesterId = requesterId;
        }
    }
}