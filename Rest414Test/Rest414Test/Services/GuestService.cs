using Rest414Test.Data;
using Rest414Test.Dto;
using Rest414Test.Entity;
using Rest414Test.Resources;
using System;

namespace Rest414Test.Services
{
    public class GuestService : BaseService
    {
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
                .AddParameters("name", user.Name)
                .AddParameters("password", user.Password);
           
            SimpleEntity simpleEntity = userAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            user.Token = simpleEntity.content;
            if (simpleEntity.content.Length == 32)
            {
                return new UserService(user);
            }
            Console.WriteLine(user.Token);
            return this;
        }

        public UserService SuccessfulUserLogin(IUser user)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("name", user.Name)
                .AddParameters("password", user.Password);
            SimpleEntity simpleEntity = userAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            user.Token = simpleEntity.content;
            Console.WriteLine(user.Token);
            return new UserService(user);
        }

        public AdminService SuccessfulAdminLogin(IUser adminUser)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("name", adminUser.Name)
                .AddParameters("password", adminUser.Password);
            SimpleEntity simpleEntity = adminAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            adminUser.Token = simpleEntity.content;
            //Console.WriteLine("adminUser.Token = " + adminUser.Token);
            return new AdminService(adminUser);
        }
    }
}
