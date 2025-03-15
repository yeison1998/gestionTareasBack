using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Task
    {
        public int id { get; set; }
        public bool isCompleted { get; set; }
        public bool isImportant { get; set; }
        public string description { get; set; }
    }
}

