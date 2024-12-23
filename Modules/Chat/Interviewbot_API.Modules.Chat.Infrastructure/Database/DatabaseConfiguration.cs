namespace Interviewbot_API.Modules.Chat.Infrastructure.Database;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    
    public DatabaseConfiguration(string connectionString, string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }
}