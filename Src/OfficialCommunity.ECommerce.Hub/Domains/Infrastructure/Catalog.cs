using System.Collections.Generic;
using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    public class Catalog
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty(PropertyName = "provider_key")]
        public string ProviderKey { get; set; }

        [JsonProperty(PropertyName = "provider_configuration")]
        public Dictionary<string,string> ProviderConfiguration { get; set; }
    }
}
