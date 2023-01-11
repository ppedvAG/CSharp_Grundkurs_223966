namespace M008;

internal class Fenster : Bauteil
{
	#region Properties
	//Get-Only Property
	public double Area
	{
		get
		{
			return Laenge * Breite;
		}
	}

	public double AreaKurz
	{
		get => Laenge *Breite;
	}

	public double AreaNochKuerzer => Laenge * Breite;

	public double CalcArea() => Laenge * Breite;
	
	private FensterStatus status = FensterStatus.Geschlossen; //Hier Standardwert auf Variablenebene setzen
	
	public FensterStatus Status
	{
		get => status;
		private set => status = value; //private set: nicht von außen setzbar (nur innerhalb der Klasse)
	}

	/// <summary>
	/// Eine Methode die das Fenster öffnet
	/// </summary>
	public void FensterOeffnen()
	{
		if (Status != FensterStatus.Offen)
			Status = FensterStatus.Offen; //hier private set sichtbar
		else
			Console.WriteLine("Fenster ist bereits geöffnet");
	}

	private string farbe = "Grau"; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)

	public int Scheibenanzahl { get; set; } = 2; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)
	#endregion

	#region Konstruktoren
	public Fenster() { }

	/// <summary>
	/// Der Initialcode des Fensters.
	/// </summary>
	/// <param name="laenge">Die Länge des Fensters</param>
	/// <param name="breite">Die Breite des Fensters</param>
	public Fenster(double laenge, double breite) //Konstruktor: Code der bei Erstellung des Objekts (new) ausgeführt wird
	{
		Laenge = laenge;
		Breite = breite;
	}

	public Fenster(double laenge, double breite, int scheiben) : this(laenge, breite) //Konstruktoren verketten (wenn dieser Konstruktor verwendet wird, wird der obere auch verwendet)
	{
		Scheibenanzahl = scheiben;
	}
	#endregion
}

enum FensterStatus
{
	Offen,
	Gekippt,
	Geschlossen
}