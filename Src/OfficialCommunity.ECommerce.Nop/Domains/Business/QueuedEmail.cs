using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class QueuedEmail
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string ToName { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int SentTries { get; set; }
        public DateTime? SentOnUtc { get; set; }
        public int EmailAccountId { get; set; }

        public virtual EmailAccount EmailAccount { get; set; }
    }
}
