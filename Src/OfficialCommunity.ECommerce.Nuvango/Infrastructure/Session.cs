﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Nuvango.Extensions;
using OfficialCommunity.ECommerce.Nuvango.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Exceptions;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;
using RestSharp;
using RestSharp.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public class Session : ISession
    {
        private readonly ILogger<Session> _logger;
        private string _token;
        private IRestClient _client;

        public Session(ILogger<Session> logger)
        {
            _logger = logger;
        }

        public IStandardResponse<bool> Configure(string passport, NuvangoService.Configuration configuration)
        {
            var entry = EntryContext.Capture
                                        .Passport(passport)
                                        .Name(nameof(Configure))
                                        .Data(nameof(configuration.EndPoint), configuration.EndPoint)
                                        .EntryContext
                                    ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var endpoint = configuration.EndPoint;
                    if (endpoint.Last() == '/')
                        endpoint = endpoint.Remove(endpoint.Length - 1, 1);

                    _token = configuration.Token;
                    _client = new RestClient(endpoint);

                    return true.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, nameof(Configure));
                    return false.GenerateStandardError(nameof(Configure));
                }
            }
        }

        private async Task<T> ExecuteAsync<T>(string context, IRestRequest request, Func<string,T> deserializer = null) where T : class
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            _client.ExecuteAsync(request, response =>
            {
                if (response.IsSuccessful())
                {
                    try
                    {
                        var t = deserializer == null ? JsonConvert.DeserializeObject<T>(response.Content) : deserializer(response.Content);
                        if (t != null)
                            taskCompletionSource.SetResult(t);
                        else
                        {
                            taskCompletionSource.SetException(new ContextException($"Unable to deserialize response for {context}"
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

        private async Task<bool> ExecutePostAsync(string context, IRestRequest request) 
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            _client.ExecuteAsync(request, response =>
            {
                if (response.IsSuccessful())
                {
                    taskCompletionSource.SetResult(true);
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

        public async Task<T> GetAsync<T>(string api, Func<string, T> deserializer = null) where T : class
        {
            var url = api.Contains("?") ? $"api/{api}&token={_token}" : $"api/{api}?token={_token}"; 

            var restRequest = new RestRequest(url, Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; },
                RequestFormat = DataFormat.Json,
                JsonSerializer = new NewtonsoftJsonSerializer()
            };

            return await ExecuteAsync<T>("GetAsync", restRequest, deserializer);
        }

        public async Task<T> PostAsync<T, TR>(string api, TR request, Func<string, T> deserializer = null)
            where T : class
            where TR : class
        {
            var url = api.Contains("?") ? $"api/{api}&token={_token}" : $"api/{api}?token={_token}"; 

            var restRequest = new RestRequest(url, Method.POST)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; },
                RequestFormat = DataFormat.Json,
                JsonSerializer = new NewtonsoftJsonSerializer()
            };

            restRequest.AddBody(request);

            return await ExecuteAsync<T>("PostAsync", restRequest, deserializer);
        }

        public async Task<bool> PostAsync<TR>(string api, TR request)
            where TR : class
        {
            var url = api.Contains("?") ? $"api/{api}&token={_token}" : $"api/{api}?token={_token}";

            var restRequest = new RestRequest(url, Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new NewtonsoftJsonSerializer()
            };

            restRequest.AddBody(request);

            return await ExecutePostAsync("PostAsyncNoResponseBody", restRequest);
        }
    }
}
