using System.Collections.Generic;
using Yo.Models;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.ResponseModels
{
    public class UserResponse : Response
    {
        public UserViewModel User { get; set; }
        
        public IEnumerable<UserViewModel> Users { get; set; }

    }
}
