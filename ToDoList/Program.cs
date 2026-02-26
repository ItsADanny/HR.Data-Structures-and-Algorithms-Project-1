public class Program
{
    public static void Main()
    {
        User DEMO_USER = new User
        {
            FirstName = "Danny",
            LastName = "de Snoo"
        };

        TaskItem[] DEMO_DATA = [
            new TaskItem("Baking a cake", "Baking a very good cake at the Hogeschool Rotterdam kitchen", 0, null, null),
            new TaskItem("Ruling the World", "What can i say but i have some solutions", 1, null, null),
            new TaskItem("Driving a JAAAG", "Driving a awesome car to the end of the world", 2, null, null),
            new TaskItem("Nailing a Copper Golem to a Cross", "Nailing a Copper Golem to a Cross to show it i mean business", 3, null, null)
        ];

        TaskView.PrintTasks(DEMO_USER, DEMO_DATA);

        MenuView.RunMenu();
    }
}