using System;
using System.Collections.Generic;

namespace Rest414Test.Dto
{
    public class RestParameters
    {
        public Dictionary<string, string> Parameters { get; private set; }

        public RestParameters()
        {
            Parameters = new Dictionary<string, string>();
        }

        private static string GetParamKey(RestParametersKeys key)
        {
            string result = null;
            Dictionary<RestParametersKeys, string> paramKeys = new Dictionary<RestParametersKeys, string>();
            paramKeys.Add(RestParametersKeys.Token, "token");
            paramKeys.Add(RestParametersKeys.Name, "name");
            paramKeys.Add(RestParametersKeys.Password, "password");
            paramKeys.Add(RestParametersKeys.Rights, "rights");
            paramKeys.Add(RestParametersKeys.Index, "index");
            paramKeys.Add(RestParametersKeys.Time, "time");
            paramKeys.Add(RestParametersKeys.Item, "item");
            paramKeys.Add(RestParametersKeys.OldPassword, "oldpassword");
            paramKeys.Add(RestParametersKeys.NewPassword, "newpassword");
            result = paramKeys[key];
            if (result == null)
            {
                throw new Exception("Key not found.");
            }
            return result;
        }

        public RestParameters AddParameters(RestParametersKeys key, string url)
        {
            string stringKey = GetParamKey(key);
            Parameters.Add(stringKey, url);
            return this;
        }

        public string GetParameters(RestParametersKeys key)
        {
            string stringKey = GetParamKey(key);
            return Parameters[stringKey];
        }
    }
}
