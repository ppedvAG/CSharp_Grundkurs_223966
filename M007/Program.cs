using M007.Bauteile;

namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Fenster f = new Fenster();
		}

		GC.Collect(); //Hier GC erzwingen
		GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren
		#endregion

		#region Static
		//Statische Member müssen ohne Objekt arbeiten
		//Console c = new Console();
		//c.WriteLine(); nicht möglich, da statisch
		//Console.WriteLine();

		Fenster fenster = new Fenster();
		//Fenster.FensterOeffnen(); nicht möglich, da kein Objekt existiert
		fenster.FensterOeffnen();

		//fenster.Zaehler++; nicht möglich
		Fenster.Zaehler++;
		Fenster.InkrementZaehler();
		#endregion

		#region Werte-/Referenztypen
		//class
		//Referenztyp
		//==, != werden Speicheradressen verglichen
		//Zuweisungen haben Referenzen anstatt Kopien

		//struct
		//Wertetyp
		//==, != werden die Inhalte verglichen
		//Zuweisungen werden kopiert statt referenziert

		//Wertetyp
		int original = 5;
		int x = original;
		original = 10;

		//Referenztyp
		Fenster f1 = new();
		Fenster f2 = f1; //Referenz zu f1
		f1.FensterOeffnen(); //f1 und f2 zeigen auf das gleiche Objekt im RAM
		#endregion

		#region Null
		Fenster f3; //Standardmäßig null (es hängt kein Wert daran)
		f3 = null; //Referenz zum Objekt trennen
		//f3.FensterOeffnen(); Nicht vorhandenes Objekt kann nicht geöffnet werden

		if (f3 != null) //Schauen ob das Objekt existiert
		{
			f3.FensterOeffnen();
		}

		f3?.FensterOeffnen(); //Schneller Null-Check: wenn das Objekt null ist, führe den Code danach nicht aus

		if (f3 == null)
		{
			f3 = new();
		}

		f3 ??= new(); //Wenn das Objekt null ist, führe den Code aus, sonst mach nichts

		if (f3 is null || f3 is not null) //Selbiges wie == und !=
		{

		}
		#endregion
	}
}

public class WrappedInt
{
	int RefInt; //"struct referenzierbar machen"
}