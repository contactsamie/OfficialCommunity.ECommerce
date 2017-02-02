using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    [Serializable]
    public abstract class BaseTableEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }

        [JsonProperty(PropertyName = "createdutc")]
        public DateTime CreatedUtc { get; set; }

        [JsonProperty(PropertyName = "createdby")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "lastupdatedutc")]
        public DateTime LastUpdatedUtc { get; set; }

        [JsonProperty(PropertyName = "lastupdatedutc")]
        public string LastUpdatedBy { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty(PropertyName = "provider_key")]
        public string ProviderKey { get; set; }

        [JsonProperty(PropertyName = "provider_configuration")]
        public Dictionary<string, string> ProviderConfiguration { get; set; }
    }

    [Serializable]
    public class CatalogTableEntity : BaseTableEntity
    {
    }

    [Serializable]
    public class StoreTableEntity : BaseTableEntity
    {
        [JsonProperty(PropertyName = "catalogs")]
        public List<string> Catalogs { get; set; }
    }
}
