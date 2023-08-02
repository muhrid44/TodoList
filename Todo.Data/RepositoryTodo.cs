using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;
using Todo.Data.Interface;
using Todo.Helper;
using Todo.Model;

namespace Todo.Data
{
    public class RepositoryTodo : IRepositoryTodo
    {
        public async Task<List<TodoModel>> GetAllTodo(SortingModel sorting)
        {
            List<TodoModel> Todo = new List<TodoModel>();

            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                //var query = from TodoTable in dbContext.TodoTable
                //            join PriorityTable in dbContext.PriorityTable on TodoTable.PriorityId equals PriorityTable.Id
                //            select new TodoModel
                //            {
                //                Id = TodoTable.Id,
                //                Todo = TodoTable.Todo,
                //                PriorityId = TodoTable.PriorityId,
                //                CreatedDate = TodoTable.CreatedDate,
                //                FinishDate = TodoTable.FinishDate,
                //                IsDone = TodoTable.IsDone,
                //                PriorityModel = PriorityTable
                //            };

                //Todo = await query.ToListAsync();

                if (sorting.SortType == "-")
                {
                    sorting.SortType = "ASC";
                }
                if(sorting.SortBy == "-")
                {
                    sorting.SortBy = "PriorityId";
                }

                var query = @$"SELECT tt.*, pt.Priority FROM [TodoTable] as tt
                            INNER JOIN [PriorityTable] as pt ON tt.PriorityId = pt.Id 
                            ORDER BY {sorting.SortBy} {sorting.SortType}";


                var exec = await db.QueryAsync<TodoModel>(query);

                return exec.ToList();

            }
        }
        public async Task CreateTodo (TodoModel data)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                var query = @"";
            }
        }
        public async Task UpdateTodo(TodoModel data)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {

            }

        }
        public async Task UpdateTodoChecklistOnly(TodoModel data)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                //TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(data.Id);

                //if (DataSelectedById != null)
                //{
                //    DataSelectedById.IsDone = data.IsDone;

                //    await dbContext.SaveChangesAsync();
                //}
            }

        }

        public async Task<TodoModel> GetDataById(int Id)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                //TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(Id);

                //return DataSelectedById;

                return null;

            }

        }

        public async Task DeleteById(int Id)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                //TodoModel? DataSelectedById = await dbContext.TodoTable.FindAsync(Id);

                //if(DataSelectedById != null)
                //{
                //    dbContext.TodoTable.Remove(DataSelectedById);

                //    await dbContext.SaveChangesAsync();

                }

            }

        }



}
