namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Enumerable.Range: Liste von <Start> mit <Anzahl> Elementen
		//Liste von 1-20
		List<int> ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Sum());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());
		Console.WriteLine(ints.Average());

		Console.WriteLine(ints.First()); //Gibt das erste Element zurück, Exception wenn kein Element gefunden wird
		Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element zurück, default wenn kein Element gefunden wird

		Console.WriteLine(ints.Last()); //Gibt das letzte Element zurück, Exception wenn kein Element gefunden wird
		Console.WriteLine(ints.LastOrDefault()); //Gibt das letzte Element zurück, default wenn kein Element gefunden wird

		//ints.First(e => e % 50 == 0); //Exception
		ints.FirstOrDefault(e => e % 50 == 0);
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Lambda
		//Alle Fahrzeuge die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs mit MaxV >= 200
		fahrzeuge.Where(e => e.MaxV >= 200 && e.Marke == FahrzeugMarke.VW);

		//Autos nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Originale Liste wird nicht verändert
		fahrzeuge.OrderByDescending(e => e.Marke);

		//Autos nach Marke sortieren und danach nach MaxV
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Alle Marken in der Liste finden
		fahrzeuge.Select(e => e.Marke); //Liste von Marken
		fahrzeuge.Select(e => e.MaxV); //Liste von Geschwindigkeiten

		//Alle Marken nur einmal finden
		fahrzeuge.Select(e => e.Marke).Distinct();

		//Fahren alle Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200);

		//Fährt mindestens ein Fahrzeug mindestens 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200);

		//Ist in der Liste mindestens ein Element?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele VWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW); //4

		//Was ist die Durchschnittsgeschwindigkeit aller Autos?
		fahrzeuge.Average(e => e.MaxV);

		//Was ist die Summe der Geschwindigkeiten?
		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit

		fahrzeuge.Max(e => e.MaxV); //Die größte Geschwindigkeit
		fahrzeuge.MaxBy(e => e.MaxV); //Das Fahrzeug mit der größten Geschwindigkeit

		//Die Durchschnittsgeschwindigkeit aller VWs
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Average(e => e.MaxV);

		//Gruppiert die Liste anhand eines Kriteriums (Audi-Gruppe, BMW-Gruppe, VW-Gruppe)
		Dictionary<FahrzeugMarke, List<Fahrzeug>> group = fahrzeuge.GroupBy(e => e.Marke).ToDictionary(e => e.Key, e => e.ToList());
		//group[FahrzeugMarke.VW] //einzelne Gruppe angreifen
		#endregion

		#region Erweiterungsmethoden
		int x = 438274;
		x.Quersumme();
		Console.WriteLine(35729.Quersumme());

		fahrzeuge.Shuffle();

		group.Where(e => e.Key == FahrzeugMarke.BMW); //Dictionary hat auch Linq-Funktion
		#endregion
	}
}

public record Fahrzeug(int MaxV, FahrzeugMarke Marke);

//public class Fahrzeug
//{
//	public int MaxGeschwindigkeit { get; set; }

//	public FahrzeugMarke Marke { get; set; }

//	public Fahrzeug(int v, FahrzeugMarke fm)
//	{
//		MaxGeschwindigkeit = v;
//		Marke = fm;
//	}
//}

public enum FahrzeugMarke { Audi, BMW, VW }