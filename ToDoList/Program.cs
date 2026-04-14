public class Program
{
    public static AppContext AppDB = new();
    public static Repository<Role> RoleRepo = new(AppDB);
    public static Repository<TaskItem> TaskItemRepo = new(AppDB);
    public static Repository<Team> TeamRepo = new(AppDB);
    public static Repository<User> UserRepo = new(AppDB);

    public static void Main()
    {
        bool ExitProgram = false;
        int attempts = 0;
        User? appUser = null;
        
        while (attempts < 3 && appUser == null)
        {
            appUser = MenuView.Login(attempts);
            attempts++;
        }
        if (attempts == 3 && appUser == null) ExitProgram = true;

        while (!ExitProgram)
        {
            ExitProgram = MenuView.Main();
        }

        MenuView.GoodByeMessage();
    }
}