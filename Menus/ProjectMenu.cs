using Models.Projects;
using Services.Projects;

namespace Menus;

public class ProjectMenu
{
    static IProjectService projectService;

    public ProjectMenu()
    {
        projectService = new ProjectService();
    }

    public async Task AddProjectAsync()
    {
        Project project = new Project();

        Console.Write("Project Id = ");
        project.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Project Name = ");
        project.Name = Console.ReadLine();
        
        Console.Write("Description = ");
        project.Description = Console.ReadLine();

        Console.Write("Created User Id of Project = ");
        project.CreatedByUserId = Convert.ToInt32(Console.ReadLine());
        
        project.CreatedDate = DateTimeOffset.Now;
        project.UpdatedDate = DateTimeOffset.Now;

        var isAdded = await projectService.AddProjectAsync(project);

        if (isAdded)
            Console.WriteLine("Project added.");
    }

    public async Task ShowAllProjectAsync()
    {
        var products = await projectService.RetriveAllProjectAsync();

        TablePrinter.Print(products);
    }

    public async Task ShowProjectByIdAsync()
    {
        Console.Write("Project ning Id sini kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = await projectService.RetriveProjectById(id);

        TablePrinter.Print(product);
    }

    public async Task UpdateProjectMenuAsync()
    {
        Project project = new Project();

        Console.Write("Project Id = ");
        project.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Project Name = ");
        project.Name = Console.ReadLine();
        
        Console.Write("Description = ");
        project.Description = Console.ReadLine();

        Console.Write("Created User Id of Project = ");
        project.CreatedByUserId = Convert.ToInt32(Console.ReadLine());
        
        project.UpdatedDate = DateTimeOffset.Now;

        var isUpdated = await projectService.UpdateProjectAsync(project);

        if (isUpdated)
            Console.WriteLine("Project updated.");
    }

    public async Task DeleteProjectMenuAsync()
    {
        Console.Write("Project ning Id sini kiriting: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var isDeleted = await projectService.DeleteProjectAsync(id);

        if (isDeleted)
            Console.WriteLine("Project deleted.");
    }
}