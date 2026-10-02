using Models.Projects;

namespace Services.Projects;

public interface IProjectService
{
    public Task<bool> AddProjectAsync(Project project);
    public Task<IEnumerable<Project>> RetriveAllProjectAsync();
    public Task<Project> RetriveProjectById(int id);
    public Task<bool> UpdateProjectAsync(Project project);
    public Task<bool> DeleteProjectAsync(int projectId);
}