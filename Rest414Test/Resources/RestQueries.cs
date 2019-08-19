using Rest414Test.Dto;
using Rest414Test.Entity;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Resources
{
    public class RestQueries<TGET, TPOST, TPUT, TDELETE> : RestCrud
    {
        private const string NOT_SUPPORT_MESSAGE = "Method {0} not Support for {1} Resource";
        private const string CONVERT_OBJECT_ERROR = "ConvertToObject Error. {0}\n{1}";
        //
        private JsonDeserializer deserial;

        public RestQueries(RestUrl restUrl) : base(restUrl)
        {
            deserial = new JsonDeserializer();
        }

        protected void ThrowException(string message)
        {
            // TODO Develop Custom Exception
            string resourceName = this.GetType().ToString();
            throw new Exception(string.Format(NOT_SUPPORT_MESSAGE, message, resourceName));
        }

        // Entity - - - - - - - - - - - - - - - - - - - -

        public virtual TGET HttpGetAsObject(RestParameters urlParameters, RestParameters pathVariables)
        {
            TGET result = default(TGET); // Running from T Default Constructor
            try
            {
                result = deserial.Deserialize<TGET>(HttpGetAsResponse(urlParameters, pathVariables));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
            }
            return result;
        }

        public virtual TPOST HttpPostAsObject(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            TPOST result = default(TPOST); // Running from T Default Constructor
            try
            {
                result = deserial.Deserialize<TPOST>(HttpPostAsResponse(urlParameters, pathVariables, bodyParameters));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
            }
            return result;
        }

        public virtual TPUT HttpPutAsObject(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            TPUT result = default(TPUT); // Running from T Default Constructor
            try
            {
                result = deserial.Deserialize<TPUT>(HttpPutAsResponse(urlParameters, pathVariables, bodyParameters));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
            }
            return result;
        }

        public virtual TDELETE HttpDeleteAsObject(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            TDELETE result = default(TDELETE); // Running from T Default Constructor
            try
            {
                result = deserial.Deserialize<TDELETE>(HttpDeleteAsResponse(urlParameters, pathVariables, bodyParameters));
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
                //
                // TODO Develop Custom Exception
                throw new Exception(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
            }
            return result;
        }

        // List Entity - - - - - - - - - - - - - - - - - - - -

        // TODO
        //public virtual IList<TGET> HttpGetAsObject(RestParameters urlParameters, RestParameters pathVariables)
        //public virtual TPOST HttpPostAsObject(RestParameters urlParameters,
        //    RestParameters pathVariables, RestParameters bodyParameters)
        //public virtual TPUT HttpPutAsObject(RestParameters urlParameters,
        //    RestParameters pathVariables, RestParameters bodyParameters)
        //public virtual IList<TDELETE> HttpDeleteAsObject(RestParameters urlParameters,
        //    RestParameters pathVariables, RestParameters bodyParameters)

    }
}
