using System.Collections;
using System.Diagnostics;

namespace M017;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		Console.WriteLine(w1 == w2);

		Zug z = new();
		foreach (Wagon w in z)
		{

		}

		//z[1] = w1;
		//Console.WriteLine(z["Rot"]);
		//Console.WriteLine(z[30, "Blau"]);

		Stopwatch sw = new Stopwatch();
		sw.Start();
		Thread.Sleep(Random.Shared.Next(1000, 5000));
		//Code...

		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);

		System.Timers.Timer timer = new();
		timer.Interval = 1000;
		timer.Elapsed += Timer_Elapsed;
		timer.Start();

		Console.ReadKey();
	}

	private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
	{
		Console.WriteLine("Intervall");
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public Wagon this[int index]
	{
		get => Wagons[index];
		set => Wagons[index] = value;
	}

	public Wagon this[string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe);
	}

	public Wagon this[int anz, string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe && e.AnzSitze == anz);
	}
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}