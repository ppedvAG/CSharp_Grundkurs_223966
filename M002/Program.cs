namespace M002
{
	/// <summary>
	/// Die Program Klasse
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Die Main Methode
		/// </summary>
		/// <param name="args">Die Programmargumente</param>
		static void Main(string[] args)
		{
			#region Variablen
			//Variable: Feld das einen Wert halten kann
			int zahl; //Deklaration
			zahl = 5; //Zuweisung
			//int: Ganze Zahl
			Console.WriteLine(zahl); //Eine Ausgabe auf die Konsole machen

			int zahlMitZuweisung = 5; //Deklaration und Zuweisung gemeinsam
			Console.WriteLine(zahlMitZuweisung); //cw + Tab + Tab

			int zahlMalZwei = zahl * 2; //obere Zahl mal 2 = 10
			Console.WriteLine(zahlMalZwei);

			/*
				Mehrzeiliger
				Kommentar
			 */

			string wort = "Hallo"; //String: Text mit maximal 4 Milliarden Zeichen, braucht doppelte Hochkomma
			Console.WriteLine(wort);

			char zeichen = 'A'; //Char: kann genau ein Zeichen halten, braucht einzelne Hochkomma
			Console.WriteLine(zeichen);

			double kostenDouble = 38.29; //double: Kommazahl

			float kostenFloat = 1.1f; //Kommazahlen sind standardmäßig double, mit f am Ende zu float konvertieren

			decimal kostenDecimal = 45.22m; //Geeignet für Geldwerte da sehr hohe Kommastellenpräzision, mit m zu decimal konvertieren

			bool b = true; //bool: Wahr-/Falschwert
			b = false; //true oder false
			#endregion

			#region Strings
			string kombi = "Das Wort ist: " + wort; //Strings verknüpfen mit +
			Console.WriteLine(kombi);

			string kombiInt = "Das Zahl ist: " + zahl; //Stringverknüpfung auch möglich mit ints (oder anderen Typen)
			Console.WriteLine(kombiInt);

			string abstand = "Die Werte sind: " + wort + ", " + zahl + ", " + b; //Anstrengend
			Console.WriteLine(abstand);

			string interpolation = $"Die Werte sind: {wort}, {zahl}, {b}"; //Einfacher als obiges mit Interpolation
			Console.WriteLine(interpolation);

			Console.WriteLine($"Die Werte sind: {wort}, {zahl}, {b}"); //Direkte Ausgabe statt extra Variable

			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			Console.WriteLine("Umbruch \n Umbruch"); //\n für Zeilenumbruch

			Console.WriteLine("Tab \t Tab"); //\t für Tabulator

			Console.WriteLine("C:\\Users"); //Doppelter Backslash um einzelnen Backslash zu machen

			//Verbatim-String: Nimmt den String 1:1 wie er geschrieben wird, beachtet keine Escape-Sequenzen
			string verbatim = @"\n\t\\";
			Console.WriteLine(verbatim);

			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_01_10\M002"; //Besonders nützlich für Pfade

			string umbruch = @"Umbruch
			Umbruch"; //Umbrüche und Tabs müssen tatsächliche Umbrüche und Tabs sein
			Console.WriteLine(umbruch);
			#endregion

			#region Eingabe
			//string eingabe = Console.ReadLine(); //Mit Console.ReadLine() eine Eingabe vom Benutzer verlangen, Programm bleibt stehen bis Enter gedrückt wird
			//Console.WriteLine($"Deine Eingabe ist: {eingabe}"); //Das Ergebnis von ReadLine wird in eine Variable geschrieben

			//char eingabeChar = Console.ReadKey(true).KeyChar; //ReadKey: Warte auf einen Input vom User ohne Enter
			//Console.WriteLine($"Das Eingegebene Zeichen ist: {eingabeChar}"); //Mit true in der Klammer kann verhindert werden das das Zeichen angezeigt wird

			////int eingabeInt = Console.ReadLine(); //Nicht direkt möglich, Konvertierung erforderlich
			//int eingabeInt = int.Parse(Console.ReadLine()); //Parse: wandle einen String zu einem anderen Typen um
			//Console.WriteLine($"Deine Eingabe mal Zwei ist: {eingabeInt * 2}"); //int.Parse um Eingabe zu einem String zu konvertieren

			////die Parse Funktion gibt es auch für andere Typen z.B.: double, long, float, char, bool, ...)
			//int x = Convert.ToInt32(Console.ReadLine()); //Convert statt int.Parse (alt)
			#endregion

			//Strg + K + C: Gewählten Bereich auskommentieren
			//Strg + K + U: Gewählten Bereich einkommentieren

			#region Konvertierungen
			//Explizite Konvertierung (Cast, Typecast, Casting)
			double d = 2385.9528;
			int i = (int) d; //Nicht kompatibel, Konvertierung muss erzwungen werden durch einen Cast
			Console.WriteLine(i); //Kommastellen werden abgeschnitten
			double zurück = i;
			Console.WriteLine(zurück); //Kommastellen bleiben weg
			float f = (float) d; //Konvertierung muss auch hier erzwungen werden

			int z = 37;
			double implizit = z; //Konvertierung passiert hier automatisch, da die 2 Typen in diese Richtung kompatibel sind

			string s = d.ToString(); //Beliebigen Wert in einen String konvertieren
			#endregion

			#region Arithmetik
			int z1 = 5;
			int z2 = 8;
			Console.WriteLine(z1 + z2); //Originale Werte bleiben unverändert, nur das Ergebnis wird berechnet und ausgegeben

			z1 = z1 + z2; //z1 um z2 erhöhen (Langform)
			z1 += z2; //z1 um z2 erhöhen

			Console.WriteLine(z1 % z2); //Gibt den Rest einer Division zurück
			Console.WriteLine(z1 % 2); //Prüfen, ob eine Zahl gerade ist

			z1++; //Erhöht die Zahl um 1 (z1 += 1)
			z2--; //Verringert die Zahl um 1 (z2 -= 1)

			double z3 = 343.218471932;
			//Rundungsfunktion verändern nicht den originalen Wert
			Math.Ceiling(z3); //Aufrunden auf die nächste ganze Zahl
			Math.Floor(z3); //Abrunden auf die nächste ganze Zahl
			Math.Round(z3); //Rundet auf die nächste Zahl, bei .5 wird auf die nächste gerade Zahl gerundet
			Math.Round(4.5); //4
			Math.Round(5.5); //6

			double zweiKomma = Math.Round(z3, 2); //Auf X Kommastellen runden
			Console.WriteLine(zweiKomma);

			Console.WriteLine(8 / 5); //Int-Division, da zwei Ints als Argumente (Ergebnis 1 statt 1.6)
			Console.WriteLine(8.0 / 5); //Kommadivision erzwingen, wenn eine der beiden Zahlen eine Kommazahl ist
			Console.WriteLine(8d / 5);
			Console.WriteLine(8f / 5); 
			Console.WriteLine((double) z1 / z2); //Eine der beiden Variablen zu double konvertieren per Cast
			#endregion
		}
	}
}