namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("", 1); //Variablentyp Mensch, kann alle Objekte halten die von Typ Mensch sind oder Unterklassen von Mensch sind

		Lebewesen l = new Mensch("", 1); //Variablentyp Lebewesen, kann alle Objekte halten die Lebewesen oder darunter sind

		object o = new Mensch("", 1); //Variablentyp object, kann alle Objekte halten
		o = 123; //int
		o = false; //bool
		o = "Hallo"; //string

		l = m; //kompatibel weil Lebewesen > Mensch
		//m = l; nicht kompatibel weil Lebewesen nicht > Mensch	

		//GetType(): gibt den Typen des derzeitigen Objekts zurück
		Console.WriteLine(m.GetType().Name); //Mensch
		Console.WriteLine(l.GetType()); //M009.Mensch
		Console.WriteLine(o.GetType()); //System.String

		Type tm = m.GetType(); //GetType() gibt ein Type Objekt
		Type typeofM = typeof(Mensch); //Über typeof(<Klassenname>) einen Typen über eine Klasse extrahieren

		#region Exakter Typvergleich
		if (m.GetType() == typeof(Mensch)) //ist m genau ein Mensch?
		{
			//true
		}

		if (m.GetType() == typeof(Lebewesen))
		{
			//false
		}
		#endregion

		#region Vererbungshiearchie Typvergleich
		if (m is Mensch) //ist m ein Mensch oder eine Unterklasse von Mensch?
		{
			//true
		}

		if (m is Lebewesen)
		{
			//true
		}

		if (m is object)
		{
			//immer true
		}

		if (m is Program)
		{
			//false
		}
		#endregion

		#region Virtual Override
		Mensch mensch = new Mensch("", 123);
		mensch.WasBinIch2(); //Ich bin ein Mensch und bin 123 Jahre alt

		Lebewesen l3 = mensch;
		l3.WasBinIch2(); //Ich bin ein Mensch und bin 123 Jahre alt
						 //Verbindung zwischen Lebewesen und Mensch hergestellt, deshalb wird die Mensch Methode verwendet
		#endregion

		#region New
		Mensch mensch2 = new Mensch("", 123);
		mensch2.WasBinIch(); //Ich bin ein Mensch

		Lebewesen l4 = mensch2;
		l4.WasBinIch(); //Ich bin ein Lebewesen
		//Hier wird die Methode von Lebewesen verwendet, da die Verbindung getrennt wurde
		#endregion


	}
}

public abstract class Lebewesen //abstract: Strukturklasse für die Unterklassen, kann nicht instanziert werden
{
	public string Name { get; set; } //Wird nach unten vererbt

	public Lebewesen(string name)
	{
		Name = name;
	}

	public void WasBinIch() //Wird auch nach unten vererbt
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public virtual void WasBinIch2() //virtual: kann überschrieben werden, muss aber nicht überschrieben werden
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public abstract void Bewegen(); //Abstrakte Methoden haben keinen Body
}

public class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
{ //sealed: Vererbung verhindern
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Konstruktoren zwischen vererbten Klassen müssen verketten sein (mit base)
	{
		//Extra Feld hinzufügen im Konstruktor (hier alter)
		Alter = alter;
	}

	public new void WasBinIch()
	{
		Console.WriteLine("Ich bin ein Mensch");
	}

	public override void WasBinIch2() //override: Überschreibe die Methode von oben, obere Methode muss virtual sein
	{
		//base.WasBinIch2(); Mit base.<Methode> auf die Basisimplementation zugreifen
		Console.WriteLine($"Ich bin ein Mensch und bin {Alter} Jahre alt");
	}

	public override void Bewegen()
	{
		Console.WriteLine("Der Mensch bewegt sich");
	}
}

public class Katze : Lebewesen
{
	public Katze(string name) : base(name)
	{
	}

	public override void Bewegen()
	{
		Console.WriteLine("Die Katze bewegt sich");
	}
}