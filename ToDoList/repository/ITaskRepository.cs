interface ITaskRepository
{
    List<Task> LoadTasks();
    void SaveTasks(List<Task> tasks);
}