using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.TaskInfo
{
    public interface ITaskManager
    {
        Task<TaskInfo> CreateAsync(TaskInfo entity);
    }
}
