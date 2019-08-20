using Rest414Test.Data;
using Rest414Test.Dto;
using Rest414Test.Entity;
using Rest414Test.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Services
{
    public class AdminService : UserService
    {
        protected UserItemResource userItemResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            userItemResource = new UserItemResource();
            CheckService(!IsAdmin(),
                "Admin " + adminUser.ToString() + "Login Unsuccessful.");
        }

        // Atomic

        public bool IsAdmin()
        {
            // TODO
            return true;
        }

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index)
                .AddParameters("name", userWithItem.Name);
            SimpleEntity simpleEntity = userItemResource.HttpGetAsObject(urlParameters, pathParameters);
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Item " + itemTemplate.ToString() + "was not received.");
            // TODO (new or exist)
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        // Business

        public AdminService UpdateTokenlifetime(Lifetime lifetime)
        {
            //Console.WriteLine("lifetime = " + lifetime.Time + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            // TODO
            CheckService(!simpleEntity.Equals(true),
                "Tokenlifetime " + lifetime.ToString() + "was not Updated.");
            return this;
        }
    }
}
