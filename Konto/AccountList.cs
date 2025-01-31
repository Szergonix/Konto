using System;
using System.Data.SqlClient;

class AccountList
{
	public static void ListAccounts(SqlConnection conn)
	{
		using (SqlCommand cmd = new SqlCommand("SELECT numer_konta, wlasciciel FROM Konto;", conn))
		{
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				Console.WriteLine("Dostêpne konta:");
				while (reader.Read())
				{
					Console.WriteLine($"{reader[0]} - {reader[1]}");
				}
			}
		}
	}
}
