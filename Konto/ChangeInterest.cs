using System;
using System.Data.SqlClient;

class ChangeInterest : AccountOperation
{
	private int numerKonta;
	private decimal noweOprocentowanie;

	public ChangeInterest(SqlConnection connection, int numerKonta, decimal noweOprocentowanie)
		: base(connection)
	{
		this.numerKonta = numerKonta;
		this.noweOprocentowanie = noweOprocentowanie;
	}

	public override void Execute()
	{
		try
		{
			using (SqlCommand cmd = new SqlCommand("UPDATE Konto SET oprocentowanie = @noweOprocentowanie WHERE numer_konta=@numerKonta;", conn))
			{
				cmd.Parameters.AddWithValue("@numerKonta", numerKonta);
				cmd.Parameters.AddWithValue("@noweOprocentowanie", noweOprocentowanie);
				cmd.ExecuteNonQuery();
			}
			Console.WriteLine("Oprocentowanie zosta�o zmienione.");
		}
		catch (Exception ex)
		{
			Console.WriteLine("Wyst�pi� b��d podczas zmiany oprocentowania: " + ex.Message);
		}
	}
}
