interface IUserService
{
    IMyCollection<User> GetAllUsers();
    User GetUserByID(int id);
    User GetUserByUsername(string username);
    IMyCollection<User> GetUsersByFirstname(string firstname);
    IMyCollection<User> GetUsersByLastname(string lastname);
    IMyCollection<User> GetUsersByTeamID(int teamID);
    bool AddUser(User user);
    bool UpdateUser(User user);
    bool DeleteUser(int id);
}