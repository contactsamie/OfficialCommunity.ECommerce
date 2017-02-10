using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Services.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Business
{
    [Serializable]
    public class StoreTableEntity : BaseTableEntity
    {
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [EntityPropertyConverter(typeof(Dictionary<string, string>))]
        [JsonProperty(PropertyName = "catalogs")]
        public Dictionary<Guid, string> Catalogs { get; set; }

    }
}
