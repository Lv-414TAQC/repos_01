using NLog;
using System;

namespace Rest414Test.Services
{
    public class BaseService
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        private const string NOT_SUPPORT_SERVICE = "Service {0} Error. {1}";

        public BaseService()
        {
        }

        protected void CheckService(bool condition, string message)
        {
            if (condition)
            {
                // TODO Develop Custom Exception
                string serviceName = this.GetType().ToString();
                throw new Exception(string.Format(NOT_SUPPORT_SERVICE, serviceName, message));
            }
        }
    }
}
