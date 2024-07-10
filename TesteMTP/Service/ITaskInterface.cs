using TesteMTP.Model;

namespace TesteMTP.Service
{
    public interface ITaskInterface
    {
        Task<ServiceResponse<List<TaskModel>>> GetTasks();
        Task<ServiceResponse<List<TaskModel>>> CreateNewTask(TaskModel newTask);
        Task<ServiceResponse<TaskModel>> GetTaskById(int id);
        Task<ServiceResponse<List<TaskModel>>> UpdateTask(TaskModel alterTask);
        Task<ServiceResponse<List<TaskModel>>> FinishTask(int id);
        Task<ServiceResponse<List<TaskModel>>>  DeleteTask(int id);
    }
}
