using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ViewModels.TaskViewModels
{
    public class TaskViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string TaskType { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
    }
}
