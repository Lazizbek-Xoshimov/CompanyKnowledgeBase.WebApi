using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Models.Projects;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertProjectAsync(Project project)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        
        var queryInsert = "INSERT INTO Projects (Id, Name, Desctiption, CreatedBy, CreatedDate, UpdatedDate) VALUES (@Id, @Name, @Desctiption, @CreatedBy, @CreatedDate, @UpdatedDate)";
        var executedRowCount = await connection.ExecuteAsync(queryInsert, new {Id = project.Id, Name = project.Name, Desctiption = project.Description, CreatedBy = project.CreatedByUserId, CreatedDate = project.CreatedDate, UpdatedDate = project.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<IEnumerable<Project>> SelectAllProjectAsync()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var querySelectAll = "SELECT * FROM Projects;";
        return await connection.QueryAsync<Project>(querySelectAll);
    }

    public async Task<Project> SelectProjectById(int projectId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var querySelectById = "SELECT * FROM Projects WHERE ID = @projectId";
        return await connection.QueryFirstOrDefaultAsync<Project>(querySelectById, new { projectId });
    }

    public async Task<int> GetProjectCount()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var querySelectCount = "SELECT COUNT(*) FROM Projects";
        return await connection.ExecuteScalarAsync<int>(querySelectCount);
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var queryUpdate = "UPDATE Projects SET Name = @Name, Description = @Description, CreatedBy = @CreatedByUserId, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate WHERE Id = @Id";
        var executedRowCount = await connection.ExecuteAsync(queryUpdate, new { Id = project.Id, Name = project.Name, Description = project.Description, CreatedByUserId = project.CreatedByUserId, CreatedDate = project.CreatedDate, UpdatedDate = project.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        var queryDelete = "DELETE FROM Projects WHERE Id = @projectId";
        var executedRowCount = await connection.ExecuteAsync(queryDelete, new { Id = projectId });

        return executedRowCount > 0;
    }
}