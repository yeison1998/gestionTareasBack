using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.interfaces
{
    public interface ITaskRepository
    {
        List<Data.Models.Task> GetTasks();
        Data.Models.Task GetTaskById(int id);
        void AddTask(Data.Models.Task newTask);
        void UpdateTask(Data.Models.Task updateTask);
        void DeteleTask(int id);

    }
}
