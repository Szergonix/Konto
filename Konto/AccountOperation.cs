using System;
using System.Data.SqlClient;

abstract class AccountOperation
{
	protected SqlConnection conn;

	public AccountOperation(SqlConnection connection)
	{
		conn = connection;
	}

	public abstract void Execute();
}
