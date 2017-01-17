using System;
using System.Collections.Generic;
using System.Text;

namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class Order : Base
    {
        public DateTime TimeStampUtc { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public decimal Tax { get; set; }
        public decimal SubtotalPrice { get; set; }
        public decimal Discounts { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
