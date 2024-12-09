namespace Dappercontext;
using Npgsql;


public class DapperContext
{
    private readonly string connectionString = "Server = localhost; Port = 5432; Database = companydb; User Id=postgres;Password=12345;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}