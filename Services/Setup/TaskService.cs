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
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.Responses;
using Common.ViewModels.TaskViewModels;
using System.Threading;
using Common;

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

        public async Task<ApiResponse> GetAll(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
                WhereIf(!taskFilter.SearchText.IsNullOrWhiteSpace(), x => x.TaskName.Contains(taskFilter.SearchText)).
                PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }

        public async Task<ApiResponse> GetById(int id)
        {
            var smartFolder = await _repository.FindAsync(r => r.Id == id, true, default(CancellationToken));
            if (smartFolder == null)
                return ResponseHelper.CreateErrorResponse(string.Format(Constants.NotFound, "Smart Folder"));

            var TaskViewModel = _mapper.Map<TaskViewModel>(smartFolder);

            return ResponseHelper.CreateGetSuccessResponse(TaskViewModel);
        }

        public async Task<ApiResponse> GetTodaysTask(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
               WhereIf(taskFilter.Time != null, r => r.Time.Date == taskFilter.Time.Date).
               PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }

        public async Task<ApiResponse> LastSevendaysTask(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
               WhereIf(taskFilter.SevenDays != null, r => r.Time.Date >= taskFilter.SevenDays.Date).
               PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }
        public Task<ApiResponse> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> Update(TaskDTO task)
        {
            var entity = await _repository.GetAsync(task.Id);
            if (entity == null)
                return ResponseHelper.CreateErrorResponse(string.Format(Constants.NotFound, task.TaskName));

            var type = new TaskInfo();
            entity.TaskName = task.TaskName;
            entity.Time = task.Time;
            try
            {
                entity = await _manager.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateErrorResponse(ex.Message);
            }
            await _repository.UpdateAsync(entity);
            await _work.Complete();

            return ResponseHelper.CreateUpdateSuccessResponse();
        }

        public async Task<ApiResponse> LastSevendaysActiveTask(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
                WhereIf(taskFilter.SevenDays != null, r => r.Time.Date >= taskFilter.SevenDays.Date).
                WhereIf(taskFilter.ActiveTask != 0, r => r.Status == taskFilter.ActiveTask).
                PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }

        public async Task<ApiResponse> CompletedTask(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
                WhereIf(taskFilter.DoneTask != 0, r => r.Status >= taskFilter.DoneTask).
                PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }

        public async Task<ApiResponse> PendingTask(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
                 WhereIf(taskFilter.DoneTask != 0, r => r.Status != taskFilter.DoneTask).
                 PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }
        public async Task<ApiResponse> ProcessingTask(TaskFilterDTO taskFilter)
        {
            var query = _repository.GetQueryable().
                 WhereIf(taskFilter.DoneTask != 0, r => r.Status == taskFilter.ActiveTask).
                 PageBy(taskFilter);

            var pagedResult = await query.ToListAsync();
            Result<TaskInfo> result = new Result<TaskInfo>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<TaskViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }
    }
}
