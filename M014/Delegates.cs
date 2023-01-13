namespace M014;

internal class Delegates
{
	public delegate void Vorstellungen(string name); //Definition von Delegate, speichert Referenzen auf Methoden, können zur Laufzeit hinzugefügt oder weggenommen werden

	static void Main(string[] args)
	{
		Vorstellungen v = new Vorstellungen(VorstellungDE); //Variablendeklaration + Erstellung mit einer Initialmethode
		v("Lukas");

		v += new Vorstellungen(VorstellungEN); //Methode anhängen (lang)
		v += VorstellungEN; //Kurzform
		v("Lukas");

		v += VorstellungDE;
		v += VorstellungDE;
		v += VorstellungDE; //Methoden können mehrmals angehängt werden
		v("Max");

		v -= VorstellungEN; //Methode abnehmen
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN; //Methode die nicht angehängt ist, kann nicht abgenommen werden -> nichts passiert
		v("Max");

		v -= VorstellungDE;
		v -= VorstellungDE;
		v -= VorstellungDE;
		v -= VorstellungDE; //Delegate ist null wenn die letzte Methode abgenommen wird
		v("Max");

		if (v is not null) //Null-Check
			v("Max");

		v?.Invoke("Max"); //Wenn v nicht null ist, dann Invoke, sonst nichts

		v = null; //Delegate entleeren

		foreach (Delegate dg in v.GetInvocationList()) //Delegate anschauen
		{
			Console.WriteLine(dg.Method.Name); //Auf Methode zugreifen über dg
		}
	}

	public static void VorstellungDE(string name) => Console.WriteLine($"Hallo mein Name ist {name}");

	public static void VorstellungEN(string name) => Console.WriteLine($"Hello my name is {name}");
}