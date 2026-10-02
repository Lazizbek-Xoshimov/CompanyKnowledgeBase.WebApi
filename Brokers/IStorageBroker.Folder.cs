using Models.Folders;

namespace Brokers;

public partial interface IStorageBroker
{
    public Task<bool> InsertFolderAsync(Folder folder);
    public Task<IEnumerable<Folder>> SelectAllFolderAsync();
    public Task<Folder> SelectFolderByIdAsync(Guid folderId);
    public Task<bool> UpdateFolderAsync(Folder folder);
    public Task<bool> DeleteFolderAsync(Guid folderId);
}
