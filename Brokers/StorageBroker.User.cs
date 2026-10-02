using Models.Users;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertUserAsync(User user)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        
        var queryInsert = "INSERT INTO Users (Id, FirstName, LastName, Email, UserRole, Password, CreatedDate, UpdatedDate) VALUES (@Id, @FirstName, @LastName, @Email, @UserRole, @Password, @CreatedDate, @UpdatedDate)";
        var executedRowCount = await connection.ExecuteAsync(queryInsert, new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, UserRole = user.UserRole.ToString(), Password = user.PasswordHash, CreatedDate = user.CreatedDate, UpdatedDate = user.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<IEnumerable<User>> SelectAllUserAsync()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var querySelectAll = "SELECT * FROM Users;";
        return await connection.QueryAsync<User>(querySelectAll);
    }
    public async Task<User> SelectUserById(int id)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var querySelectById = "SELECT * FROM Users WHERE Id = @id";
        return await connection.QueryFirstOrDefaultAsync<User>(querySelectById, new { id });
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var queryUpdate = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, UserRole = @UserRole, Password = @Password, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate WHERE Id = @Id";
        var executedRowCount = await connection.ExecuteAsync(queryUpdate, new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, UserRole = user.UserRole, Password = user.PasswordHash, CreatedDate = user.CreatedDate, UpdatedDate = user.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var queryDelete = "DELETE FROM Users WHERE Id = @userId";
        var executedRowCount = await connection.ExecuteAsync(queryDelete, new { Id = userId });

        return executedRowCount > 0;
    }
}