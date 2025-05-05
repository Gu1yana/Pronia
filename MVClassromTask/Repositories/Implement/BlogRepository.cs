using Dapper;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Data.SqlClient;
using MVClassromTask.Constants;
using MVClassromTask.Models;
using MVClassromTask.Repositories.Abstractions;

namespace MVClassromTask.Repositories.Implement
{
    public class BlogRepository : IBlogRepository
    {
        private SqlConnection _connection { get => new SqlConnection(ConnectionStrings._connString); }
        public async Task AddAsync(Blog entity)
        {
            using var db = _connection;

            await db.ExecuteAsync("INSERT INTO Blogs VALUES (@Title, @Description, @Price, @ImagePath )", entity);
        }
        public async Task DeleteAsync(int id)
        {
            using var db = _connection;

            await db.ExecuteAsync("Delete From Blogs Where Id=@Id", new { id });
        }
        public async Task<List<Blog>> GetAllAsync()
        {
            using var db = _connection;
            var list = await db.QueryAsync<Blog>("Select*From Blogs");
            return list.ToList();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            using var db = _connection;
            var Blog = await db.QueryFirstOrDefaultAsync<Blog>("Select*From Blogs Where Id=@Id", new { id });
            return Blog;
        }

        public async Task UpdateAsync(int id, Blog entity)
        {
            using var db = _connection;
            await db.ExecuteAsync("Update Blogs Set Title=@Title, Description=@Description, Price=@Price, ImagePath=@ImagePath Where Id=@Id");
        }
    }
}
