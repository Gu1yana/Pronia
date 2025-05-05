using Dapper;
using Microsoft.Data.SqlClient;
using MVClassromTask.Constants;
using MVClassromTask.Models;
using MVClassromTask.Repositories.Abstractions;

namespace MVClassromTask.Repositories.Implement
{
    public class SliderRepository : ISliderRepository
    {
        private SqlConnection _connection { get => new SqlConnection(ConnectionStrings._connString); }
        public async Task AddAsync(Slider entity)
        {
            using var db = _connection;

            await db.ExecuteAsync("INSERT INTO Sliders VALUES (@Title, @Description, @Price, @ImagePath )", entity);
        }
        public async Task DeleteAsync(int id)
        {
            using var db=_connection;

            await db.ExecuteAsync("Delete From Sliders Where Id=@Id", new { id });  
        }
        public async Task<List<Slider>> GetAllAsync()
        {
            using var db=_connection;
            var list = await db.QueryAsync<Slider>("Select*From Sliders");
            return list.ToList();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            using var db= _connection;
            var slider=await db.QueryFirstOrDefaultAsync<Slider>("Select*From Sliders Where Id=@Id", new {id});
            return slider;
        }

        public async Task UpdateAsync(int id, Slider entity)
        {
            using var db= _connection;
            await db.ExecuteAsync("Update Sliders Set Title=@Title, Description=@Description, Price=@Price, ImagePath=@ImagePath Where Id=@Id");
        }
    }
}
