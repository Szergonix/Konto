using System;
using System.Data.SqlClient;

class Deposit : AccountOperation
{
	private int numerKonta;
	private decimal kwota;

	public Deposit(SqlConnection connection, int numerKonta, decimal kwota)
		: base(connection)
	{
		this.numerKonta = numerKonta;
		this.kwota = kwota;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("UPDATE Konto SET stan = stan + @kwota WHERE numer_konta=@numerKonta;", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			cmd.Parameters.AddWithValue("@kwota", kwota);
			cmd.ExecuteNonQuery();
		}
	}
}
