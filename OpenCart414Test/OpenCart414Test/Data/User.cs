
namespace OpenCart414Test.Data
{
    public interface IFirstname
    {
        ILastname SetFirstname(string firstname);
    }
    public interface ILastname
    {
        IEmail SetLastname(string lastname);
    }
    public interface IEmail
    {
        ITelephone SetEmail(string email);
    }
    public interface ITelephone
    {
        IAddress SetTelephone(string telephone);
    }
    public interface IAddress
    {
        ICity SetAddress1(string address1);
    }
    public interface ICity
    {
        IPostcode SetCity(string city);
    }
    public interface IPostcode
    {
        ICountry SetPostcode(string postcode);
    }
    public interface ICountry
    {
        IRegionState SetCountry(string country);
    }
    public interface IRegionState
    {
        IPassword SetRegionState(string regionState);
    }
    public interface IPassword
    {
        ISubscribe SetPassword(string password);
    }
    public interface ISubscribe
    {
        IUserBuild SetSubscribe(bool subscribe);
    }

    public interface IUserBuild
    {
        IUserBuild SetFax(string fax);
        IUserBuild SetCompany(string company);
        IUserBuild SetAddress2(string address2);
        // 5. Add Builder
        //User Build();
        // 6. Dependency Inversion
        IUser Build();
    }


    public class User : IFirstname, ILastname, IEmail,
                        ITelephone, IAddress, ICity,
                        IPostcode, ICountry, IRegionState,
                        IPassword, ISubscribe, IUserBuild, IUser
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
        //
        // 1. Use Constructor
        // public string Fax { get; set; }              // not required
        // 2. Default Constructor and Setters
        public string Fax { get; private set; }         // not required
        //
        // 1. Use Constructor
        // public string Company { get; set; }          // not required
        // 2. Default Constructor and Setters
        public string Company { get; private set; }     // not required
        //
        public string Address1 { get; private set; }
        //
        // 1. Use Constructor
        // public string Address2 { get; set; }         // not required = "";
        // 2. Default Constructor and Setters
        public string Address2 { get; private set; }    // not required
        //
        public string City { get; private set; }
        public string Postcode { get; private set; }
        public string Country { get; private set; }
        public string RegionState { get; private set; }
        public string Password { get; private set; }
        public bool Subscribe { get; private set; }


        // 5. Add Builder
        private User()
        {
            Fax = string.Empty;
            Company = string.Empty;
            Address2 = string.Empty;
        }

        // 4. Add Static Factory
        // public static User Get()
        // 5. Add Builder
        public static IFirstname Get()
        {
            return new User();
        }

        // Setters

        // 2. Default Constructor and Setters
        //public void SetFirstname(string firstname)
        // 3. Add Fluent Interface
        //public User SetFirstname(string firstname)
        // 5. Add Builder
        public ILastname SetFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public IEmail SetLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public ITelephone SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public IAddress SetTelephone(string telephone)
        {
            Telephone = telephone;
            return this;
        }

        public ICity SetAddress1(string address1)
        {
            Address1 = address1;
            return this;
        }

        public IPostcode SetCity(string city)
        {
            City = city;
            return this;
        }

        public ICountry SetPostcode(string postcode)
        {
            Postcode = postcode;
            return this;
        }

        public IRegionState SetCountry(string country)
        {
            Country = country;
            return this;
        }

        public IPassword SetRegionState(string regionState)
        {
            RegionState = regionState;
            return this;
        }

        public ISubscribe SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public IUserBuild SetSubscribe(bool subscribe)
        {
            Subscribe = subscribe;
            return this;
        }

        // not required

        public IUserBuild SetFax(string fax)
        {
            Fax = fax;
            return this;
        }

        public IUserBuild SetCompany(string company)
        {
            Company = company;
            return this;
        }

        public IUserBuild SetAddress2(string address2)
        {
            Address2 = address2;
            return this;
        }

        // 5. Add Builder
        //public User Build()
        // 6. Dependency Inversion
        public IUser Build()
        {
            return this;
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname
                + "\nLastname = " + Lastname
                + "\nEmail = " + Email
                + "\nTelephone = " + Telephone
                + "\nFax = " + Fax
                + "\nCompany = " + Company
                + "\nAddress1 = " + Address1
                + "\nAddress2 = " + Address2
                + "\nCity = " + City
                + "\nPostcode = " + Postcode
                + "\nCountry = " + Country
                + "\nRegionState = " + RegionState
                + "\nPassword = " + Password
                + "\nSubscribe = " + Subscribe.ToString();
        }


    }
}
