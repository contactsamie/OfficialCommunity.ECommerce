using System;
using System.ComponentModel.DataAnnotations;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    public class Log
    {
        [Required]
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        [MaxLength(128)]
        public string Level { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }

    }
}