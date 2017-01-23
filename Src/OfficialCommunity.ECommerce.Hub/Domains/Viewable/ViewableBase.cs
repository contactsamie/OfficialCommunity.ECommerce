using System;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    public abstract class ViewableBase
    {
        protected ViewableBase()
        {
            
        }

        public Guid Id { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public string MachineName { get; set; }
    }
}