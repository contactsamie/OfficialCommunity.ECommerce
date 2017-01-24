using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public int NewsItemId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual News NewsItem { get; set; }
    }
}
