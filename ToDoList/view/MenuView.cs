public class MenuView()
{
    public static void PrintMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. View Tasks");
        Console.WriteLine("2. Add Task");
        Console.WriteLine("3. Update Task");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Exit");
        Console.Write("\n Please select an option: ");
        HandleMenuSelection(int.Parse(Console.ReadLine()));
    }

    public static void HandleMenuSelection(int selection)
    {
        switch (selection)
        {
            case 1:
                // Code to view tasks
                Console.WriteLine("Viewing tasks...");
                break;
            case 2:
                // Code to add task
                Console.WriteLine("Adding a new task...");
                break;
            case 3:
                // Code to update task
                Console.WriteLine("Updating a task...");
                break;
            case 4:
                // Code to delete task
                Console.WriteLine("Deleting a task...");
                break;
            case 5:
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid selection. Please try again.");
                break;
        }
    }
}