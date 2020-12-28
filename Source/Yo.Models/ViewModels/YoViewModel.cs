using System;
using System.ComponentModel.DataAnnotations;

namespace Yo.Models.ViewModels
{
    public class YoViewModel
    {
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool IsYoLocation { get; set; }

        public DateTime YoDate { get; set; }

        public UserViewModel FromUser { get; set; }
    }
}
