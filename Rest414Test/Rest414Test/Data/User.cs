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

    public enum UserFields : int
    {
        Name = 0,
        Password,
        Address,
        Email,
        Token
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

        // Static Factory

        public static IUser GetUser(IList<string> row)
        {
            IList<string> fields = new List<string>(row);
            for (int i = fields.Count; i < ((UserFields[])Enum.GetValues(typeof(UserFields))).Length; i++)
            {
                fields.Add(string.Empty);
            }
            return Get()
               .SetName(fields[(int)UserFields.Name])
               .SetPassword(fields[(int)UserFields.Password])
               //.SetAddress(fields[(int)UserFields.Address])
               //.SetEmail(fields[(int)UserFields.Email])
               .SetToken(fields[(int)UserFields.Token])
               .Build();
        }


        public static IList<IUser> GetAllUsers(IList<IList<string>> rows)
        {
            //logger.Debug("Start GetAllUsers, path = " + path);
            IList<IUser> users = new List<IUser>();
            //if ((rows[0][(int)UserFields.Email] != null)
            //    && (!rows[0][(int)UserFields.Email].Contains(EMAIL_SEPARATOR)))
            //{
            //    rows.Remove(rows[0]);
            //}
            foreach (IList<string> row in rows)
            {
                if (row[(int)UserFields.Name].ToLower().Equals("name")
                        && row[(int)UserFields.Password].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(GetUser(row));
            }
            return users;
        }


        public override bool Equals(object obj)
        {
            var other = obj as User;

            if (other == null)
                return false;

            if (Name != other.Name || Password != other.Password)
                return false;

            return true;
        }
    }
}
