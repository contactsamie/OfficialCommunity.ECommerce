namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class Store : Base
    {
        // Which IStoreProvider

        public string Provider { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}