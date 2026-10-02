using Models.Folders;

namespace Services.Folders;

public interface IFolderService
{
    public Task<bool> AddFolderAsync(Folder folder);
    public Task<IEnumerable<Folder>> RetriveAllFolderAsync();
    public Task<Folder> RetriveFolderByIdAsync(Guid folderId);
    public Task<bool> UpdateFolderAsync(Folder folder);
    public Task<bool> DeleteFolderAsync(Guid folderId);
}
