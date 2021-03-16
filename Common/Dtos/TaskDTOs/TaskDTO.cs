using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos.TaskDTOs
{
    public class TaskDTO:PagedRequestDTO
    {
        public int Id { get; set; }
        public string TaskType { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
    }
}
