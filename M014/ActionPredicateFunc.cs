namespace M014;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
		action += Subtrahiere;
		action(6, 2);
		action?.Invoke(5, 9);

		DoAction(4, 5, Addiere); //Das Verhalten der Methode anpassen über den Action Parameter
		DoAction(4, 5, Subtrahiere);
		DoAction(4, 5, action);

		Predicate<int> pred = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		pred += CheckForOne;
		bool b = pred(2); //Ergebnis der letzten Methode wird genommen
		bool? b2 = pred?.Invoke(0); //Drei mögliche Ergebnisse: true, false oder null wenn das Predicate null ist
		bool b3 = pred?.Invoke(0) == true; //false oder null -> false, sonst true

		DoPredicate(3, CheckForZero); //Das Verhalten der Methode anpassen über den Predicate Parameter
		DoPredicate(3, CheckForOne);
		DoPredicate(2, pred);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert (letztes Generic ist der Rückgabetyp), bis zu 16 Parameter
		func += Dividiere;
		double d = func(5, 4); //Das letzte Ergebnis
		double? d2 = func?.Invoke(4, 8);

		DoFunc(4, 2, Multipliziere);
		DoFunc(9, 3, Dividiere);
		DoFunc(5, 2, func);

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		DoAction(6, 2, (x, y) => Console.WriteLine($"{x} + {y} = {x + y}")); //Action als anonyme Methode
		DoPredicate(4, (x) => x % 2 == 0); //Ist die gegebene Zahl gerade? (Lambda Expression muss einen bool zurückgeben)
		DoFunc(5, 2, (x, y) => (double) x % y); //Anonyme Methode bei Func mit double als Ergebnis

		List<int> ints = new() { 1, 2, 3, 4 };
		ints.Find(pred => pred % 2 == 0);
		ints.ForEach(x => Console.WriteLine(x));
	}

	#region Action
	private static void Addiere(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	private static void Subtrahiere(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	private static void DoAction(int x, int y, Action<int, int> action) => action?.Invoke(x, y);
	#endregion

	#region Predicate
	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	private static bool DoPredicate(int x, Predicate<int> pred) => pred(x);
	#endregion

	#region Func
	private static double Multipliziere(int arg1, int arg2) => arg1 * arg2;

	private static double Dividiere(int arg1, int arg2) => arg1 / arg2;

	private static double DoFunc(int x, int y, Func<int, int, double> func) => func(x, y);
	#endregion
}
