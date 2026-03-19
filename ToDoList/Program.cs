public class Program
{
    public static AppContext AppDB = new();
    public static Repository<Role> RoleRepo = new(AppDB);
    public static Repository<TaskItem> TaskItemRepo = new(AppDB);
    public static Repository<Team> TeamRepo = new(AppDB);
    public static Repository<User> UserRepo = new(AppDB);

    public static void Main()
    {
        TaskView.PrintTasks(DEMO_USER, DEMO_DATA);

        MenuView.RunMenu();
    }
}