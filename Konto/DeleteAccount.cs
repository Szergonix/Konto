using System;
using System.Data.SqlClient;

class DeleteAccount : AccountOperation
{
	private int numerKonta;

	public DeleteAccount(SqlConnection connection, int numerKonta)
		: base(connection)
	{
		this.numerKonta = numerKonta;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("DELETE FROM Konto WHERE numer_konta=@numerKonta;", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			cmd.ExecuteNonQuery();
		}
	}
}
