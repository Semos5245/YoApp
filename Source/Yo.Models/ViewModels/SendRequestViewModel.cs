using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yo.Models.ViewModels
{
    public class SendRequestViewModel
    {
        public string RequesterId { get; set; }

        public string ReceiverId { get; set; }

        public SendRequestViewModel(string requesterId, string receiverId)
        {
            this.RequesterId = requesterId;
            this.ReceiverId = receiverId;
        }
    }
}