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
            List<IUser> adminsList = this.GetAllAdmins();
            return adminsList.Contains(isAdmin);
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

        public List<IUser> GetAllAdmins()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
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
                .AddParameters("token", newAdmin.Token);
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
                .AddParameters("token", user.Token);
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
                .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = cooldowntimeResource.HttpGetAsObject(urlParameters, null);
            //coolDownTime.Time = simpleEntity.content;
            Console.WriteLine("simpleEntity = " + simpleEntity.content);
            return simpleEntity.content;
        }

        
        public List<IUser> GetLockedUsers()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
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
                Console.WriteLine(user);
            }
            return listLockedUsers;
        }

        // Business



        public AdminService UnlockUser(IUser user1)
        {
            //RestParameters urlParameters = new RestParameters()

            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathVariables = new RestParameters()
                .AddParameters("name", user1.Name); //?????
            
            SimpleEntity simpleEntity = lockeduserResource
                .HttpPutAsObject(null, pathVariables, bodyParameters);
            Console.WriteLine("\t***AddAdmin(): simpleEntity = " + simpleEntity);
            return this;
        }

        public AdminService UpdateTokenlifetime(Lifetime lifetime)
        {
            Console.WriteLine("lifetime = " + lifetime + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            // TODO
            CheckService(!simpleEntity.Equals(true),
                "Tokenlifetime " + lifetime.ToString() + " was not Updated.");
            return this;
        }
        public AdminService UpdateCoolDowntime(CoolDownTime cooldowntime)
        {
            //Console.WriteLine("CoolDownTime = " + CoolDownTime.Time + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", cooldowntime.Time);
            SimpleEntity simpleEntity = cooldowntimeResource.HttpPutAsObject(null, null, bodyParameters);
            // TODO
            CheckService(!simpleEntity.Equals(true),
                "CoolDownTime " + cooldowntime.ToString() + "was not Updated.");
            return this;
        }

        public UserService AddAdmin(IUser newAdmin)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters urlParameters = new RestParameters()
            //RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", newAdmin.Name)
                .AddParameters("password", newAdmin.Password)
                .AddParameters("rights", "true");
            SimpleEntity simpleEntity = userResource
                .HttpPostAsObject(urlParameters, null, null);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Admin " + newAdmin.ToString() + "was not Added.");
            Console.WriteLine("\t***AddAdmin(): simpleEntity = " + simpleEntity);
            return this;
        }

        public UserService RemoveUser(IUser newAdmin)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters urlParameters = new RestParameters()
            //RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", newAdmin.Name);
            SimpleEntity simpleEntity = userResource
                .HttpDeleteAsObject(urlParameters, null, null);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Admin " + newAdmin.ToString() + "was not Added.");
           // Console.WriteLine("\t***AddAdmin(): simpleEntity = " + simpleEntity);
            return this;
        }
        public UserService CreateUser(IUser newUser)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters urlParameters = new RestParameters()
            //RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", newUser.Name)
                .AddParameters("password", newUser.Password)
                .AddParameters("rights", "false");
            SimpleEntity simpleEntity = userResource
                .HttpPostAsObject(urlParameters, null, null);
            
          //Console.WriteLine("\t***NewUser(): simpleEntity = " + simpleEntity);
            return this;
        }

        public List<IUser> GetAllUsers()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
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
                Console.WriteLine(u);
            }
            return listUsers;
        }
    }
}
