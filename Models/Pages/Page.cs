namespace Models.Pages;

public class Page
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ProjectId { get; set; }
    public Guid FolderId { get; set; }
    public int CurrentVersionId { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
