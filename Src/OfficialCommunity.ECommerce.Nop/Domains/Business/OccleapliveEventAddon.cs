using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccleapliveEventAddon
    {
        public int Id { get; set; }
        public Guid LiveEventAddonGuid { get; set; }
        public string LeapliveEventId { get; set; }
        public int AddonProductId { get; set; }

        public virtual OccleapaddonProduct AddonProduct { get; set; }
    }
}
