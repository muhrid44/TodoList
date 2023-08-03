using Dapper;
using Microsoft.Data.SqlClient;
using System;
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
                var query = @"INSERT INTO [TodoTable](Todo, PriorityId, CreatedDate, FinishDate, IsDone)
                              VALUES (@Todo, @PriorityId, @CreatedDate, @FinishDate, @IsDone)";

                var exec = await db.ExecuteAsync(query, data);
            }
        }
        public async Task UpdateTodo(TodoModel data)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                var query = @"UPDATE [TodoTable]
                            SET [Todo] = @Todo,
                            [PriorityId] = @PriorityId,
                            [FinishDate] = @FinishDate
                            WHERE Id = @Id";

                var exec = await db.ExecuteAsync(query, data);
            }

        }
        public async Task UpdateTodoChecklistOnly(TodoModel data)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                var query = @"UPDATE [TodoTable]
                            SET [IsDone] = @IsDone
                            WHERE Id = @Id";

                var exec = await db.ExecuteAsync(query, data);
            }

        }

        public async Task<TodoModel> GetDataById(int Id)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                var query = @$"SELECT tt.*, pt.Priority FROM [TodoTable] as tt
                            INNER JOIN [PriorityTable] as pt ON tt.PriorityId = pt.Id 
                            WHERE tt.Id = {Id}";

                var exec = await db.QueryAsync<TodoModel>(query);

                return exec.FirstOrDefault();
            }

        }

        public async Task DeleteById(int Id)
        {
            using (var db = new SqlConnection(StaticHelper.ConnectionString))
            {
                var query = @$"DELETE FROM [TodoTable]
                            WHERE [Id] = {Id}";

                var exec = await db.ExecuteAsync(query);

            }

        }

        }



}
