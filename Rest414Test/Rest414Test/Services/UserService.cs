using Rest414Test.Data;
using Rest414Test.Dto;
using Rest414Test.Entity;
using Rest414Test.Resources;
using System;
using System.Collections.Generic;

namespace Rest414Test.Services
{
    public class UserService : GuestService
    {
        protected IUser user;
        protected LogoutResource logoutResource;
        protected ItemResource itemResource;
        protected AllItemsResource allItemsResource;


        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            itemResource = new ItemResource();
            allItemsResource =new AllItemsResource();
            CheckService(!IsLoggined(),
                "User " + user.ToString() + " Login Unsuccessful.");
        }

        // Atomic

        public bool IsLoggined()
        {
            return (user != null) && (!string.IsNullOrEmpty(user.Token) && !user.Token.Contains("ERROR, user not found"));
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

        public UserService AddItems(List<ItemTemplate> itemsTemplate)
        {
            foreach (ItemTemplate item in itemsTemplate)
            {
                RestParameters pathParameters = new RestParameters()
                    .AddParameters("index", item.Index);
                RestParameters bodyParameters = new RestParameters()
                    .AddParameters("token", user.Token)
                    .AddParameters("item", item.Item);
                SimpleEntity simpleEntity = itemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
                CheckService(!simpleEntity.Equals(true),
                    "Item " + item.ToString() + "was not Added.");
            }
            return this;
        }
        public UserService UpdateItem(ItemTemplate item, ItemTemplate updateItem)
        {
            RestParameters bodyParameters = new RestParameters()
                   .AddParameters("token", user.Token)
                   .AddParameters("item", updateItem.Item);
            RestParameters pathParameters = new RestParameters()
                    .AddParameters("index", item.Index);
            
                SimpleEntity simpleEntity = itemResource.HttpPutAsObject(null, pathParameters, bodyParameters);
            CheckService(!simpleEntity.Equals(true),
                "Item " + item.ToString() + "was not Added.");
            return this;
        }
        public bool IsUpdateItem(ItemTemplate updatedItem, List<ItemTemplate> items)
        {
            bool result = false;
            foreach(ItemTemplate itemTemplate in items)
            {
                Console.WriteLine($"{itemTemplate.Index}---{updatedItem.Index}");
                Console.WriteLine($"{itemTemplate.Item}---{updatedItem.Item}");
                if (itemTemplate.Index.Contains(updatedItem.Index)
                    && itemTemplate.Item.Contains(updatedItem.Item))
                {
                    result = true;
                }
                else Console.WriteLine("NOOOO");
            }
            return result;
        }

        public GuestService Logout()
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);

            CheckService(!simpleEntity.Equals(true), "Logout Unsuccessful.");
            user.Token = string.Empty;
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
           // Console.WriteLine(simpleEntity.content);
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
        public List<ItemTemplate> GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);

            SimpleEntity simpleEntity = allItemsResource.HttpGetAsObject(urlParameters, null);
            Console.WriteLine(simpleEntity.content);
            List<string> list = new List<string>(simpleEntity.content
                .Split(new string[] { "\n", "\t", " \t"}, StringSplitOptions.None));
            foreach (string i in list) Console.WriteLine("Element-"+i);
            List<ItemTemplate> listItems = new List<ItemTemplate>();
            for (int i = list.Count - 2; i > 0; i -= 2)
            {
                ItemTemplate template = new ItemTemplate(list[i], list[i - 1]);
                listItems.Add(template);
                Console.WriteLine($"{template.Index}- index");
                Console.WriteLine($"{template.Item}- item");
            }
            return listItems;
        }
    }
}
