using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Data
{
    public interface IName
    {
        IPassword SetName(string name);
    }

    public interface IPassword
    {
        IUserBuild SetPassword(string password);
    }

    public interface IUserBuild
    {
        IUserBuild SetToken(string token);
        IUser Build();
    }

    public class User : IName, IPassword, IUserBuild, IUser
    {
        public string Name { get; private set; }            // Required
        public string Password { get; private set; }        // Required
        public string Token { get; set; }

        private User()
        {
            Token = string.Empty;
        }

        public static IName Get()
        {
            return new User();
        }

        public IPassword SetName(string name)
        {
            Name = name;
            return this;
        }

        public IUserBuild SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public IUserBuild SetToken(string token)
        {
            Token = token;
            return this;
        }

        public IUser Build()
        {
            return this;
        }

        public override string ToString()
        {
            return "[Name: " + Name + ", Password: " + Password + ", Token: " + Token + "]";
        }

    }

}
