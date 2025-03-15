using Business.interfaces;
using Data.interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.services
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Data.Models.Task> GetTasks()
        {
            return _taskRepository.GetTasks();
        }

        public Data.Models.Task GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public void AddTask(Data.Models.Task newTask)
        {
            _taskRepository.AddTask(newTask);
        }

        public void UpdateTask(Data.Models.Task updateTask) {
            _taskRepository.UpdateTask(updateTask);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeteleTask(id);
        }
    }
}