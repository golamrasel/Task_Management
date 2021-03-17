using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using AutoWrapper.Wrappers;
using Common.Dtos.TaskDTOs;
using Common.IServices;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("GetAll")]
        public async Task<ApiResponse> GetAll([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.GetAll(task);
        }

        [HttpGet("GetTodaysTask")]
        public async Task<ApiResponse> GetTodaysTask([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.GetTodaysTask(task);
        }
        [HttpGet("LastSevendaysTask")]
        public async Task<ApiResponse> LastSevendaysTask([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.LastSevendaysTask(task);
        }
        [HttpGet("LastSevendaysActiveTask")]
        public async Task<ApiResponse> LastSevendaysActiveTask([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.LastSevendaysActiveTask(task);
        }
        [HttpGet("CompletedTask")]
        public async Task<ApiResponse> CompletedTask([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.CompletedTask(task);
        }

        [HttpGet("PendingTask")]
        public async Task<ApiResponse> PendingTask([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.PendingTask(task);
        }
        [HttpGet("ProcessingTask")]
        public async Task<ApiResponse> ProcessingTask([FromQuery] TaskFilterDTO task)
        {
            return await _taskService.PendingTask(task);
        }

        [HttpPost("Add")]
        public async Task<ApiResponse> Add(TaskDTO product)
        {
            return await _taskService.Add(product);
        }
        [HttpGet("GetById")]
        public async Task<ApiResponse> GetById(int id)
        {
            return await _taskService.GetById(id);
        }
        [HttpPut("Update")]
        public async Task<ApiResponse> Update([FromBody] TaskDTO user)
        {
            return await _taskService.Update(user);
        }
    }
}