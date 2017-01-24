﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class AclRecord
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public int CustomerRoleId { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }
    }
}
