using System.Data;
using Interviewbot_API.BuildingBlocks.Application.Data;
using Microsoft.Data.SqlClient;

namespace Interviewbot_API.BuildingBlocks.Infrastructure;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection GetOpenConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        return _connection;
    }

    public IDbConnection CreateNewConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }

    public void Dispose()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Dispose();
        }
    }
}