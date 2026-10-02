using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Models.Pages;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertPageAsync(Page page)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = """
            INSERT INTO Pages
                (Id, Name, ProjectId, FolderId, CurrentVersionId, CreatedBy, CreatedDate, UpdatedDate)
            VALUES
                (@Id, @Name, @ProjectId, @FolderId, @CurrentVersionId, @CreatedBy, @CreatedDate, @UpdatedDate)
            """;

        var executedRowCount = await connection.ExecuteAsync(query, page);
        return executedRowCount > 0;
    }

    public async Task<IEnumerable<Page>> SelectAllPageAsync()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = "SELECT * FROM Pages";
        return await connection.QueryAsync<Page>(query);
    }

    public async Task<Page> SelectPageByIdAsync(Guid pageId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = "SELECT * FROM Pages WHERE Id = @pageId";
        return await connection.QueryFirstOrDefaultAsync<Page>(query, new { pageId });
    }

    public async Task<bool> UpdatePageAsync(Page page)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = """
            UPDATE Pages
            SET Name = @Name,
                ProjectId = @ProjectId,
                FolderId = @FolderId,
                CurrentVersionId = @CurrentVersionId,
                CreatedBy = @CreatedBy,
                CreatedDate = @CreatedDate,
                UpdatedDate = @UpdatedDate
            WHERE Id = @Id
            """;

        var executedRowCount = await connection.ExecuteAsync(query, page);
        return executedRowCount > 0;
    }

    public async Task<bool> DeletePageAsync(Guid pageId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        const string query = "DELETE FROM Pages WHERE Id = @pageId";
        var executedRowCount = await connection.ExecuteAsync(query, new { pageId });
        return executedRowCount > 0;
    }
}
