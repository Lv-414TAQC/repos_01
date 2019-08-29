using Rest414Test.Data;
using Rest414Test.Dto;
using Rest414Test.Entity;
using Rest414Test.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rest414Test.Services
{
    public class AdminService : UserService
    {
        protected UserItemResource userItemResource;
        protected AdminsResource adminsResource;
        protected LoggedInAdminsResource loggedInAdminsResource;
        protected UserResource userResource;
        protected CoolDownTimeResource cooldowntimeResource;
        protected UsersResource usersResource;
        protected LockedUsersResource lockedusersResource;
        protected LockedUserResource lockeduserResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            userItemResource = new UserItemResource();
            adminsResource = new AdminsResource();
            loggedInAdminsResource = new LoggedInAdminsResource();
            userResource = new UserResource();
            usersResource = new UsersResource();
            cooldowntimeResource = new CoolDownTimeResource();
            lockedusersResource = new LockedUsersResource();
            lockeduserResource = new LockedUserResource();
           
            CheckService(!IsAdmin(adminUser),
                "Admin " + adminUser.ToString() + "Login Unsuccessful.");
        }

        // Atomic

        public bool IsAdmin(IUser isAdmin)
        {
            return GetAllAdmins().Contains(isAdmin);
        }

        public bool IsLoggedInAdmin(IUser isLoggedInAdmin)
        {
            return GetLoggedInAdmins().Contains(isLoggedInAdmin);
        }

        public bool UserExists(IUser isUserThere)
        {
            return GetAllUsers().Contains(isUserThere);
        }

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Index, itemTemplate.Index)
                .AddParameters(RestParametersKeys.Name, userWithItem.Name);
            SimpleEntity simpleEntity = userItemResource.HttpGetAsObject(urlParameters, pathParameters);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        public List<IUser> GetAllAdmins()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            SimpleEntity simpleEntity = adminsResource.HttpGetAsObject(urlParameters, null);
            string[] contentArray = simpleEntity.content.Split(' ');
            int counter = 0;
            foreach(string i in contentArray)
            {
                contentArray[counter] = new String(i.Where(Char.IsLetter).ToArray());
                counter++;
            }
            List<IUser> returnedUsers = new List<IUser> {};
            foreach(string i in contentArray)
            {
                returnedUsers.Add(new User(i));
            }
            return returnedUsers;
        }

        public List<IUser> GetAllAdmins(IUser newAdmin)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, newAdmin.Token);
            SimpleEntity simpleEntity = adminsResource.HttpGetAsObject(urlParameters, null);
            string[] contentArray = simpleEntity.content.Split(' ');
            int counter = 0;
            foreach (string i in contentArray)
            {
                contentArray[counter] = new String(i.Where(Char.IsLetter).ToArray());
                counter++;
            }
            List<IUser> returnedUsers = new List<IUser> { };
            foreach (string i in contentArray)
            {
                returnedUsers.Add(new User(i));
            }
            return returnedUsers;
        }
        
        public List<IUser> GetLoggedInAdmins()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            SimpleEntity simpleEntity = loggedInAdminsResource.HttpGetAsObject(urlParameters, null);
            string[] contentArray = simpleEntity.content.Split(' ');
            int counter = 0;
            foreach (string i in contentArray)
            {
                contentArray[counter] = new String(i.Where(Char.IsLetter).ToArray());
                counter++;
            }
            List<IUser> returnedUsers = new List<IUser> { };
            foreach (string i in contentArray)
            {
                returnedUsers.Add(new User(i));
            }
            return returnedUsers;
        }

        public string GetCoolDownTime()
        {
            CoolDownTime coolDownTime = new CoolDownTime();
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            SimpleEntity simpleEntity = cooldowntimeResource.HttpGetAsObject(urlParameters, null);
            coolDownTime.Time = simpleEntity.content;
            return simpleEntity.content;
        }

        
        public List<IUser> GetLockedUsers()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            SimpleEntity simpleEntity = lockedusersResource.HttpGetAsObject(urlParameters, null);
            List<string> listNameLockedUsers = new List<string>(simpleEntity.content.Split(new char[] { '\n', '\t' }));

            for (int i = 0; i < listNameLockedUsers.Count; i++)
            {
                listNameLockedUsers.RemoveAt(i);
            }
            List<IUser> listLockedUsers = new List<IUser>();
            foreach (string lockuser in listNameLockedUsers)
            {
                listLockedUsers.Add(new User(lockuser));
                
            }
            return listLockedUsers;
        }

        // Business

        public AdminService UnlockUser(IUser user1)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            RestParameters pathVariables = new RestParameters()
                .AddParameters(RestParametersKeys.Name, user1.Name); //?????
            
            SimpleEntity simpleEntity = lockeduserResource
                .HttpPutAsObject(null, pathVariables, bodyParameters);
            return this;
        }

        public AdminService UpdateTokenlifetime(Lifetime lifetime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Time, lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            CheckService(!simpleEntity.Equals(true),
                "Tokenlifetime " + lifetime.ToString() + " was not Updated.");
            return this;
        }
        public AdminService UpdateCoolDowntime(CoolDownTime cooldowntime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Time, cooldowntime.Time);
            SimpleEntity simpleEntity = cooldowntimeResource.HttpPutAsObject(null, null, bodyParameters);
            CheckService(!simpleEntity.Equals(true),
                "CoolDownTime " + cooldowntime.ToString() + "was not Updated.");
            return this;
        }

        public UserService AddAdmin(IUser newAdmin)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Name, newAdmin.Name)
                .AddParameters(RestParametersKeys.Password, newAdmin.Password)
                .AddParameters(RestParametersKeys.Rights, ParamTrue);
            SimpleEntity simpleEntity = userResource
                .HttpPostAsObject(urlParameters, null, null);
            CheckService(!simpleEntity.Equals(true),
                "Admin " + newAdmin.ToString() + "was not Added.");
            return this;
        }

        public UserService RemoveUser(IUser newAdmin)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Name, newAdmin.Name);
            SimpleEntity simpleEntity = userResource
                .HttpDeleteAsObject(urlParameters, null, null);
            CheckService(!simpleEntity.Equals(true),
                "User " + newAdmin.ToString() + "was not Removed.");
            //logger.Info("RemoveUser = " + simpleEntity.content);
            return this;
        }
        public UserService CreateUser(IUser newUser)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token)
                .AddParameters(RestParametersKeys.Name, newUser.Name)
                .AddParameters(RestParametersKeys.Password, newUser.Password)
                .AddParameters(RestParametersKeys.Rights, ParamFalse);
            SimpleEntity simpleEntity = userResource
                .HttpPostAsObject(urlParameters, null, null);
            //logger.Info("CreateUser = " + simpleEntity.content);
            return this;
        }

        public List<IUser> GetAllUsers()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RestParametersKeys.Token, user.Token);
            SimpleEntity simpleEntity = usersResource.HttpGetAsObject(urlParameters, null);
            List<string> listNameUsers = new List<string>(simpleEntity.content.Split(new char[] { '\n', '\t' }));

            for (int i = 0; i < listNameUsers.Count; i++)
            {
                listNameUsers.RemoveAt(i);
            }
            List<IUser> listUsers = new List<IUser>();
            foreach (string u in listNameUsers)
            {
                listUsers.Add(new User(u));       
            }
            return listUsers;
        }
    }
}
