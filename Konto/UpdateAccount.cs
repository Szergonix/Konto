using System;
using System.Data.SqlClient;

class UpdateAccount : AccountOperation
{
	private int numerKonta;
	private string wlasciciel;
	private decimal stan;
	private decimal oprocentowanie;
	private decimal debet;

	public UpdateAccount(SqlConnection connection, int numerKonta, string wlasciciel, decimal stan, decimal oprocentowanie, decimal debet)
		: base(connection)
	{
		this.numerKonta = numerKonta;
		this.wlasciciel = wlasciciel;
		this.stan = stan;
		this.oprocentowanie = oprocentowanie;
		this.debet = debet;
	}

	public override void Execute()
	{
		using (SqlCommand cmd = new SqlCommand("UPDATE Konto SET wlasciciel=@wlasciciel, stan=@stan, oprocentowanie=@oprocentowanie, debet=@debet WHERE numer_konta=@numerKonta;", conn))
		{
			cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
			cmd.Parameters.AddWithValue("@wlasciciel", wlasciciel);
			cmd.Parameters.AddWithValue("@stan", stan);
			cmd.Parameters.AddWithValue("@oprocentowanie", oprocentowanie);
			cmd.Parameters.AddWithValue("@debet", debet);
			cmd.ExecuteNonQuery();
		}
	}
}
