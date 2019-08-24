using System.Collections.Generic;

namespace Rest414Test.Dto
{
    public class RestUrl
    {
        private Dictionary<RestUrlKeys, string> urls;

        public RestUrl()
        {
            urls = new Dictionary<RestUrlKeys, string>();
        }

        public RestUrl AddUrl(RestUrlKeys key, string url)
        {
            urls.Add(key, url);
            return this;
        }

        public string GetUrl(RestUrlKeys key)
        {
            return urls[key];
        }

        public RestUrl AddBaseUrl(string url)
        {
            urls.Add(RestUrlKeys.BASE, url);
            return this;
        }

        public RestUrl AddGetUrl(string url)
        {
            urls.Add(RestUrlKeys.GET, url);
            return this;
        }

        public RestUrl AddPostUrl(string url)
        {
            urls.Add(RestUrlKeys.POST, url);
            return this;
        }

        public RestUrl AddPutUrl(string url)
        {
            urls.Add(RestUrlKeys.PUT, url);
            return this;
        }

        public RestUrl AddDeleteUrl(string url)
        {
            urls.Add(RestUrlKeys.DELETE, url);
            return this;
        }

        public string ReadBaseUrl()
        {
            return urls[RestUrlKeys.BASE];
        }

        public string ReadGetUrl()
        {
            return urls[RestUrlKeys.GET];
        }

        public string ReadPostUrl()
        {
            return urls[RestUrlKeys.POST];
        }

        public string ReadPutUrl()
        {
            return urls[RestUrlKeys.PUT];
        }

        public string ReadDeleteUrl()
        {
            return urls[RestUrlKeys.DELETE];
        }
    }
}
