using Models.Users;

namespace Models.Projects;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}