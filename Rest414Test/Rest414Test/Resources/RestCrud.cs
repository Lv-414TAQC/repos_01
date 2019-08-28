using NLog;
using Rest414Test.Dto;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Rest414Test.Resources
{
    public abstract class RestCrud
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        private const string NotSupportMessage = "Method {0} not Support for {1} Resource";
        
        private const string UrlParametersSeparator = "?";
        private const string NextParametersSeparator = "&";
        private const string KeyValueSeparator = "=";
        
        private RestUrl restUrl;
        private RestClient client;
        private Dictionary<RestUrlKeys, RestSharp.Method> dictionaryMethods;

        public RestCrud(RestUrl restUrl)
        {
            this.restUrl = restUrl;
            client = new RestClient(restUrl.ReadBaseUrl());
            InitDictionaryMethods();
        }

        private void InitDictionaryMethods()
        {
            dictionaryMethods = new Dictionary<RestUrlKeys, RestSharp.Method>();
            dictionaryMethods.Add(RestUrlKeys.GET, Method.GET);
            dictionaryMethods.Add(RestUrlKeys.POST, Method.POST);
            dictionaryMethods.Add(RestUrlKeys.PUT, Method.PUT);
            dictionaryMethods.Add(RestUrlKeys.DELETE, Method.DELETE);
        }

        // protected - - - - - - - - - - - - - - - - - - - -

        protected void ThrowException(string message)
        {
            string resourceName = this.GetType().ToString();
            throw new Exception(string.Format(NotSupportMessage, message, resourceName));
        }

        protected void CheckImplementation(RestUrlKeys restUrlKeys)
        {
            if (string.IsNullOrEmpty(restUrl.GetUrl(restUrlKeys)))
            {
                ThrowException(restUrlKeys.ToString());
            }
        }

        // private - - - - - - - - - - - - - - - - - - - -

        private string PrepareUrlParameters(string urlTemplate, RestParameters urlParameters)
        {
            if (urlParameters != null)
            {
                bool isFirstParameter = true;
                foreach (KeyValuePair<string, string> current in urlParameters.Parameters)
                {
                    //logger.Info("urlParameters: key = " + current.Key + " value = " + current.Value);
                    if (isFirstParameter)
                    {
                        urlTemplate = urlTemplate + UrlParametersSeparator;
                        isFirstParameter = false;
                    }
                    else
                    {
                        urlTemplate = urlTemplate + NextParametersSeparator;
                    }
                    urlTemplate = urlTemplate + current.Key + KeyValueSeparator + current.Value;
                }
            }
            return urlTemplate;
        }

        private RestRequest PreparePathVariables(RestRequest request, RestParameters pathVariables)
        {
            if (pathVariables != null)
            {
                foreach (KeyValuePair<string, string> current in pathVariables.Parameters)
                {
                    request.AddUrlSegment(current.Key, current.Value);
                }
            }
            return request;
        }

        private RestRequest prepareRequestBody(RestRequest request, RestParameters bodyParameters)
        {
            if (bodyParameters != null)
            {
                foreach (KeyValuePair<string, string> current in bodyParameters.Parameters)
                {
                    request.AddParameter(current.Key, current.Value);
                }
            }
            return request;
        }

        private RestRequest CreateRestRequest(RestUrlKeys restUrlKeys, RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            CheckImplementation(restUrlKeys);
            string url = PrepareUrlParameters(restUrl.ReadBaseUrl() + restUrl.GetUrl(restUrlKeys), urlParameters);
            RestRequest request = new RestRequest(url, dictionaryMethods[restUrlKeys]);
            request = PreparePathVariables(request, pathVariables);
            request = prepareRequestBody(request, bodyParameters);
            return request;
        }

        private IRestResponse ExecuteRequest(RestRequest request)
        {
            return client.Execute(request);
        }

        // Http Get - - - - - - - - - - - - - - - - - - - -

        protected IRestResponse HttpGetAsResponse(RestParameters urlParameters, RestParameters pathVariables)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.GET, urlParameters, pathVariables, null));
        }

        protected string HttpGetAsString(RestParameters urlParameters, RestParameters pathVariables)
        {
            return HttpGetAsResponse(urlParameters, pathVariables).Content;
        }

        // Http Post - - - - - - - - - - - - - - - - - - - -

        protected IRestResponse HttpPostAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.POST, urlParameters, pathVariables, bodyParameters));
        }

        protected string HttpPostAsString(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return HttpPostAsResponse(urlParameters, pathVariables, bodyParameters).Content;
        }

        // Http Put - - - - - - - - - - - - - - - - - - - -

        protected IRestResponse HttpPutAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.PUT, urlParameters, pathVariables, bodyParameters));
        }

        protected string HttpPutAsString(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return HttpPutAsResponse(urlParameters, pathVariables, bodyParameters).Content;
        }

        // Http Delete - - - - - - - - - - - - - - - - - - - -

        protected IRestResponse HttpDeleteAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.DELETE, urlParameters, pathVariables, bodyParameters));
        }

        protected string HttpDeleteAsString(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return HttpDeleteAsResponse(urlParameters, pathVariables, bodyParameters).Content;
        }
    }
}
