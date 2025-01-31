using System;
using System.Data.SqlClient;

class CreateAccount : AccountOperation
{
	private string wlasciciel;
	private decimal stan;
	private decimal oprocentowanie;
	private decimal debet;

	public CreateAccount(SqlConnection connection, string wlasciciel, decimal stan, decimal oprocentowanie, decimal debet)
		: base(connection)
	{
		this.wlasciciel = wlasciciel;
		this.stan = stan;
		this.oprocentowanie = oprocentowanie;
		this.debet = debet;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("INSERT INTO Konto (wlasciciel, stan, oprocentowanie, debet) OUTPUT INSERTED.numer_konta VALUES (@wlasciciel, @stan, @oprocentowanie, @debet);", conn))
		{
			cmd.Parameters.AddWithValue("@wlasciciel", wlasciciel);
			cmd.Parameters.AddWithValue("@stan", stan);
			cmd.Parameters.AddWithValue("@oprocentowanie", oprocentowanie);
			cmd.Parameters.AddWithValue("@debet", debet);
			int numerKonta = (int)cmd.ExecuteScalar();
			Console.WriteLine($"Konto utworzone z numerem: {numerKonta}");
		}
	}
}
