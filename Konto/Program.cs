using System;

class Program
{
	static void Main()
	{
		string server = "PC";
		string database = "Konto_bankowe";

		using (Connection conn = new Connection(server, database))
		{
			while (true)
			{
				Console.WriteLine("Wybierz opcj�:\n1. Dodaj konto\n2. Wp�a� kwot�\n3. Wyp�a� kwot�\n4. Nalicz odsetki\n5. Usu� konto\n6. Wy�wietl informacje o koncie\n7. Wyj�cie");
				string choice = Console.ReadLine();

				if (choice == "7") break;
				int numerKonta = 0;
				if (choice != "1") // List accounts before selecting
				{
					AccountList.ListAccounts(conn.GetSqlConnection());
					Console.WriteLine("Podaj numer konta (0 aby wr�ci�): ");
					numerKonta = int.Parse(Console.ReadLine());
					if (numerKonta == 0) continue;
				}

				switch (choice)
				{
					case "1":
						Console.Write("Podaj w�a�ciciela: ");
						string wlasciciel = Console.ReadLine();
						Console.Write("Podaj stan: ");
						decimal stan = decimal.Parse(Console.ReadLine());
						Console.Write("Podaj oprocentowanie: ");
						decimal oprocentowanie = decimal.Parse(Console.ReadLine());
						Console.Write("Podaj debet: ");
						decimal debet = decimal.Parse(Console.ReadLine());
						conn.ExecuteOperation(new CreateAccount(conn.GetSqlConnection(), wlasciciel, stan, oprocentowanie, debet));
						break;
					case "2":
						Console.Write("Podaj kwot� do wp�aty: ");
						conn.ExecuteOperation(new Deposit(conn.GetSqlConnection(), numerKonta, decimal.Parse(Console.ReadLine())));
						break;
					case "3":
						Console.Write("Podaj kwot� do wyp�aty: ");
						conn.ExecuteOperation(new Payout(conn.GetSqlConnection(), numerKonta, decimal.Parse(Console.ReadLine())));
						break;
					case "4":
						conn.ExecuteOperation(new ApplyInterest(conn.GetSqlConnection(), numerKonta));
						break;
					case "5":
						conn.ExecuteOperation(new DeleteAccount(conn.GetSqlConnection(), numerKonta));
						break;
					case "6":
						conn.ExecuteOperation(new AccountInfoOperation(conn.GetSqlConnection(), numerKonta));
						break;
				}
			}
		}
	}
}
