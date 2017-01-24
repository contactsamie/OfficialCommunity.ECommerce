using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ForumsPost
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int CustomerId { get; set; }
        public string Text { get; set; }
        public string Ipaddress { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ForumsTopic Topic { get; set; }
    }
}
