using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Dto
{
    public sealed class RestUrlRepository
    {
        private static string server = "http://localhost:8080";

        public static string Server
        {
            get { return server; }
            set { server = value; }
        }

        private RestUrlRepository()
        {
        }

        public static RestUrl GetAdminAuthorized()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/login/users")
                .AddPostUrl("/login")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetUser()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/user")
                .AddPutUrl("")
                .AddDeleteUrl("/user");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetUsers()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/users")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetLockedUsers()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/locked/users")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetLockedUser()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/locked/user/{name}")
                .AddPutUrl("/locked/user/{name}")
                .AddDeleteUrl("");
        }



        public static RestUrl GetAllAdmins()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/admins")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetLoggedInAdmins()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/login/admins")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetUserAuthorized()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/login")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetLogout()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/logout")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetCoolDownTime()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/cooldowntime")
                .AddPostUrl("")
                .AddPutUrl("/cooldowntime")
                .AddDeleteUrl("");
        }

        public static RestUrl GetTokenLifetime()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/tokenlifetime")
                .AddPostUrl("")
                .AddPutUrl("/tokenlifetime")
                .AddDeleteUrl("");
        }

        public static RestUrl GetUserItem()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item/{index}/user/{name}")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetItem()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item/{index}")
                .AddPostUrl("/item/{index}")
                .AddPutUrl("/item/{index}")
                .AddDeleteUrl("/item/{index}");
        }

        public static RestUrl GetNewUser()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/user")
                .AddPutUrl("")
                .AddDeleteUrl("/user");

        }

        public static RestUrl ChangePassw()
        {
            return new RestUrl()
               .AddBaseUrl(Server)
               .AddGetUrl("")
               .AddPostUrl("")
               .AddPutUrl("/user")
               .AddDeleteUrl("");
        }
    }

}
