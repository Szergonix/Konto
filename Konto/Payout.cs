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
		decimal currentBalance = 0;
		decimal debet = 0;

		// Sprawdzenie aktualnego stanu konta i debetu
		using (SqlCommand checkCmd = new SqlCommand("SELECT stan, debet FROM Konto WHERE numer_konta=@numerKonta", conn))
		{
			checkCmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			using (SqlDataReader reader = checkCmd.ExecuteReader())
			{
				if (reader.Read())
				{
					currentBalance = reader.GetDecimal(0);
					debet = reader.GetDecimal(1);
				}
			}
		}

		// Sprawdzenie, czy œrodki s¹ wystarczaj¹ce
		if (currentBalance - kwota < debet)
		{
			throw new InsufficientFundsException("Niewystarczaj¹ca iloœæ œrodków na koncie!");
		}

		// Aktualizacja stanu konta
		using (SqlCommand cmd = new SqlCommand("UPDATE Konto SET stan = stan - @kwota WHERE numer_konta=@numerKonta", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			cmd.Parameters.AddWithValue("@kwota", kwota);
			cmd.ExecuteNonQuery();
		}
	}
}

public class InsufficientFundsException : Exception
{
	public InsufficientFundsException(string message) : base(message) { }
}
