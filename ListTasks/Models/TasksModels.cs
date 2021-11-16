using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListTasks.Models
{
    public class TasksModels
    {

        public int Id { get; set; }
        public string Tarefa { get; set; }
        public string Concluida { get; set; }
        public DateTime Date { get; set; }
    }
}
