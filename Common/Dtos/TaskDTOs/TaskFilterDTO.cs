using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos.TaskDTOs
{
    public class TaskFilterDTO:PagedRequestDTO
    {
        public string TaskType { get; set; }
        public string Status { get; set; }
    }
}
