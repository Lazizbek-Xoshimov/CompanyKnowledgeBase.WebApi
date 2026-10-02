using Brokers;
using Models.Exceptions;
using Models.Folders;

namespace Services.Folders;

public class FolderService : IFolderService
{
    private readonly IStorageBroker storageFolder;

    public FolderService()
    {
        storageFolder = new StorageBroker();
    }

    public async Task<bool> AddFolderAsync(Folder folder)
    {
        var folders = await RetriveAllFolderAsync();

        if (folders.Any(existingFolder => existingFolder.Id == folder.Id))
            throw new ValidationException($"{folder.Id} folder is exsits.", "Use another folder Id.");

        return await storageFolder.InsertFolderAsync(folder);
    }

    public async Task<IEnumerable<Folder>> RetriveAllFolderAsync()
    {
        return await storageFolder.SelectAllFolderAsync();
    }

    public async Task<Folder> RetriveFolderByIdAsync(Guid folderId)
    {
        var folder = await storageFolder.SelectFolderByIdAsync(folderId);

        if (folder is null)
            throw new NotFoundException($"{folderId} folder was not found.", "Use a different Id");

        return folder;
    }

    public async Task<bool> UpdateFolderAsync(Folder folder)
    {
        var existingFolder = await storageFolder.SelectFolderByIdAsync(folder.Id);

        if (existingFolder is null)
            throw new NotFoundException($"{folder.Id} folder was not found.", "Use a different Id");

        return await storageFolder.UpdateFolderAsync(folder);
    }

    public async Task<bool> DeleteFolderAsync(Guid folderId)
    {
        var existingFolder = await storageFolder.SelectFolderByIdAsync(folderId);

        if (existingFolder is null)
            throw new NotFoundException($"{folderId} folder was not found.", "Use a different Id");

        return await storageFolder.DeleteFolderAsync(folderId);
    }
}
