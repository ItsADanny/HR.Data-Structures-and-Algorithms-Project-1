interface ITaskService
{
IEnumerable<TaskItem> GetAllTasks();
void AddTask(TaskItem task);
void UpdateTask(TaskItem task);
void DeleteTask(int id);
void ToggleTaskCompletion(int id);
}