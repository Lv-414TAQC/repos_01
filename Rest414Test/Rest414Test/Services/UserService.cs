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
    public class UserService : GuestService
    {
        protected IUser user;
        protected LogoutResource logoutResource;
        protected ItemResource itemResource;
        


        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            itemResource = new ItemResource();
            CheckService(!IsLoggined(),
                "User " + user.ToString() + " Login Unsuccessful.");
        }

        // Atomic

        public bool IsLoggined()
        {
            return (user != null) && (!string.IsNullOrEmpty(user.Token));
        }

        public ItemTemplate GetItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            SimpleEntity simpleEntity = itemResource.HttpGetAsObject(urlParameters, pathParameters);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Item " + itemTemplate.ToString() + "was not received.");
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            // TODO (new or exist)
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        // Business

        public UserService AddItem(ItemTemplate itemTemplate)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("item", itemTemplate.Item);
            SimpleEntity simpleEntity = itemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
            // TODO
            CheckService(!simpleEntity.Equals(true),
                "Item " + itemTemplate.ToString() + "was not Added.");
            //Console.WriteLine("\t***AddItem(): simpleEntity = " + simpleEntity);
            return this;
        }

        public GuestService Logout()
        {
            //Console.WriteLine("\t***Logout(): user = " + user);
            //
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            //Console.WriteLine("\t***Logout(): simpleEntity = " + simpleEntity);
            // TODO
            CheckService(!simpleEntity.Equals(true), "Logout Unsuccessful.");
            user.Token = string.Empty;
            //Console.WriteLine("\t***Logout(): DONE ");
            return new GuestService();
        }

        public GuestService Logout(IUser loggerOut)
        {
            //Console.WriteLine("\t***Logout(): user = " + user);
            //
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", loggerOut.Token)
                .AddParameters("name", loggerOut.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            //Console.WriteLine("\t***Logout(): simpleEntity = " + simpleEntity);
            // TODO
            CheckService(!simpleEntity.Equals(true), "Logout Unsuccessful.");
            //user.Token = string.Empty;
            //Console.WriteLine("\t***Logout(): DONE ");
            return new GuestService();
        }

        public UserService ChangePassw(IUser userD, IUser newpassw)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", userD.Token)
                .AddParameters("oldpassword", userD.Password)
                .AddParameters("newpassword", newpassw.Password);
            SimpleEntity simpleEntity = userpasswresource.HttpPutAsObject(null, null, bodyParameters);
            Console.WriteLine("ResultChangePasww = " + simpleEntity.content);
            userD.Password = newpassw.Password;
            return new UserService(userD);
        }
    }
}
