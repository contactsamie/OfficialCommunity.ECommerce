using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Table;
using Nito.AsyncEx;
using OfficialCommunity.ECommerce.Services.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Exceptions;
using OfficialCommunity.Necropolis.Extensions;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public abstract class TableEntityService<TC>
        where TC : TableEntityService<TC>.Configuration, new()
    {
        public class Configuration
        {
            public string ConnectionString { get; set; }
            public string TableName { get; set; }
            public int MaximumExecutionTimeSeconds { get; set; }
            public int LinearRetryInMilliseconds { get; set; }
            public int MaximumAttempts { get; set; }
        }

        protected class Session
        {
            private CloudStorageAccount StorageAccount { get; set; }
            private CloudTableClient TableClient { get; set; }
            private CloudTable Table { get; set; }

            public async Task Build(Configuration configuration)
            {
                StorageAccount = CloudStorageAccount.Parse(configuration.ConnectionString);
                TableClient = StorageAccount.CreateCloudTableClient();

                var requestOption = new TableRequestOptions
                {
                    RetryPolicy = new LinearRetry(TimeSpan.FromMilliseconds(configuration.LinearRetryInMilliseconds)
                                                                            , configuration.MaximumAttempts),
                    // For Read-access geo-redundant storage, use PrimaryThenSecondary.
                    // Otherwise set this to PrimaryOnly.
                    LocationMode = LocationMode.PrimaryThenSecondary,
                    // Maximum execution time based on the business use case. Maximum value up to 10 seconds.
                    MaximumExecutionTime = TimeSpan.FromSeconds(configuration.MaximumExecutionTimeSeconds)
                };

                TableClient.DefaultRequestOptions = requestOption;

                Table = TableClient.GetTableReference(configuration.TableName);

                await Table.CreateIfNotExistsAsync();
            }

            public async Task<TableResult> ExecuteAsync(TableOperation operation)
            {
                return await Table.ExecuteAsync(operation);
            }
        }

        private readonly AsyncLazy<Session> _session;

        protected TableEntityService(IOptions<TC> configuration)
        {
            var configuration1 = configuration.Value;
            _session = new AsyncLazy<Session>(async () =>
            {
                var session = new Session();
                await session.Build(configuration1);
                return session;
            });
        }

        protected async Task<StandardResponse<bool>> Create<T>(string partition, string row, T value)
        {
            try
            {
                var session = await _session;

                var entity = new GenericTableEntity<T>(partition, row, value);

                var operation = TableOperation.Insert(entity);

                var tableResult = await session.ExecuteAsync(operation);

                return CheckResult(tableResult, true);
            }
            catch (Exception e)
            {
                throw new ContextException("Unable to Create"
                    , e
                    , new
                    {
                        PartitionKey = partition,
                        RowKey = row,
                        Value = value
                    });
            }
        }

        protected async Task<StandardResponse<T>> Read<T>(string partition, string row)
        {
            try
            {
                var session = await _session;

                var operation = TableOperation.Retrieve<GenericTableEntity<T>>(partition, row);

                var tableResult = await session.ExecuteAsync(operation);

                return CheckResult<T>(tableResult);
            }
            catch (WebException webEx)
            {
                var status = (webEx.Response as HttpWebResponse)?.StatusCode;

                if (status.HasValue && status.Value == HttpStatusCode.NotFound)
                {
                    var @null = default(T);
                    return @null.GenerateStandardResponse();
                }

                throw new ContextException("Unable to Read"
                    , webEx
                    , new
                    {
                        PartitionKey = partition,
                        RowKey = row,
                    });
            }
            catch (Exception e)
            {
                throw new ContextException("Unable to Read"
                    , e
                    , new
                    {
                        PartitionKey = partition,
                        RowKey = row
                    });
            }
        }

        protected async Task<StandardResponse<T>> InsertOrMerge<T>(string key, string row, T value)
        {
            try
            {
                var session = await _session;

                var entity = new GenericTableEntity<T>(key, row, value);

                var operation = TableOperation.InsertOrMerge(entity);

                var tableResult = await session.ExecuteAsync(operation);

                return CheckResult<T>(tableResult);
            }
            catch (Exception e)
            {
                throw new ContextException("Unable to InsertOrMerge"
                    , e
                    , new
                    {
                        PartitionKey = key,
                        RowKey = row,
                        Value = value
                    });
            }
        }

        protected async Task<StandardResponse<T>> InsertOrReplace<T>(string key, string row, T value)
        {
            try
            {
                var session = await _session;

                var entity = new GenericTableEntity<T>(key, row, value);

                var operation = TableOperation.InsertOrReplace(entity);

                var tableResult = await session.ExecuteAsync(operation);

                return CheckResult<T>(tableResult);
            }
            catch (Exception e)
            {
                throw new ContextException("Unable to InsertOrReplace"
                    , e
                    , new
                    {
                        PartitionKey = key,
                        RowKey = row,
                        Value = value
                    });
            }
        }

        protected async Task<StandardResponse<bool>> Delete<T>(string key, string row)
        {
            try
            {
                var session = await _session;

                var entity = new GenericTableEntity<T>(key, row)
                {
                    ETag = "*" // Required for deletes, or throws exception
                };

                var operation = TableOperation.Delete(entity);

                var tableResult = await session.ExecuteAsync(operation);

                return CheckResult(tableResult, true);
            }
            catch (WebException webEx)
            {
                var status = (webEx.Response as HttpWebResponse)?.StatusCode;

                if (status.HasValue && status.Value == HttpStatusCode.NotFound)
                {
                    return false.GenerateStandardResponse();
                }

                throw new ContextException("Unable to Delete"
                    , webEx
                    , new
                    {
                        PartitionKey = key,
                        RowKey = row,
                    });
            }
            catch (Exception e)
            {
                throw new ContextException("Unable to Delete"
                    , e
                    , new
                    {
                        PartitionKey = key,
                        RowKey = row,
                    });
            }
        }

        private static bool IsSuccessStatusCode(int statusCode)
        {
            return (statusCode >= 200) && (statusCode <= 299);
        }

        private static StandardResponse<bool> CheckResult(TableResult result, bool expectResult = false)
        {
            if (result == null)
                return false.GenerateStandardError("TableResult == null");

            if (!IsSuccessStatusCode(result.HttpStatusCode))
                return false.GenerateStandardError($"HttpStatusCode == {result.HttpStatusCode}");

            if (expectResult && result.Result == null)
            {
                return false.GenerateStandardError("Expecting TableResult.Result but == null");
            }

            return true.GenerateStandardResponse();
        }

        private static StandardResponse<T> CheckResult<T>(TableResult result)
        {
            var error = default(T);

            if (result == null)
                return error.GenerateStandardError("TableResult == null");

            if (!IsSuccessStatusCode(result.HttpStatusCode))
                return error.GenerateStandardError($"HttpStatusCode == {result.HttpStatusCode}");

            if (result.Result == null)
            {
                return error.GenerateStandardError("Expecting TableResult.Result but == null");
            }

            var entity = (GenericTableEntity<T>)result.Result;

            return entity == null ? error.GenerateStandardError("TableResult.Result not of expected Type")
                : entity.Value.GenerateStandardResponse();
        }
    }
}
