namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Schleife läuft solange die Bedingung true ist
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: beendet die Schleife (bei verschachtelten Schleifen springt break aus der inneren Schleife heraus)
				a++;
			} //Nach jedem Ende der Schleife wird die Bedingung nochmal überprüft

			int c = 0;
			int d = 10;
			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //Continue: springt in den Schleifenkopf zurück (Code darunter wird ausgelassen)
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			c = 0;

			while (true) //do-while mit while (true)
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine("while true: " + c);

				if (c >= d)
					break;
			}

			//for + Tab + Tab
			for (int i = 0; i < 10; i++) //Variable wird am Anfang angelegt, dann wird die Bedingung überprüft, dann wird der Code ausgeführt, am Ende wird die Variable erhöht
			{
				Console.WriteLine("for: " + i); //i ist nur innerhalb der Schleife sichtbar
			}

			//forr + Tab + Tab
			for (int i = 10; i >= 0; i--)
			{
				Console.WriteLine("forr: " + i);
			}

			//for Schleife ist sehr flexibel was Zählervariablen und Inkremente betrifft
			for (int i = 1, j = 0; i < 10; i *= 2, j %= 2)
			{

			}

			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8 };
			for (int i = 0; i < zahlen.Length; i++) //Array durchgehen und ausgeben
			{
				Console.WriteLine(zahlen[i]); //for Schleife kann daneben greifen, daher suboptimal um Arrays durchzugehen
			}

			//foreach + Tab + Tab
			foreach (int item in zahlen) //Array durchgehen aber kann nicht daneben greifen, da kein Index
			{
				Console.WriteLine(item);
			}

			foreach (int item in zahlen) //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
				Console.WriteLine(item);
			#endregion

			#region Enums
			string heutigerTag = "dienstag"; //User Eingabe
			if (heutigerTag == "Dienstag")
			{
				//Fehleranfälligkeit bei Strings
			}

			Wochentag wt = Wochentag.Di; //Variable vom Enum Typ
			if (wt == Wochentag.Di)
			{
				//Keine Fehleranfälligkeit
			}

			//Jeder Enum Wert hat einen int dahinter (Mo = 0, Di = 1, ...)
			int x = 2;
			Wochentag cast = (Wochentag) x;

			int y = (int) cast;

			string tag = "Mo";
			Wochentag einTag = Enum.Parse<Wochentag>(tag); //String zu Enum parsen (funktioniert mit Mo oder Zahl z.B. 0)

			Wochentag[] tage = Enum.GetValues<Wochentag>(); //Aus einem Enum alle Werte in ein Array entnehmen
			foreach (Wochentag t in tage) //Über alle Enumwerte iterieren
			{
				Console.WriteLine(t);
			}
			#endregion

			#region Switch
			Wochentag sw = Wochentag.Di;
			if (sw == Wochentag.Mo)
				Console.WriteLine("Wochenanfang");
			else if (sw == Wochentag.Di || sw == Wochentag.Mi || sw == Wochentag.Do || sw == Wochentag.Fr)
				Console.WriteLine("Wochenmitte");
			else if (sw == Wochentag.Sa || sw == Wochentag.So)
				Console.WriteLine("Wochenende");
			else
				Console.WriteLine("Fehler");

			switch (sw) //if-else Baum mit switch
			{
				case Wochentag.Mo: //Sozusagen eine if
					Console.WriteLine("Wochenanfang");
					break; //Am Ende von jedem Case ein break machen
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default: //Sozusagen eine else
					Console.WriteLine("Fehler");
					break; //default case kann weggelassen werden
			}

			switch (sw) //Switch mit boolescher Logik
			{
				//and/or statt &&/||
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}

			Wochentag2 wt2 = Wochentag2.Mo | Wochentag2.Di;
			if (wt2 == (Wochentag2.Sa | Wochentag2.So))
			{

			}
			Console.WriteLine(wt2);
			#endregion
		}
	}

	public enum Wochentag
	{
		Mo = 1, //Enumwerten eigene Werte zuweisen, Rest wird aufgeschoben
		Di,
		Mi,
		Do = 10, //hier neu anfangen zu zählen
		Fr,
		Sa,
		So
	}

	[Flags]
	public enum Wochentag2
	{
		Mo = 1,
		Di = 2,
		Mi = 4,
		Do = 8,
		Fr = 16,
		Sa = 32,
		So = 64
	}
}