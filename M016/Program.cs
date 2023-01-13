using System.Text.Json;
using System.Xml.Serialization;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

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

		//Streams();

		//NewtonsoftJson();

		//SystemJson();
	}

	public void Streams()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1"); //Stream füllen
		sw.WriteLine("Test2"); //Stream füllen
		sw.WriteLine("Test3"); //Stream füllen
		sw.Flush(); //Schreibt den Inhalt vom Stream in das File
		sw.Close(); //Stream schließen, Datei kann nicht angegriffen werden wenn der Stream offen bleibt

		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw2.WriteLine("Test4"); //Stream füllen
			sw2.WriteLine("Test5"); //Stream füllen
			sw2.WriteLine("Test6"); //Stream füllen
		} //Schließt sich am automatisch am Ende des Blocks

		using StreamWriter sw3 = new StreamWriter(filePath); //using-Statement: seit C#10, schließt sich am Ende der Methode
		sw3.WriteLine("Test4"); //Stream füllen
		sw3.WriteLine("Test5"); //Stream füllen
		sw3.WriteLine("Test6"); //Stream füllen

		using StreamReader sr = new StreamReader(filePath);
		while (!sr.EndOfStream)
		{
			sr.ReadLine(); //nächste Zeile in eine Liste schreiben
		}
		sr.ReadToEnd(); //ganzes File einlesen

		File.WriteAllText(filePath, "Ein String"); //Schnell einen String in ein File schreiben

		File.ReadAllText(filePath); //Ließt das ganze File in einen String ein
		File.ReadAllLines(filePath); //Ließt das ganze File Zeile für Zeile in ein string[] ein
	}

	public void NewtonsoftJson()
	{
		//string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern unter Windows

		//string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		//string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		//List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		//{
		//	new Fahrzeug(251, FahrzeugMarke.BMW),
		//	new Fahrzeug(274, FahrzeugMarke.BMW),
		//	new Fahrzeug(146, FahrzeugMarke.BMW),
		//	new Fahrzeug(208, FahrzeugMarke.Audi),
		//	new Fahrzeug(189, FahrzeugMarke.Audi),
		//	new Fahrzeug(133, FahrzeugMarke.VW),
		//	new Fahrzeug(253, FahrzeugMarke.VW),
		//	new Fahrzeug(304, FahrzeugMarke.BMW),
		//	new Fahrzeug(151, FahrzeugMarke.VW),
		//	new Fahrzeug(250, FahrzeugMarke.VW),
		//	new Fahrzeug(217, FahrzeugMarke.Audi),
		//	new Fahrzeug(125, FahrzeugMarke.Audi)
		//};

		//JsonSerializerSettings settings = new JsonSerializerSettings();
		//settings.Formatting = Formatting.Indented;
		//settings.TypeNameHandling = TypeNameHandling.Objects;

		//string json = JsonConvert.SerializeObject(fahrzeuge, settings);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson, settings);
	}

	public void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

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

		JsonSerializerOptions settings = new JsonSerializerOptions();
		settings.WriteIndented = true;

		string json = JsonSerializer.Serialize(fahrzeuge, settings);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson, settings);
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }