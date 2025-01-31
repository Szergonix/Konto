using System;
using System.Data.SqlClient;

class ApplyInterest : AccountOperation
{
	private int numerKonta;

	public ApplyInterest(SqlConnection connection, int numerKonta)
		: base(connection)
	{
		this.numerKonta = numerKonta;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("UPDATE Konto SET stan = stan + (stan * oprocentowanie / 100) WHERE numer_konta=@numerKonta;", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			cmd.ExecuteNonQuery();
		}
	}
}
