public class UserService : IUserService
{
    private MyArray<User> UserList = new MyArray<User>();

    public bool AddUser(User user)
    {
        if (UserList.FindBy(u => u.Username == user.Username) == null)
        {
            UserList.Add(user);
            return true;
        }
        return false;
    }

    public bool DeleteUser(int id)
    {
        var user = GetUserByID(id);
        if (user != null)
        {
            UserList.Remove(user);
            return true;
        }
        return false;
    }

    public IMyCollection<User> GetAllUsers() => UserList;

    public User GetUserByID(int id)
    {
        return UserList.FindBy(u => u.ID == id);
    }

    public User GetUserByUsername(string username)
    {
        return UserList.FindBy(u => u.Username == username);
    }

    public IMyCollection<User> GetUsersByFirstname(string firstname)
    {
        return UserList.Filter((u) => u.FirstName == firstname);
    }

    public IMyCollection<User> GetUsersByLastname(string lastname)
    {
        return UserList.Filter((u) => u.LastName == lastname);
    }

    public IMyCollection<User> GetUsersByTeamID(int teamID)
    {
        return UserList.Filter((u) => u.TeamID == teamID);
    }

    public bool UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}