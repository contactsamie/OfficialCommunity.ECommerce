using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class BlogComment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CommentText { get; set; }
        public int BlogPostId { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
