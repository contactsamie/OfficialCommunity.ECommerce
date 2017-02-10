using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Hub.Domains.Editable
{
    public class EditableStoreTableEntity : EditableTableEntity
    {
        public string Secret { get; set; }
        public string Token { get; set; }
        public List<EditableStoreCatalog> Catalogs { get; set; }
    }
}