public class TaskItem
{
    public int ID {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public int Priority {get; set;}
    public eTaskStatus Status {get; set;}
    public DateTime CreationDate {get; set;}

    //Builders
    public TaskItem(int id, string title, string description, int priority, int status, DateTime creationDate)
    {

    }

    public TaskItem(int id, string title, string description, int priority, eTaskStatus status, DateTime creationDate)
    {
        
    }
}