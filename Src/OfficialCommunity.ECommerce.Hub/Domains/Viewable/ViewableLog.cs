using System;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    public class ViewableLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
 }
}
