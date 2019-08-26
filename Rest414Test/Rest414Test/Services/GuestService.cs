using NLog;
using Rest414Test.Data;
using Rest414Test.Dto;
using Rest414Test.Entity;
using Rest414Test.Resources;
using System;

namespace Rest414Test.Services
{
    public class GuestService : BaseService
    {
        private const int LengthToken = 32;

        public string ResultStatus { get; set; }
        protected AdminAuthorizedResource adminAuthorizedResource;
        protected UserAuthorizedResource userAuthorizedResource;
        protected TokenLifetimeResource tokenLifetimeResource;
        protected UserPasswordResource userpasswresource;

        public GuestService() : base()
        {
            adminAuthorizedResource = new AdminAuthorizedResource();
            userAuthorizedResource = new UserAuthorizedResource();
            tokenLifetimeResource = new TokenLifetimeResource();
            userpasswresource = new UserPasswordResource();
        }

        // Atomic

        public Lifetime GetCurrentTokenLifetime()
        {
            Lifetime lifetime = new Lifetime();
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpGetAsObject(null, null);
            lifetime.Time = simpleEntity.content;
            return lifetime;
        }

        // Business

        public GuestService UnsuccessfulLogin(IUser user)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Name, user.Name)
                .AddParameters(RestParametersKeys.Password, user.Password);

            SimpleEntity simpleEntity = userAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            if (simpleEntity.content.Length == LengthToken)
            {
                logger.Error("Custom exception: entered valid login in UnsuccessfulLogin method");
                throw new Exception("Valid login"); 
            }
            return this;
        }
        public GuestService LockingUser(IUser user)
        {
            int i = 0;
            while (i < 3)
            {
                UnsuccessfulLogin(user);
                if (UnsuccessfulLogin(user).GetType() == typeof(GuestService))
                {
                    ResultStatus = "error, user not found";
                }
                i++;
            }
            UnsuccessfulLogin(user);
            if (UnsuccessfulLogin(user).GetType() == typeof(GuestService))
            {
                ResultStatus = "error, user locked";
            }
            return this;

        }
    

        public UserService SuccessfulUserLogin(IUser user)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Name, user.Name)
                .AddParameters(RestParametersKeys.Password, user.Password);
            SimpleEntity simpleEntity = userAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            user.Token = simpleEntity.content;
            return new UserService(user);
        }

        public AdminService SuccessfulAdminLogin(IUser adminUser)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Name, adminUser.Name)
                .AddParameters(RestParametersKeys.Password, adminUser.Password);
            SimpleEntity simpleEntity = adminAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            adminUser.Token = simpleEntity.content;
            
            return new AdminService(adminUser);
        }
    }
}
