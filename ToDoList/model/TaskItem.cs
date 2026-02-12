public class TaskItem : iDatabase
{
    public int ID {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public eTaskPriority Priority {get; set;}
    public eTaskStatus Status {get; set;}
    public DateTime CreateDateTime {get; set;}
    public DateTime UpdateDateTime {get; set;}

    //Builders
    public TaskItem(string title, string description, int priority) =>
        new TaskItem(0, title, description, TaskPriority.FromInt(priority), eTaskStatus.ToDo, DateTime.Now, DateTime.Now);

    public TaskItem(int id, string title, string description, int priority, int status, string createDateTime, string updateDateTime)
    {
        DateTime createDT = Utilities.DTFromSTR(createDateTime);
        DateTime updateDT = Utilities.DTFromSTR(updateDateTime);

        new TaskItem(id, title, description, TaskPriority.FromInt(priority), TaskStatus.FromInt(status), createDT, updateDT);
    }

    public TaskItem(int id, string title, string description, int priority, int status, DateTime createDateTime, DateTime updateDateTime) =>
        new TaskItem(id, title, description, TaskPriority.FromInt(priority), TaskStatus.FromInt(status), createDateTime, updateDateTime);

    public TaskItem(int id, string title, string description, eTaskPriority priority, eTaskStatus status, DateTime createDateTime, DateTime updateDateTime)
    {
        ID = id;
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
        CreateDateTime = createDateTime;
        UpdateDateTime = updateDateTime;
    }

    public string ToSQLInsert() =>
        $"";
    
    public string ToSQLUpdate() =>
        $"";

    public string ToSQLDelete() =>
        $"";
}