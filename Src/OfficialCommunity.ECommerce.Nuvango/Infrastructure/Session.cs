using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Exceptions;
using RestSharp;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public class Session : ISession
    {
        private readonly ILogger _logger;
        private readonly string _endpoint;
        private readonly string _token;
        private readonly IRestClient _client;

        public Session(ILogger logger, Configuration configuration)
        {
            _logger = logger;

            _endpoint = configuration.EndPoint;
            if (_endpoint.Last() == '/')
                _endpoint.Remove(_endpoint.Length - 1, 1); 

            _token = configuration.Token;

            _client = new RestClient(_endpoint);

        }

        public async Task<T> ExecuteAsync<T>(string context, IRestRequest request) where T : class
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            _client.ExecuteAsync(request, response =>
            {
                if (response.ErrorException != null)
                {
                    taskCompletionSource.SetException(new ContextException($"Unable to {context}"
                                                                            , response.ErrorException
                                                                            , new
                                                                            {
                                                                                _client.BaseUrl,
                                                                                request.Resource
                                                                            }));
                }
                else
                {
                    var t = JsonConvert.DeserializeObject<T>(response.Content);
                    if (t != null)
                        taskCompletionSource.SetResult(t);
                    else
                    {
                        taskCompletionSource.SetException(new ContextException($"Unable to deserialize response for {context}"
                                                                                , response.ErrorException
                                                                                , new
                                                                                {
                                                                                    _client.BaseUrl,
                                                                                    request.Resource,
                                                                                    Json = response.Content
                                                                                }));

                    }
                }
            });

            return await taskCompletionSource.Task;
        }

        public async Task<T> GetAsync<T>(string api) where T : class
        {
            var url = $"{api}&token={_token}";

            var restRequest = new RestRequest(url, Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; },
                RequestFormat = DataFormat.Json
            };

            return await ExecuteAsync<T>("GetAsync", restRequest);
       }

        public async Task<T> PostAsync<T, TR>(HttpClient client, string api, TR request)
            where T : class
            where TR : class
        {
            var url = $"{api}&token={_token}";

            var restRequest = new RestRequest(url, Method.POST)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; },
                RequestFormat = DataFormat.Json
            };

            restRequest.AddBody(request);

            return await ExecuteAsync<T>("PostAsync", restRequest);
        }
    }
}
