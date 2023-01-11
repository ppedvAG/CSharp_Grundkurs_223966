namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Test", 23);
		m.Name = "Test"; //Property wurde vererbt
		m.WasBinIch(); //Methode wurden vererbt

		Console.WriteLine(m.Alter);

		Lebewesen l = new Lebewesen("Test");
		//Console.WriteLine(l.Alter); Vererbung geht nur nach unten und nicht nach oben

		m.WasBinIch2();

		Console.WriteLine(m.ToString()); //ToString: gibt den Typen des Objekts aus (Standard), kann überschrieben werden

		Raum r = new Raum();
		Fenster f1 = new();
		Fenster f2 = new();
		Tuere t = new();
		r.Teile[0] = t;
		r.Teile[1] = f1;
		r.Teile[2] = f2;
	}
}

public class Lebewesen //Basisklasse
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

	public override string ToString() //Überschreibung wird auch nach unten weitergegeben
	{
		return "Lebewesen";
	}
}

public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
{ //sealed: Vererbung verhindern
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Konstruktoren zwischen vererbten Klassen müssen verketten sein (mit base)
	{
		//Extra Feld hinzufügen im Konstruktor (hier alter)
		Alter = alter;
	}

	public override void WasBinIch2() //override: Überschreibe die Methode von oben, obere Methode muss virtual sein
	{
		//base.WasBinIch2(); Mit base.<Methode> auf die Basisimplementation zugreifen
		Console.WriteLine($"Ich bin ein Mensch und bin {Alter} Jahre alt");
	}

	public sealed override string ToString() //Hier kann die Methode nochmal überschrieben werden
	{
		return "Mensch";
	}
}

public class Katze : Lebewesen
{
	public Katze(string name) : base(name)
	{
	}
}

//public class Kind : Mensch //Nicht möglich da sealed
//{
//	public Kind(string name, int alter) : base(name, alter) { }

//	public override string ToString() //Nicht möglich da sealed
//	{
//		return base.ToString();
//	}
//}