using Models.Pages;

namespace Brokers;

public partial interface IStorageBroker
{
    public Task<bool> InsertPageAsync(Page page);
    public Task<IEnumerable<Page>> SelectAllPageAsync();
    public Task<Page> SelectPageByIdAsync(Guid pageId);
    public Task<bool> UpdatePageAsync(Page page);
    public Task<bool> DeletePageAsync(Guid pageId);
}
