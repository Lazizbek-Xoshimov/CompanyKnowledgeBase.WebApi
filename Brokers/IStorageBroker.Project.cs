using Models.Projects;

namespace Brokers;

public partial interface IStorageBroker
{
    public Task<bool> InsertProjectAsync(Project project);
    public Task<IEnumerable<Project>> SelectAllProjectAsync();
    public Task<Project> SelectProjectById(int projectId);
    public Task<int> GetProjectCount();
    public Task<bool> UpdateProjectAsync(Project project);
    public Task<bool> DeleteProjectAsync(int projectId);
}