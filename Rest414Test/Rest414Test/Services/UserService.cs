using NLog;
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
            CheckService(!IsLogged(),
                "User " + user.ToString() + " Login Unsuccessful.");
        }


        public bool IsLogged()
        {
            return (user != null) && (!string.IsNullOrEmpty(user.Token));
        }

        public ItemTemplate GetItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Index, itemTemplate.Index);
            SimpleEntity simpleEntity = itemResource.HttpGetAsObject(urlParameters, pathParameters);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        // Business

        public UserService AddItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Index, itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Item, itemTemplate.Item);
            SimpleEntity simpleEntity = itemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
            CheckService(!simpleEntity.Equals(true),
                "Item " + itemTemplate.ToString() + "was not Added.");
            return this;
        }

        public UserService AddItems(List<ItemTemplate> itemsTemplate)
        {
            foreach (ItemTemplate item in itemsTemplate)
            {
                RestParameters pathParameters = new RestParameters()
                    .AddParameters(RestParametersKeys.Index, item.Index);
                RestParameters bodyParameters = new RestParameters()
                    .AddParameters(RestParametersKeys.Token, user.Token)
                    .AddParameters(RestParametersKeys.Item, item.Item);
                SimpleEntity simpleEntity = itemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
                CheckService(!simpleEntity.Equals(true),
                    "Item " + item.ToString() + "was not Added.");
            }
            return this;
        }
        public UserService UpdateItem(ItemTemplate item, ItemTemplate updateItem)
        {
            RestParameters bodyParameters = new RestParameters()
                   .AddParameters(RestParametersKeys.Token, user.Token)
                   .AddParameters(RestParametersKeys.Item, updateItem.Item);
            RestParameters pathParameters = new RestParameters()
                    .AddParameters(RestParametersKeys.Index, item.Index);
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
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Name, user.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            CheckService(!simpleEntity.Equals(true), "Logout Unsuccessful.");
            user.Token = string.Empty;
            return new GuestService();
        }

        public GuestService Logout(IUser loggerOut)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, loggerOut.Token)
                .AddParameters(RestParametersKeys.Name, loggerOut.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            CheckService(!simpleEntity.Equals(true), "Logout Unsuccessful.");
            loggerOut.Token = string.Empty;
            return new GuestService();
        }

        public UserService ChangePassw(IUser userD, IUser newpassw)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, userD.Token)
                .AddParameters(RestParametersKeys.OldPassword, userD.Password)
                .AddParameters(RestParametersKeys.NewPassword, newpassw.Password);
            SimpleEntity simpleEntity = userpasswresource.HttpPutAsObject(null, null, bodyParameters);
            Console.WriteLine("ResultChangePasww = " + simpleEntity.content);
            //userD.Password = newpassw.Password;
            return this;
        }
        public List<ItemTemplate> GetAllItems()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
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
                LogManager.GetCurrentClassLogger()
                    .Info("Index- "+template.Index);
                LogManager.GetCurrentClassLogger()
                    .Info("Item- " + template.Item);
            }
            return listItems;
        }
    }
}
