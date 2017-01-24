using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class CustomerRole
    {
        public CustomerRole()
        {
            AclRecord = new HashSet<AclRecord>();
            CustomerCustomerRoleMapping = new HashSet<CustomerCustomerRoleMapping>();
            PermissionRecordRoleMapping = new HashSet<PermissionRecordRoleMapping>();
            TierPrice = new HashSet<TierPrice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string SystemName { get; set; }

        public virtual ICollection<AclRecord> AclRecord { get; set; }
        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMapping { get; set; }
        public virtual ICollection<PermissionRecordRoleMapping> PermissionRecordRoleMapping { get; set; }
        public virtual ICollection<TierPrice> TierPrice { get; set; }
    }
}
