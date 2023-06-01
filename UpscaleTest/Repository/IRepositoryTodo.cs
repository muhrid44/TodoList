using UpscaleTest.Models;

namespace UpscaleTest.Repository
{
    public interface IRepositoryTodo
    {
        Task<List<TodoModel>> GetAllTodo(SortingModel sorting);
        Task CreateTodo(TodoModel data);
        Task UpdateTodo(TodoModel data);
        Task UpdateTodoChecklistOnly(TodoModel data);
        Task<TodoModel> GetDataById(int Id);
        Task DeleteById(int Id);


    }
}
