using Common.Tasks;
using Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.TaskInfo
{
    public class TaskInfo:BaseModel
    {
        public int Id { get; set; }
        public TaskType TaskType { get; set; }
        public string TaskName { get; set; }
        public TaskType Status { get; set; }
        public DateTime Time { get; set; }
    }
}
