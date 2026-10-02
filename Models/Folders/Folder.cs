namespace Models.Folders;

public class Folder
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ProjectId { get; set; }
    public Guid? ParentFolderId { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
