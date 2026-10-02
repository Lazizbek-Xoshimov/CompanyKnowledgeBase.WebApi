using System.Data;
using Microsoft.Data.SqlClient;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    private readonly string _connectionString;

    public StorageBroker()
    {
        _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CompanyKnowledgeBaseDB;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}