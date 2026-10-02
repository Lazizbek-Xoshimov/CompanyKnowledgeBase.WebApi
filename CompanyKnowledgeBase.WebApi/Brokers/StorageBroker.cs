namespace CompanyKnowledgeBase.WebApi.Brokers;

public partial class StorageBroker : IStorageBroker
{
    private readonly string _context;

    public StorageBroker()
    {
        _context = "Server=(localdb)\\MSSQLLocalDB;Database=CompanyKnowledgeBaseDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
    }
}
