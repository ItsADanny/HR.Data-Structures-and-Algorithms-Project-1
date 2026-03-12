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
            new TaskItem("Learning about IMyCollections", "What is a IMyCollection?", 1, null, null),
            new TaskItem("Making UI", "Make the UI for our awesome application", 2, null, null),
            new TaskItem("Learning Introductions", "Learning about how to write a introduction", 3, null, null)
        ];

        TaskView.PrintTasks(DEMO_USER, DEMO_DATA);
    }
}