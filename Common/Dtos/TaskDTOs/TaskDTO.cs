using Common.DTOs;
using Common.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos.TaskDTOs
{
    public class TaskDTO:PagedRequestDTO
    {
        public int Id { get; set; }
        public TaskType TaskType { get; set; }
        public string TaskName { get; set; }
        public TaskType Status { get; set; }
        public DateTime Time { get; set; }
    }
}
