namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(5, 9); //Funktionsaufruf über den Namen der Funktion, Parameter müssen mit angegeben werden
			PrintAddiere(3, 8);
			PrintAddiere(12, 3);

			int summe = Addiere(59, 19); //Ergebnis der Addiere Funktion in die summe Variable schreiben
			Console.WriteLine(summe);

			int summe3 = Addiere(6, 3, 4);

			Addiere(12, 4); //int Overload
			Addiere(12.0, 3); //double Overload erzwingen

			Summiere(); //Auch keine Parameter sind beliebig viele Parameter
			Summiere(1, 2, 3); //3 Parameter
			Summiere(1, 2, 3, 4, 5, 2.5, 1.4, 9.8, 291); //9 Parameter

			Subtrahiere(1, 3); //z = 0
			Subtrahiere(1, 4, 2); //z = 2

			SubtrahiereOderAddiere(5, 1);
			SubtrahiereOderAddiere(7, 3, true);

			int add;
			int sub = SubtrahiereUndAddiere(4, 3, out add);

			//int result;
			if (int.TryParse("123", out int result)) //Ergebnis des Parsens steht in result wenn es funktioniert hat
			{
				//Parsen hat funktioniert
			}
			else
			{
				//Parsen hat nicht funktioniert
			}
			Console.WriteLine(result);

			PrintWochentag(DayOfWeek.Tuesday);
		}

		static void PrintAddiere(int x, int y) //Funktion mit void (ohne Rückgabewert), Zwei Parameter: x, y
		{
			Console.WriteLine($"{x} + {y} = {x + y}");
		}

		static int Addiere(int x, int y) //Funktion mit Rückgabewert
		{
			return x + y; //Ergebnis der Funktion zurückgeben mit return
		}

		static int Addiere(int x, int y, int z) //Funktion überladen, Funktion mit gleichem Namen definieren wie bereits vorhandene Funktion, nur mit anderen Parametern
		{
			return x + y + z;
		}

		static double Addiere(double x, double y)
		{
			return x + y;
		}

		static double Summiere(params double[] zahlen) //Mit Params können beliebig viele Parameter angegeben werden (muss ein Array sein)
		{
			return zahlen.Sum();
		}

		static double Subtrahiere(int x, int y, int z = 0) //Optionaler Parameter: Kann bei Funktionsaufruf übergeben werden, muss aber nicht
		{
			return x - y - z;
		}

		static double SubtrahiereOderAddiere(int x, int y, bool add = false) //Optionale Parameter müssen am Ende stehen
		{
			//if (add)
			//	return x + y;
			//else
			//	return x - y;
			return add ? x + y : x - y;
		}

		static int SubtrahiereUndAddiere(int x, int y, out int add) //Out-Parameter: Mehrere Werte zurückgeben
		{
			add = x + y; //Muss zugewiesen werden vor return
			return x - y;
		}

		static string PrintWochentag(DayOfWeek wt)
		{
			switch (wt)
			{
				case DayOfWeek.Monday: return "Montag"; //Bei einem Switch mit return muss kein break verwendet werden
				case DayOfWeek.Tuesday: return "Dienstag";
				case DayOfWeek.Wednesday: return "Mittwoch";
				case DayOfWeek.Thursday: return "Donnerstag";
				case DayOfWeek.Friday: return "Freitag";
				case DayOfWeek.Saturday: return "Samstag";
				case DayOfWeek.Sunday: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}

		static void PrintZahl(int zahl)
		{
			Console.WriteLine(zahl);
			return; //Aus Funktion herausspringen / Funktion beendet
			Console.WriteLine(zahl); //Kann nicht erreicht werden
		}
	}
}