using Models.Pages;

namespace Services.Pages;

public interface IPageService
{
    public Task<bool> AddPageAsync(Page page);
    public Task<IEnumerable<Page>> RetriveAllPageAsync();
    public Task<Page> RetrivePageByIdAsync(Guid pageId);
    public Task<bool> UpdatePageAsync(Page page);
    public Task<bool> DeletePageAsync(Guid pageId);
}
