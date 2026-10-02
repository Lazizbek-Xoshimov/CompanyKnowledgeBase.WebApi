using Brokers;
using Models.Projects;
using Models.Exceptions;

namespace Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IStorageBroker storageProject;

    public ProjectService()
    {
        storageProject = new StorageBroker();
    }

    public async Task<bool> AddProjectAsync(Project project)
    {
        var projects = await RetriveAllProjectAsync();

        if (projects.Select(p => p.Id).Contains(project.Id))
            throw new ValidationException($"{project.Id} project is exsits.", "Use another project Id.");

        return await storageProject.InsertProjectAsync(project);
    }

    public async Task<IEnumerable<Project>> RetriveAllProjectAsync()
    {
        return await storageProject.SelectAllProjectAsync();  
    }

    public async Task<Project> RetriveProjectById(int id)
    {
        var product = await storageProject.SelectProjectById(id);

        if (product is null)
            throw new NotFoundException($"{id} project was not found.", "Use a different Id");
        
        return product;
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        var projects = await storageProject.SelectAllProjectAsync();

        if (!projects.Select(p => p.Id).Contains(project.Id))
            throw new NotFoundException($"{project.Id} project is not exsits.", "Use another project Id.");

        return await storageProject.UpdateProjectAsync(project);
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        var projects = await storageProject.SelectAllProjectAsync();

        if (!projects.Select(p => p.Id).Contains(projectId))
            throw new NotFoundException($"{projectId} project is exsits.", "Use another project Id.");

        return await storageProject.DeleteProjectAsync(projectId);
    }
}