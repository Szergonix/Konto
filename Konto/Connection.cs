using System;
using System.Data.SqlClient;

class Connection : IDisposable
{
	private SqlConnection conn;

	public Connection(string server, string database)
	{
		string connectionString = $"Server={server};Database={database};Integrated Security=True;";
		conn = new SqlConnection(connectionString);
		conn.Open();
	}

	public void Close()
	{
		conn.Close();
	}

	public void Dispose()
	{
		Close();
		conn.Dispose();
	}

	public void ExecuteOperation(AccountOperation operation)
	{
		operation.Execute();
	}

	public SqlConnection GetSqlConnection()
	{
		return conn;
	}
}
