using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.TaskInfo
{
    public class TaskManager:ITaskManager
    {
        private readonly IRepository<TaskInfo> _repository;

        public TaskManager(IRepository<TaskInfo> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TaskInfo> CreateAsync(TaskInfo entity)
        {
            Check.NotNull(entity, nameof(entity));
            Check.NotNull(entity.TaskName, nameof(entity.TaskName));

            await ValidateAsync(entity.TaskName, entity.Id);

            return entity;
        }

        protected virtual async Task ValidateAsync(string name, int id = 0)
        {
            var entity = await _repository.FindAsync(x => x.TaskName == name);
            if (entity != null && entity.Id != id)
            {
                throw new DuplicateNameException("Duplicate category name: " + name);
            }
        }
    }
}
