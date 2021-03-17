using Common.DTOs;
using Common.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos.TaskDTOs
{
    public class TaskFilterDTO:PagedRequestDTO
    {
        public string TaskType { get; set; }
        public string Status { get; set; }
        public string SearchText { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public DateTime SevenDays { get; set; } = DateTime.Today.AddDays(-6);
        public TaskType ActiveTask { get; set; } = Common.Tasks.TaskType.Inprogress;
        public TaskType DoneTask { get; set; } = Common.Tasks.TaskType.Done;
    }
}
