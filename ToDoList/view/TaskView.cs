using Spectre.Console;

public static class TaskView
{
    public static void PrintTasks(User currUser, TaskItem[] taskItems)
    {
        //Clear the console
        AnsiConsole.Clear();

        //Create a new table
        Table table = new Table().Expand();

        //Add columns to the table
        table.AddColumn(new TableColumn("TH_Title").Header("Title"));
        table.AddColumn(new TableColumn("TH_Description").Header("Description"));
        table.AddColumn(new TableColumn("TH_Priority").Header("Priority"));
        table.AddColumn(new TableColumn("TH_Status").Header("Status"));
        table.AddColumn(new TableColumn("TH_Created").Header("Created"));
        table.AddColumn(new TableColumn("TH_Updated").Header("Updated"));

        foreach (TaskItem task in taskItems)
        {
            Console.WriteLine(task);

            table.AddRow(
                new Text($"{task.Title}"),
                new Text($"{task.Description}"),
                new Text($"{task.Priority}"),
                new Text($"{task.Status}"),
                new Text($"{Utilities.DTToDisplaySTR(task.CreateDateTime)}"),
                new Text($"{Utilities.DTToDisplaySTR(task.UpdateDateTime)}")
            );
        }

        //Create a new panel in which we will add our table
        Panel panel = new Panel(table);

        //Set the Header
        if (currUser is not null)
        {
            panel.Header($"{currUser.FirstName} {currUser.LastName} - Current tasks", Justify.Center);
        }
        else
        {
            panel.Header("all tasks", Justify.Center);
        }
        

        //Print the new UI
        AnsiConsole.Write(panel);
    }

    public static void PrintTasksKanBan(User? currUser, TaskItem[] taskItems)
    {
        //Clear the console
        AnsiConsole.Clear();

        //Create a new table
        Table table = new Table().Expand();

        //Add columns to the table
        table.AddColumn(new TableColumn("TH_ToDo").Header("To Do"));
        table.AddColumn(new TableColumn("TH_Doing").Header("Doing"));
        table.AddColumn(new TableColumn("TH_Review").Header("Review"));
        table.AddColumn(new TableColumn("TH_Complete").Header("Complete"));

        TaskItem[] BacklogItems = [];
        TaskItem[] DoingItems = [];
        TaskItem[] ReviewItems = [];
        TaskItem[] CompleteItems = [];

        //Create a new panel in which we will add our table
        Panel panel = new Panel(table);

        //Set the Header
        if (currUser is not null)
        {
            panel.Header($"{currUser.FirstName} {currUser.LastName} - Current tasks", Justify.Center);
        }
        else
        {
            panel.Header("all tasks", Justify.Center);
        }
        

        //Print the new UI
        AnsiConsole.Write(panel);
    }
}