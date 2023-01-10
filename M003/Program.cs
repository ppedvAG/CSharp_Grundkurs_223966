namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Variable die mehrere Werte halten kann
			int[] zahlen; //Arrayvariable mit [] nach Typ (<Typ>[])
			zahlen = new int[10]; //Array mit Länge 10 (0-9)
			zahlen[3] = 20; //Stelle angreifen mit [<Index>]
			Console.WriteLine(zahlen[3]);

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, Länge automatisch (5)
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise (wie oben, nur kürzer)
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Kürzeste Schreibweise

			Console.WriteLine(zahlen.Length); //Größe des Arrays (10)

			Console.WriteLine(zahlen.Contains(3)); //false
			Console.WriteLine(zahlen.Contains(20)); //true

			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), Deklaration mit Beistrich in der Klammer
			zweiDArray[1, 1] = 4; //Mittlere Stelle
			Console.WriteLine(zweiDArray[1, 1]);

			zweiDArray = new[,] //Direkte Initialisierung
			{
				{ 1, 2, 3 },
				{ 1, 4, 5 },
				{ 7, 8, 9 }
			};

			Console.WriteLine(zweiDArray.Length); //3x3 Plätze = 9
			Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen: 2
			Console.WriteLine(zweiDArray.GetLength(0)); //Länge der nullten Dimension: 3
			Console.WriteLine(zweiDArray.GetLength(1)); //Länge der ersten Dimension: 3
			#endregion

			#region Bedingungen
			int z1 = 5;
			int z2 = 1;

			if (z1 == z2)
			{

			}

			bool b1 = true;
			bool b2 = false;
			if (b1 ^ b2)
			{
				//Wenn b1 und b2 unterschiedlich sind
			}

			b1 = !b1; //boolean invertieren auf klassischem Wege
			b1 ^= true; //boolean invertieren über xor
			//App.MainWindow.Button.Boolean = !App.MainWindow.Button.Boolean;
			//App.MainWindow.Button.Boolean ^= true;

			if (zahlen.Contains(3))
			{
				//...
			}

			if (z1 != z2)
			{
				Console.WriteLine("Die Zahlen sind ungleich");
			}
			else
			{
				Console.WriteLine("Die Zahlen sind gleich");
			}

			//Fragezeichen Operator (?, :) ? ist if, : ist else
			//Braucht immer ein else
			Console.WriteLine(z1 != z2 ? "Die Zahlen sind ungleich" : "Die Zahlen sind gleich");
			#endregion
		}
	}
}