using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Hub.Domains.Editable
{
    public class EditableCatalog
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public string ProviderKey { get; set; }

        public List<EditableConfiguration> ProviderConfiguration { get; set; }
    }
}
