﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nuvango.Extensions;
using OfficialCommunity.Necropolis.Exceptions;
using RestSharp;
using RestSharp.Deserializers;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public class Session : ISession
    {
        private readonly ILogger _logger;
        private readonly string _token;
        private readonly IRestClient _client;
        private readonly IDeserializer _jsonDeserializer;

        public Session(ILogger logger, Configuration configuration)
        {
            _logger = logger;

            var endpoint = configuration.EndPoint;
            if (endpoint.Last() == '/')
                endpoint = endpoint.Remove(endpoint.Length - 1, 1);

            _token = configuration.Token;

            _client = new RestClient(endpoint);

            _jsonDeserializer = new JsonDeserializer();
        }

        public async Task<T> ExecuteAsync<T>(string context, IRestRequest request) where T : class
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            _client.ExecuteAsync(request, response =>
            {
                if (response.IsSuccessful())
                {
                    try
                    {
                        var t = _jsonDeserializer.Deserialize<T>(response);
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
                    catch (Exception e)
                    {
                        taskCompletionSource.SetException(new ContextException($"Unable to deserialize response for {context}"
                                                                                , e
                                                                                , new
                                                                                {
                                                                                    _client.BaseUrl,
                                                                                    request.Resource,
                                                                                    Json = response.Content
                                                                                }));
                    }
                }
                else if (response.ErrorException != null)
                {
                    taskCompletionSource.SetException(new ContextException($"Unable to {context}"
                                                                            , response.ErrorException
                                                                            , new
                                                                            {
                                                                                _client.BaseUrl,
                                                                                request.Resource,
                                                                                response.StatusCode,
                                                                                response.StatusDescription
                                                                            }));
                }
                else
                {
                    taskCompletionSource.SetException(new ContextException($"Unable to {context}"
                                                                            , new
                                                                            {
                                                                                _client.BaseUrl,
                                                                                request.Resource,
                                                                                response.StatusCode,
                                                                                response.StatusDescription
                                                                            }));
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

        public async Task<T> PostAsync<T, TR>(string api, TR request)
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
