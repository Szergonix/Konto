using System;
using System.Data.SqlClient;

class AccountInfo : AccountOperation
{
	private int numerKonta;

	public AccountInfo(SqlConnection connection, int numerKonta)
		: base(connection)
	{
		this.numerKonta = numerKonta;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("SELECT wlasciciel, stan, oprocentowanie, debet FROM Konto WHERE numer_konta=@numerKonta;", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				if (reader.Read())
				{
					Console.WriteLine($"Właściciel: {reader[0]}\nStan: {reader[1]}\nOprocentowanie: {reader[2]}\nDebet: {reader[3]}");
				}
				else
				{
					Console.WriteLine("Nie znaleziono takiego konta!");
				}
			}
		}
	}
}
