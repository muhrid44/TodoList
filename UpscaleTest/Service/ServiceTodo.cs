using Microsoft.AspNetCore.Mvc;
using UpscaleTest.Models;
using UpscaleTest.Repository;

namespace UpscaleTest.Service
{
    public class ServiceTodo : IServiceTodo
    {
        private readonly IRepositoryTodo _repositoryTodo;

        public ServiceTodo(IRepositoryTodo repositoryTodo)
        {
            _repositoryTodo = repositoryTodo;
        }
        public async Task<List<TodoModel>> GetAllTodo(SortingModel sorting)
        {
            List<TodoModel> result = await _repositoryTodo.GetAllTodo(sorting);
            return result;

        }
        public async Task CreateTodo(TodoModel data)
        {
            DateTime createdDateToday = DateTime.Today.Date;
            data.CreatedDate = createdDateToday;
            await _repositoryTodo.CreateTodo(data);
        }

        public async Task UpdateTodo(TodoModel data)
        {
            await _repositoryTodo.UpdateTodo(data);
        }
        public async Task UpdateTodoChecklistOnly(TodoModel data)
        {
            await _repositoryTodo.UpdateTodoChecklistOnly(data);

        }

        public async Task<TodoModel> GetDataById(int Id)
        {
            return await _repositoryTodo.GetDataById(Id);
        }
        public async Task DeleteById(int Id)
        {
            await _repositoryTodo.DeleteById(Id);
        }


    }
}
