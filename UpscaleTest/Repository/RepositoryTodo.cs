using Microsoft.EntityFrameworkCore;
using System.Linq;
using UpscaleTest.Models;

namespace UpscaleTest.Repository
{
    public class RepositoryTodo : IRepositoryTodo
    {
        public async Task<List<TodoModel>> GetAllTodo(SortingModel sorting)
        {
            List<TodoModel> Todo = new List<TodoModel>();

            using (var dbContext = new MyDbContextModel())
            {
                var query = from TodoTable in dbContext.TodoTable
                            join PriorityTable in dbContext.PriorityTable on TodoTable.PriorityId equals PriorityTable.Id
                            select new TodoModel
                            {
                                Id = TodoTable.Id,
                                Todo = TodoTable.Todo,
                                PriorityId = TodoTable.PriorityId,
                                CreatedDate = TodoTable.CreatedDate,
                                FinishDate = TodoTable.FinishDate,
                                IsDone = TodoTable.IsDone,
                                PriorityModel = PriorityTable
                            };

                Todo = await query.ToListAsync();

                if (sorting.SortType == "DESC")
                {
                    if (sorting.SortBy == "CreatedDate")
                    {
                        Todo = Todo.OrderByDescending(order => order.CreatedDate).ToList();
                    } else
                    if (sorting.SortBy == "Priority")
                    {
                        Todo = Todo.OrderByDescending(order => order.PriorityId).ToList();
                    } else
                    {
                        Todo = Todo.OrderByDescending(order => order.Id).ToList();

                    }
                } else
                {
                    if (sorting.SortBy == "CreatedDate")
                    {
                        Todo = Todo.OrderBy(order => order.CreatedDate).ToList();
                    } else
                    if (sorting.SortBy == "Priority")
                    {
                        Todo = Todo.OrderBy(order => order.PriorityId).ToList();
                    }
                    else
                    {
                        Todo = Todo.OrderByDescending(order => order.CreatedDate).ToList();
                    }
                }

                    return Todo;
            }
        }
        public async Task CreateTodo (TodoModel data)
        {
            using (var dbContext = new MyDbContextModel())
            {
                await dbContext.TodoTable.AddAsync(data);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateTodo(TodoModel data)
        {
            using (var dbContext = new MyDbContextModel())
            {
                TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(data.Id);

                if (DataSelectedById != null)
                {
                    DataSelectedById.Todo = data.Todo;
                    DataSelectedById.PriorityId = data.PriorityId;
                    DataSelectedById.FinishDate = data.FinishDate;

                    await dbContext.SaveChangesAsync();
                }
            }

        }
        public async Task UpdateTodoChecklistOnly(TodoModel data)
        {
            using (var dbContext = new MyDbContextModel())
            {
                TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(data.Id);

                if (DataSelectedById != null)
                {
                    DataSelectedById.IsDone = data.IsDone;

                    await dbContext.SaveChangesAsync();
                }
            }

        }

        public async Task<TodoModel> GetDataById(int Id)
        {
            using (var dbContext = new MyDbContextModel())
            {
                TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(Id);

                return DataSelectedById;

            }

        }

        public async Task DeleteById(int Id)
        {
            using (var dbContext = new MyDbContextModel())
            {
                TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(Id);

                if(DataSelectedById != null)
                {
                    dbContext.TodoTable.Remove(DataSelectedById);

                    await dbContext.SaveChangesAsync();

                }

            }

        }



    }
}
