using Data.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly GestionTareasContext _context;

        public TaskRepository(GestionTareasContext context)
        {
            _context = context;
        }
        public List<Data.Models.Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public Data.Models.Task GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.id == id);
        }

        public void AddTask(Data.Models.Task newTask) {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }

        public void UpdateTask(Data.Models.Task updateTask)
        {
            var existTask = _context.Tasks.FirstOrDefault(t => t.id == updateTask.id);
            if (existTask != null) { 
                existTask.description = updateTask.description;
                existTask.isCompleted = updateTask.isCompleted;
                existTask.isImportant = updateTask.isImportant;
                _context.Tasks.Update(updateTask);
                _context.SaveChanges();
            }
        }

        public void DeteleTask(int id)
        {
            var taskRemove = _context.Tasks.FirstOrDefault(x => x.id == id);

            if (taskRemove != null) {
                _context.Tasks.Remove(taskRemove);
                _context.SaveChanges();
            }
        }
    }
}
