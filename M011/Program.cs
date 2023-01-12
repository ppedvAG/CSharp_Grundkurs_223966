using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		List<int> list = new List<int>(); //Erstellung einer Liste mit Generic
		list.Add(2); //T wird ersetzt durch int
		list.Add(4); //T wird ersetzt durch int
		list.Add(8); //T wird ersetzt durch int
		list.Remove(2); //Entfernt das erste Element das der Bedingung entspricht
		list.RemoveAt(1); //Entfernt ein Element anhand eines Indizes

		List<string> strList = new List<string>();
		strList.Add("Test"); //T wird ersetzt durch string

		Console.WriteLine(list[0]); //Funktioniert genau wie beim Array
		list[0] = 34; //Zuweisung genau wie bei Array

		Console.WriteLine(list.Count); //Count statt Length, nicht Count() benutzen

		list.Sort(); //Liste sortieren

		foreach (int item in list) //Liste iterieren wie bei Arrays
		{
			Console.WriteLine(item);
		}

		if (list.Contains(2))
		{

		}

		list.Clear(); //Entleert die Liste


		Stack<int> stack = new Stack<int>();
		stack.Push(1); //Elemente auflegen
		stack.Push(2); //Elemente auflegen
		stack.Push(3); //Elemente auflegen
		stack.Push(4); //Elemente auflegen

		Console.WriteLine(stack.Peek()); //Oberstes Element anschauen (4)

		Console.WriteLine(stack.Pop());  //Oberstes Element anschauen und entfernen (4)


		Queue<int> queue = new Queue<int>();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);

		Console.WriteLine(queue.Peek()); //Erstes Element anschauen (1)

		Console.WriteLine(queue.Dequeue()); //Erstes Element anschauen und entfernen (1)


		Dictionary<string, int> einwohnerzahlen = new(); //Liste von Key-Value Paaren, Keys müssen eindeutig sein
		einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter: Key = string, Value = int
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //ArgumentException

		if (!einwohnerzahlen.ContainsKey("Paris")) //Überprüfen ob ein Key schon existiert
		{

		}

		Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary mit [] angreifen über den Key (hier string), Value als Ergebnis

		einwohnerzahlen.ContainsValue(2_000_000); //Überprüfen ob ein Value existiert

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var -> Strg + . -> Typ generieren lassen
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner."); //mit kv.Key und kv.Value auf Key/Value zugreifen
		}

		List<string> keys = einwohnerzahlen.Keys.ToList(); //Nur auf Keys zugreifen
		List<int> values = einwohnerzahlen.Values.ToList(); //Nur auf Values zugreifen


		SortedDictionary<string, int> einwohnerzahlenSorted = new(); //Sortiert sich bei jedem Add automatisch nach dem Key (Achtung: Performance)
		einwohnerzahlenSorted.Add("Wien", 2_000_000);
		einwohnerzahlenSorted.Add("Berlin", 3_650_000); //Berlin vor Wien
		einwohnerzahlenSorted.Add("Paris", 2_160_000); //Paris zwischen Berlin und Wien

		ObservableCollection<string> str = new(); //Benachrichtigt bei jeder Listenänderungen
		str.CollectionChanged += Str_CollectionChanged; //Immer wenn sich in der Liste etwas ändert, wird die angehängte Methode ausgeführt
		str.Add("X");
		str.Add("Y");
		str.Add("Z");
		str.Remove("X");
	}

	private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				Console.WriteLine($"Ein Element wurde hinzugefügt: {e.NewItems[0]}");
				break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Ein Element wurde entfernt: {e.OldItems[0]}");
				break;
			//case NotifyCollectionChangedAction.Replace:
			//	break;
			//case NotifyCollectionChangedAction.Move:
			//	break;
			//case NotifyCollectionChangedAction.Reset:
			//	break;
		}
	}
}