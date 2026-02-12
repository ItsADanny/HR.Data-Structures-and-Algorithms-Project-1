public class TaskItem : iDatabase
{
    public int ID {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public eTaskPriority Priority {get; set;}
    public eTaskStatus Status {get; set;}
    public int? TeamID {get; set;}
    public int? UserID {get; set;}
    public DateTime CreateDateTime {get; set;}
    public DateTime UpdateDateTime {get; set;}

    //Builders
    public TaskItem(string title, string description, int priority, int? teamID, int? userID) =>
        new TaskItem(0, title, description, TaskPriority.FromInt(priority), eTaskStatus.ToDo, teamID, userID, DateTime.Now, DateTime.Now);

    public TaskItem(int id, string title, string description, int priority, int status, int? teamID, int? userID, string createDateTime, string updateDateTime)
    {
        DateTime createDT = Utilities.DTFromSTR(createDateTime);
        DateTime updateDT = Utilities.DTFromSTR(updateDateTime);

        new TaskItem(id, title, description, TaskPriority.FromInt(priority), TaskStatus.FromInt(status), teamID, userID, createDT, updateDT);
    }

    public TaskItem(int id, string title, string description, int priority, int status, int? teamID, int? userID, DateTime createDateTime, DateTime updateDateTime) =>
        new TaskItem(id, title, description, TaskPriority.FromInt(priority), TaskStatus.FromInt(status), teamID, userID, createDateTime, updateDateTime);

    public TaskItem(int id, string title, string description, eTaskPriority priority, eTaskStatus status, int? teamID, int? userID, DateTime createDateTime, DateTime updateDateTime)
    {
        ID = id;
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
        TeamID = teamID;
        UserID = userID;
        CreateDateTime = createDateTime;
        UpdateDateTime = updateDateTime;
    }

    public string ToSQLInsert() =>
        $"";
    
    public string ToSQLUpdate() =>
        $"";

    public string ToSQLDelete() =>
        $"";

    public static string GetAllSQL() =>
        $"";

    public static string GetByIDSQL() =>
        $"";
}