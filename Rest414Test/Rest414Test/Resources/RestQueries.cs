using Rest414Test.Dto;
using RestSharp.Serialization.Json;
using System;

namespace Rest414Test.Resources
{
    public class RestQueries<TGET, TPOST, TPUT, TDELETE> : RestCrud
    {
        private const string ConvertObjectError = "ConvertToObject Error. {0}\n{1}";
        
        private JsonDeserializer deserial;

        public RestQueries(RestUrl restUrl) : base(restUrl)
        {
            deserial = new JsonDeserializer();
        }

        // Entity - - - - - - - - - - - - - - - - - - - -

        public virtual TGET HttpGetAsObject(RestParameters urlParameters, RestParameters pathVariables)
        {
            TGET result = default(TGET);
            try
            {
                result = deserial.Deserialize<TGET>(HttpGetAsResponse(urlParameters, pathVariables));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
            }
            return result;
        }

        public virtual TPOST HttpPostAsObject(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            TPOST result = default(TPOST);
            try
            {
                result = deserial.Deserialize<TPOST>(HttpPostAsResponse(urlParameters, pathVariables, bodyParameters));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
            }
            return result;
        }

        public virtual TPUT HttpPutAsObject(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            TPUT result = default(TPUT);
            try
            {
                result = deserial.Deserialize<TPUT>(HttpPutAsResponse(urlParameters, pathVariables, bodyParameters));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
            }
            return result;
        }

        public virtual TDELETE HttpDeleteAsObject(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            TDELETE result = default(TDELETE);
            try
            {
                result = deserial.Deserialize<TDELETE>(HttpDeleteAsResponse(urlParameters, pathVariables, bodyParameters));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(ConvertObjectError, ex.Message, ex.StackTrace));
            }
            return result;
        }
    }
}
