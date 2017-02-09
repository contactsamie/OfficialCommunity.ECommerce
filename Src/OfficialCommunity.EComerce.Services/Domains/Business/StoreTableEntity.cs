using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Services.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Business
{
    [Serializable]
    public class StoreTableEntity : BaseTableEntity
    {
        [EntityPropertyConverter(typeof(Dictionary<string, string>))]
        [JsonProperty(PropertyName = "catalogs")]
        public Dictionary<Guid, string> Catalogs { get; set; }

    }
}
