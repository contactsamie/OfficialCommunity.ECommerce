using System;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    public class ViewableOperation : ViewableBase
    {
        public string Level { get; set; }
        public string Message { get; set; }
        public Guid? ExternalCorrelationId { get; set; }
        public Guid? InternalCorrelationId { get; set; }
    }
}