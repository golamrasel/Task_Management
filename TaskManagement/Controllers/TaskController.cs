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