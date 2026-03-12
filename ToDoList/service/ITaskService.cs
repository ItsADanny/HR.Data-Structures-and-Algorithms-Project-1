interface ITaskService
{
IMyCollection<TaskItem> GetAllTasks();
void AddTask(TaskItem task);
void UpdateTask(TaskItem task);
void DeleteTask(int id);

//NOT NEEDED, WE HAVE A DIFFERENT METHOD NOW FOR THIS
// void ToggleTaskCompletion(int id);
}