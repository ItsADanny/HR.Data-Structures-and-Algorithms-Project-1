
public class TaskService : ITaskService
{
    private MyArray<TaskItem> TasksList = new MyArray<TaskItem>();

    public IMyCollection<TaskItem> GetAllTasks()
    {
        return TasksList;
    }

    public void AddTask(TaskItem task)
    {
        TasksList.Add(task);
    }
    
    public void UpdateTask(TaskItem task)
    {
        TaskItem found = TasksList.FindBy(task.ID, (t, id) => t.ID == id);
        if (found != null)
        {
            int index = TasksList.IndexOf(found);
            TasksList[index] = task;
        }
    }

    public void DeleteTask(int id)
    {
        TaskItem found = TasksList.FindBy(id, (task, taskId) => task.ID == taskId);
        if (found != null)
        {
            TasksList.Remove(found);
        }
    }

    public void ToggleTaskCompletion(int id)
    {
        TaskItem found = TasksList.FindBy(id, (task, taskId) => task.ID == taskId);
        if (found != null)
        {
            int index = TasksList.IndexOf(found);
            found.Status = found.Status == eTaskStatus.Complete ? eTaskStatus.ToDo : eTaskStatus.Complete;
            TasksList[index] = found;
        }
    }

    public IMyCollection<TaskItem> FilterByPriority(eTaskPriority priority)
    {
        return TasksList.Filter(task => task.Priority == priority);
    }

    public IMyCollection<TaskItem> FilterByDateRange(DateTime startDate, DateTime endDate)
    {
        return TasksList.Filter(task => task.CreateDateTime >= startDate && task.CreateDateTime <= endDate);
    }

    public IMyCollection<TaskItem> FilterByDate(DateTime date)
    {
        return TasksList.Filter(task => task.CreateDateTime.Date == date.Date);
    }

    public IMyCollection<TaskItem> FilterByStatus(eTaskStatus status)
    {
        return TasksList.Filter(task => task.Status == status);
    }

    public IMyCollection<TaskItem> FilterByPriorityAndDate(eTaskPriority priority, DateTime startDate, DateTime endDate)
    {
        return TasksList
            .Filter(task => task.Priority == priority)
            .Filter(task => task.CreateDateTime >= startDate && task.CreateDateTime <= endDate);
    }
}