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
        public List<string> Catalogs { get; set; }
    }
}
