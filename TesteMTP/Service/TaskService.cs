using Microsoft.EntityFrameworkCore;
using System;
using TesteMTP.DataContext;
using TesteMTP.Model;

namespace TesteMTP.Service
{
    public class TaskService : ITaskInterface
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<TaskModel>>> CreateNewTask(TaskModel newTask)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = new ServiceResponse<List<TaskModel>>();

            try 
            { 
                if (newTask == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "É necessário preencher a descrição da tarefa!";
                    serviceResponse.Success = false; 
                }

                _context.Add(newTask);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.T_TASK.ToList();
            } 
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TaskModel>>> DeleteTask(int id)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = new ServiceResponse<List<TaskModel>>();

            try
            {
                TaskModel task = _context.T_TASK.FirstOrDefault(x => x.idTask == id);
                if(task == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Id Taks não encontrado!";
                    serviceResponse.Success = false;
                }

                _context.T_TASK.Remove(task);
                await _context.SaveChangesAsync();

            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<TaskModel>> GetTaskById(int id)
        {
            ServiceResponse<TaskModel> serviceResponse = new ServiceResponse<TaskModel>();

            try
            {
                TaskModel task = _context.T_TASK.FirstOrDefault(x =>x.idTask == id);

                if (task == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Id Task não encontrada!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = task;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TaskModel>>> GetTasks()
        {
            ServiceResponse<List<TaskModel>> serviceResponse = new ServiceResponse<List<TaskModel>>();

            try
            {
                serviceResponse.Data = _context.T_TASK.ToList();

                if (serviceResponse.Data.Count == 0) 
                {
                    serviceResponse.Message = "Nenhuma task encontrada!";
                }

            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TaskModel>>> UpdateTask(TaskModel alterTask)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = new ServiceResponse<List<TaskModel>>();

            try
            {
                TaskModel task = _context.T_TASK.AsNoTracking().FirstOrDefault(x => x.idTask == alterTask.idTask); 
                if (task == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Task não encontrada!";
                    serviceResponse.Success = false;
                }

                task.dtModification = DateTime.Now.ToLocalTime();
                _context.T_TASK.Update(alterTask);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.T_TASK.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<TaskModel>>> FinishTask(int id)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = new ServiceResponse<List<TaskModel>>();

            try
            {
                TaskModel task = _context.T_TASK.FirstOrDefault(x => x.idTask == id);

                if(task == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Task não encontrada!";
                    serviceResponse.Success = false;
                }

                task.idStatus = Enum.StatusEnum.Finished;
                task.dtModification = DateTime.Now.ToLocalTime();

                _context.T_TASK.Update(task);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.T_TASK.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;  
            }

            return serviceResponse;
        }
    }
}
