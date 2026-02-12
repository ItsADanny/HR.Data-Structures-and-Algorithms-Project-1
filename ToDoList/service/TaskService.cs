public class TaskService : ITaskService
{
    public TaskItem[] TasksList = new TaskItem[] {};
    int LastIndex = 0;
    public IEnumerable<TaskItem> GetAllTasks()
    {
        return TasksList; 
    }

    public void AddTask(TaskItem task)
    {
        if (LastIndex < TasksList.Length - 1)
        {
            TasksList[LastIndex] = task;
            LastIndex++;
            return; 
        } 
        addslots();
        TasksList[LastIndex] = task;
        LastIndex++;
        return;
    }
    
    public void UpdateTask(TaskItem task)
    {
        int index = findTaskById(task.ID);
        TasksList[index] = task; return;
    }

    public int findTaskById(int id)
    {
        for (int i = 0; i < TasksList.Length; i++)
        {
            if (TasksList[i].ID == id)
            {
                return i;
            }
        }
        return -1;
    }
    public void DeleteTask(int id)
    {
        int index = findTaskById(id);
        if(index != -1)
        {
            shiftToleft(index);
            LastIndex--;
        }
        return;
    }

    public void shiftToleft( int index) 
    { 
        for (int x = index; x < LastIndex; x++) 
        {
            TasksList[x] = TasksList[x + 1];
        }
    }

    public void addslots()
    {
        TaskItem[] newlist = new TaskItem[TasksList.Length + 10];
        for (int i = 0; i < TasksList.Length; i++)
        {
            newlist[i] = TasksList[i];
        }
        TasksList = newlist;
    }

    public void ToggleTaskCompletion(int id)
    {
        // Implementation here
        return ;
    }
}