using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Mensch m = new Mensch() { Gehalt = 3000, Job = "Softwareentwickler" }; //Direkte Initialisierung von bestimmten Feldern
		//m.Lohnauszahlung(); //Lohnauszahlungsmethode durch Interface

		IArbeit a = m; //Variable vom Typ IArbeit genau wie bei Vererbung
		a.Lohnauszahlung();

		ITeilzeitArbeit ta = m;
		ta.Lohnauszahlung();

		//IEnumerable: Basisinterface von allen Listen in C#
		IEnumerable<int> e1 = new int[1];
		IEnumerable<int> e2 = new List<int>();
		IEnumerable<int> e3 = new Stack<int>();

		Test(e1);
		Test(e2);
		Test(e3);

		//Überprüfung, ob ein Interface an der Klasse hängt
		if (m is IArbeit)
		{

		}
	}

	static void Test<T>(IEnumerable<T> x)
	{

	}
}

public class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit
{
	public int Gehalt { get; set; }
	
	public string Job { get; set; }

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche.");
	}
}

public interface IArbeit //Interfaces fangen per Konvention mit I an
{
	static int Wochenstunden = 40; //statisches Feld über IArbeit.Wochenstunden angreifen

	int Gehalt { get; set; }

	string Job { get; set; } //Properties werden weitergegeben

	void Lohnauszahlung(); //Methoden ohne Body wie bei abstrakten Klassen

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit : IArbeit
{
	static new int Wochenstunden = 20;

	new void Lohnauszahlung();
}



public class Fahrzeug
{
	//...
}

public class PKW : Fahrzeug { }

public class Schiff : Fahrzeug, IBeladbar
{
	public void Segeln() { }
}

public class Flugzeug : Fahrzeug
{ 

}

public class LKW : Fahrzeug, IBeladbar
{

}

public interface IBeladbar
{

}