﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ReturnRequest
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int OrderItemId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public string ReasonForReturn { get; set; }
        public string RequestedAction { get; set; }
        public string CustomerComments { get; set; }
        public string StaffNotes { get; set; }
        public int ReturnRequestStatusId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
    }
}