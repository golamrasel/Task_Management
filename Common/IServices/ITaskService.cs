using AutoWrapper.Wrappers;
using Common.Dtos.TaskDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.IServices
{
    public interface ITaskService
    {
        Task<ApiResponse> GetAll(TaskFilterDTO taskFilterDTO);
        Task<ApiResponse> Add(TaskDTO taskDTO);
        Task<ApiResponse> Update(TaskDTO task);
        Task<ApiResponse> GetById(int id);
        Task<ApiResponse> Search(string searchText);
        Task<ApiResponse> Delete(int Id);
    }
}
