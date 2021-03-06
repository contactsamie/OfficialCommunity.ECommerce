﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Discount
    {
        public Discount()
        {
            DiscountAppliedToCategories = new HashSet<DiscountAppliedToCategories>();
            DiscountAppliedToProducts = new HashSet<DiscountAppliedToProducts>();
            DiscountRequirement = new HashSet<DiscountRequirement>();
            DiscountUsageHistory = new HashSet<DiscountUsageHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountTypeId { get; set; }
        public bool UsePercentage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }
        public int DiscountLimitationId { get; set; }
        public int LimitationTimes { get; set; }

        public virtual ICollection<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public virtual ICollection<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public virtual ICollection<DiscountRequirement> DiscountRequirement { get; set; }
        public virtual ICollection<DiscountUsageHistory> DiscountUsageHistory { get; set; }
    }
}
