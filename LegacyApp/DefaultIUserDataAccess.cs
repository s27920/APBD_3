namespace LegacyApp;

public class DefaultIUserDataAccess : IUserDataAccess
{
    public void AddUser(User user)
    {
        UserDataAccess.AddUser(user);
    }
}