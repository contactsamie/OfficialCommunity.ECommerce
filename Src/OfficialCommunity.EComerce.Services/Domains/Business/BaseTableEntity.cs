using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Services.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Business
{
    [Serializable]
    public abstract class BaseTableEntity : TableEntity, IBaseTableEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }

        [JsonProperty(PropertyName = "created_utc")]
        public DateTime CreatedUtc { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "lastupdated_utc")]
        public DateTime LastUpdatedUtc { get; set; }

        [JsonProperty(PropertyName = "lastupdated_by")]
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
        [EntityPropertyConverter(typeof(Dictionary<string, string>))]
        public Dictionary<string, string> ProviderConfiguration { get; set; }

        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var results = base.WriteEntity(operationContext);
            EntityPropertyConvert.Serialize(this, results);
            return results;
        }

        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            base.ReadEntity(properties, operationContext);
            EntityPropertyConvert.DeSerialize(this, properties);
        }
    }
}