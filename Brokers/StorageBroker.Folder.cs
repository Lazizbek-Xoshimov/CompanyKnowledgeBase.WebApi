using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Models.Folders;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertFolderAsync(Folder folder)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = """
            INSERT INTO Folders
                (Id, Name, ProjectId, ParentFolderId, CreatedDate, UpdatedDate)
            VALUES
                (@Id, @Name, @ProjectId, @ParentFolderId, @CreatedDate, @UpdatedDate)
            """;

        var executedRowCount = await connection.ExecuteAsync(query, folder);
        return executedRowCount > 0;
    }

    public async Task<IEnumerable<Folder>> SelectAllFolderAsync()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = "SELECT * FROM Folders";
        return await connection.QueryAsync<Folder>(query);
    }

    public async Task<Folder> SelectFolderByIdAsync(Guid folderId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = "SELECT * FROM Folders WHERE Id = @folderId";
        return await connection.QueryFirstOrDefaultAsync<Folder>(query, new { folderId });
    }

    public async Task<bool> UpdateFolderAsync(Folder folder)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = """
            UPDATE Folders
            SET Name = @Name,
                ProjectId = @ProjectId,
                ParentFolderId = @ParentFolderId,
                CreatedDate = @CreatedDate,
                UpdatedDate = @UpdatedDate
            WHERE Id = @Id
            """;

        var executedRowCount = await connection.ExecuteAsync(query, folder);
        return executedRowCount > 0;
    }

    public async Task<bool> DeleteFolderAsync(Guid folderId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = "DELETE FROM Folders WHERE Id = @folderId";
        var executedRowCount = await connection.ExecuteAsync(query, new { folderId });
        return executedRowCount > 0;
    }
}
