
namespace Rest414Test.Data
{
    public interface IUser
    {
        string Name { get; }
        string Password { get; set; }
        string Token { get; set; }
    }

}
