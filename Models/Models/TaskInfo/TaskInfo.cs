using Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.TaskInfo
{
    public class TaskInfo:BaseModel
    {
        public int Id { get; set; }
        public string TaskType { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }


        public string GetTaskType(string type)
        {
            if(type == Convert.ToString(TaskEnum.Bug))
            {
                return Convert.ToString((int)TaskEnum.Bug);
            }
            else if (type == Convert.ToString(TaskEnum.Done))
            {
                return Convert.ToString((int)TaskEnum.Done);
            }
            else if (type == Convert.ToString(TaskEnum.Feature))
            {
                return Convert.ToString((int)TaskEnum.Feature);
            }
            else if (type == Convert.ToString(TaskEnum.Improvement))
            {
                return Convert.ToString((int)TaskEnum.Improvement);
            }
            else if (type == Convert.ToString(TaskEnum.Inprogress))
            {
                return Convert.ToString((int)TaskEnum.Inprogress);
            }
            else if (type == Convert.ToString(TaskEnum.Notstarted))
            {
                return Convert.ToString((int)TaskEnum.Notstarted);
            }
            else if (type == Convert.ToString(TaskEnum.Skipped))
            {
                return Convert.ToString((int)TaskEnum.Skipped);
            }
            return "";
        }

    }
}
