using System;

namespace OfficialCommunity.Necropolis.DocumentDB.Domains.Configuration
{
    public class DocumentDbConfiguration
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public Uri DatabaseUri { get; set; }
        public string DatabaseKey { get; set; }
    }
}
