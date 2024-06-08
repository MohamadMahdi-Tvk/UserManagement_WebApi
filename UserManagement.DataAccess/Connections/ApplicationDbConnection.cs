using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;
using System.Data;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.Context;

namespace UserManagement.DataAccess.Connections;

public class ApplicationReadDbConnection : IApplicationReadDbConnection, IDisposable
{
    private readonly IDbConnection connection;
    public ApplicationReadDbConnection(IConfiguration configuration)
    {
        connection = new SqlConnection(configuration.GetConnectionString("DefaultDb"));
    }
    public async Task<List<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return (await connection.QueryAsync<T>(sql, param, transaction, commandType: commandType)).AsList();
    }

    public async Task<T> QueryScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return await connection.ExecuteScalarAsync<T>(sql, param, transaction, commandType: commandType);
    }
    public void Dispose()
    {
        connection.Dispose();
    }

    public async Task<GridReader> QueryMultipleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return await connection.QueryMultipleAsync(sql, param, transaction, commandType: commandType);
    }
}


public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
{
    private readonly DatabaseContext context;
    public ApplicationWriteDbConnection(DatabaseContext context)
    {
        this.context = context;
    }
    public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await context.Connection.ExecuteAsync(sql, param, transaction);
    }
}