using Brokers;
using Models.Exceptions;
using Models.Pages;

namespace Services.Pages;

public class PageService : IPageService
{
    private readonly IStorageBroker storagePage;

    public PageService()
    {
        storagePage = new StorageBroker();
    }

    public async Task<bool> AddPageAsync(Page page)
    {
        var pages = await RetriveAllPageAsync();

        if (pages.Any(existingPage => existingPage.Id == page.Id))
            throw new ValidationException($"{page.Id} page is exsits.", "Use another page Id.");

        if (pages.Any(existingPage => existingPage.Name == page.Name))
            throw new ValidationException($"{page.Name} page is exsits.", "Use another page name.");

        return await storagePage.InsertPageAsync(page);
    }

    public async Task<IEnumerable<Page>> RetriveAllPageAsync()
    {
        return await storagePage.SelectAllPageAsync();
    }

    public async Task<Page> RetrivePageByIdAsync(Guid pageId)
    {
        var page = await storagePage.SelectPageByIdAsync(pageId);

        if (page is null)
            throw new NotFoundException($"{pageId} page was not found.", "Use a different Id");

        return page;
    }

    public async Task<bool> UpdatePageAsync(Page page)
    {
        var existingPage = await storagePage.SelectPageByIdAsync(page.Id);

        if (existingPage is null)
            throw new NotFoundException($"{page.Id} page was not found.", "Use a different Id");

        var pagesWithSameName = await storagePage.SelectAllPageAsync();
        if (pagesWithSameName.Any(existingPageWithSameName =>
                existingPageWithSameName.Name == page.Name &&
                existingPageWithSameName.Id != page.Id))
            throw new ValidationException($"{page.Name} page is exsits.", "Use another page name.");

        return await storagePage.UpdatePageAsync(page);
    }

    public async Task<bool> DeletePageAsync(Guid pageId)
    {
        var existingPage = await storagePage.SelectPageByIdAsync(pageId);

        if (existingPage is null)
            throw new NotFoundException($"{pageId} page was not found.", "Use a different Id");

        return await storagePage.DeletePageAsync(pageId);
    }
}
