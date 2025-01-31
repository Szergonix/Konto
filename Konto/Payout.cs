using System;
using System.Data.SqlClient;

class Payout : AccountOperation
{
	private int numerKonta;
	private decimal kwota;

	public Payout(SqlConnection connection, int numerKonta, decimal kwota)
		: base(connection)
	{
		this.numerKonta = numerKonta;
		this.kwota = kwota;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("UPDATE Konto SET stan = stan - @kwota WHERE numer_konta=@numerKonta AND stan - @kwota >= debet;", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			cmd.Parameters.AddWithValue("@kwota", kwota);
			int rowsAffected = cmd.ExecuteNonQuery();
			if (rowsAffected == 0)
				throw new Exception("Niewystarczaj¹ca iloœæ œrodków na koncie!");
		}
	}
}
