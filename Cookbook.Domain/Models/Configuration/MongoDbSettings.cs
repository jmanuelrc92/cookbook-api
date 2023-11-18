namespace Cookbook.Domain.Models.Configuration;

public class MongoDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
    public MongoDbSettings()
    {
        DatabaseName = string.Empty;
        ConnectionString = string.Empty;
    }
    public MongoDbSettings(string databaseName, string connectionString)
    {
        DatabaseName = databaseName;
        ConnectionString = connectionString;
    }
}