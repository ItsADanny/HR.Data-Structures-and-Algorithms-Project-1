public class MenuView
{
    public static void RunMenu()
    {
        while (true)
        {
            PrintMenu();

            string option = Prompt("Select an option: ");
            switch (option)
            {
                case "1":
                    // View Tasks

                    break;
                case "2":
                    // Add Task

                    break;
                case "3":
                    // Update Task

                    break;
                case "4":
                    // Delete Task
                    string removIdStr = Prompt("Enter the ID of the task to delete: ");

                    break;
                case "5":
                    // Toggle Task Completion
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public static void PrintMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. View Tasks");
        Console.WriteLine("2. Add Task");
        Console.WriteLine("3. Update Task");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Toggle Task Completion");
        Console.WriteLine("6. Exit");
    }

    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}