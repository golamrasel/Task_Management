using AutoMapper;
using AutoWrapper.Wrappers;
using Common.Dtos.TaskDTOs;
using Common.Helper;
using Common.IServices;
using Models.Models.TaskInfo;
using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Setup
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskInfo> _repository;
        private readonly ITaskManager _manager;
        private readonly IMapper _mapper;
        private IUnitOfWork _work;

        public TaskService(IRepository<TaskInfo> repository, ITaskManager manager, IMapper mapper, IUnitOfWork work)
        {
            _manager = manager;
            _repository = repository;
            _mapper = mapper;
            _work = work;
        }
        public async Task<ApiResponse> Add(TaskDTO input)
        {
            var entity = _mapper.Map<TaskInfo>(input);

            try
            {
                var type = new TaskInfo();
                entity.TaskType = type.GetTaskType(entity.TaskType);
                entity.Status = type.GetTaskType(entity.Status);
                entity = await _manager.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateErrorResponse(ex.Message);
            }
            await _repository.InsertAsync(entity);
            await _work.Complete();

            return ResponseHelper.CreateAddSuccessResponse();
        }

        public Task<ApiResponse> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetAll(TaskFilterDTO taskFilterDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(TaskDTO task)
        {
            throw new NotImplementedException();
        }
    }
}
