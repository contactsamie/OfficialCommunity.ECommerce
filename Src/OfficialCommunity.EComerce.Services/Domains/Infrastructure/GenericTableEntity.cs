using Microsoft.WindowsAzure.Storage.Table;

namespace OfficialCommunity.ECommerce.Services.Domains.Infrastructure
{
    public class GenericTableEntity<T> : TableEntity
    {
        public GenericTableEntity(string domain, string key, T value)
        {
            PartitionKey = domain;
            RowKey = key;
            Value = value;
        }

        public GenericTableEntity(string domain, string key)
        {
            PartitionKey = domain;
            RowKey = key;
        }

        public GenericTableEntity()
        {
        }

        public T Value { get; set; }
    }
}
