using CompanyKnowledgeBase.WebApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CompanyKnowledgeBase.WebApi.Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertUserAsync(User user)
    {
        using IDbConnection connection = new SqlConnection(_context);

        var queryInsert = """
                INSERT INTO 
                    Users (FirstName, LastName, Email, UserRole, Password, CreatedDate, UpdatedDate) 
                    VALUES 
                (@FirstName, @LastName, @Email, @UserRole, @Password, @CreatedDate, @UpdatedDate)
                """;
            
        var executedRowCount = await connection.ExecuteAsync(
            queryInsert, 
            new 
            { 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Email = user.Email, 
                UserRole = user.UserRole.ToString(), 
                Password = user.Password, 
                CreatedDate = user.CreatedDate, 
                UpdatedDate = user.UpdatedDate 
            });

        return executedRowCount > 0;
    }

    public async Task<IEnumerable<User>> SelectAllUserAsync()
    {
        using IDbConnection connection = new SqlConnection(_context);

        var querySelectAll = "SELECT * FROM Users;";
        return await connection.QueryAsync<User>(querySelectAll);
    }
    public async Task<User> SelectUserById(int id)
    {
        using IDbConnection connection = new SqlConnection(_context);

        var querySelectById = "SELECT * FROM Users WHERE Id = @id";
        return await connection.QueryFirstOrDefaultAsync<User>(querySelectById, new { id });
    }

    public async Task<bool> UpdateUserAsync(int userId, User user)
    {
        using IDbConnection connection = new SqlConnection(_context);

        var queryUpdate = """
            UPDATE 
                Users 
            SET 
                FirstName = @FirstName, 
                LastName = @LastName, 
                Email = @Email, 
                UserRole = @UserRole, 
                Password = @Password, 
                CreatedDate = @CreatedDate, 
                UpdatedDate = @UpdatedDate 
            WHERE Id = @Id;
            """;
            
        var executedRowCount = await connection.ExecuteAsync(
            queryUpdate, 
            new 
            { 
                Id = userId, 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Email = user.Email, 
                UserRole = user.UserRole.ToString(), 
                Password = user.Password, 
                CreatedDate = user.CreatedDate, 
                UpdatedDate = user.UpdatedDate 
            });

        return executedRowCount > 0;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        using IDbConnection connection = new SqlConnection(_context);

        var queryDelete = "DELETE FROM Users WHERE Id = @userId";
        var executedRowCount = await connection.ExecuteAsync(queryDelete, new { userId = userId });

        return executedRowCount > 0;
    }
}
