using NLog;
using System;

namespace Rest414Test.Services
{
    public class BaseService
    {
        public Logger logger = LogManager.GetCurrentClassLogger();

        private const string NotSupportService = "Service {0} Error. {1}";
        public const string ParamTrue = "true";
        public const string ParamFalse = "false";

        public BaseService()
        {
        }

        protected void CheckService(bool condition, string message)
        {
            if (condition)
            {
                string serviceName = this.GetType().ToString();
                throw new Exception(string.Format(NotSupportService, serviceName, message));
            }
        }
    }
}
