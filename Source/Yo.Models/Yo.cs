using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yo.Models
{
    public class Yo
    {
        [Key]
        public string YoId { get; set; }

        public bool IsSeen { get; set; }

        public bool IsReceived { get; set; }

        public bool IsYoLocation { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public DateTime YoDate { get; set; }

        //Relations with other tables

        [Required]
        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }

        [ForeignKey("FromUser")]
        public string FromId { get; set; }

        [ForeignKey("ToUser")]
        public string ToId { get; set; }
        
    }
}
