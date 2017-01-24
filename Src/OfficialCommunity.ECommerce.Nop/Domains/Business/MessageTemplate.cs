using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class MessageTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BccEmailAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
        public int EmailAccountId { get; set; }
        public bool LimitedToStores { get; set; }
    }
}
