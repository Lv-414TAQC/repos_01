
namespace Rest414Test.Data
{
    public interface IUser
    {
        string Name { get; }        // Required
        string Password { get; set; }    // Required
        string Token { get; set; }
    }

}
