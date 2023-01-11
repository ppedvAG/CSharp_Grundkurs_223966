using M006.Bauteile; //mit Using andere Namespaces importieren

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		Fenster f = new Fenster(); //Fenster Objekt erstellen mit dem new Keyword
		f.SetLaenge(4); //Länge setzen über Set-Methode
		f.Breite = 3; //Breite setzen über Property
		Console.WriteLine(f.Area);
		//f.Area = 4;
		Console.WriteLine(f.Status);
		//f.Status = FensterStatus.Geschlossen;

		Fenster f2 = new Fenster(5, 5, 2);

		//Referenzen zwischen Objekten
		Raum r = new Raum();
		Tuere t = new Tuere();
		r.Tuer = t;
		r.Fenster[0] = f;
		r.Fenster[1] = f2;

		//Console -> System
		//File -> System.IO
		//HttpClient -> System.Net.Http
	}
}