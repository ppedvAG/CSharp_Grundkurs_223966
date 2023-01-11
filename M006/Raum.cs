using M006.Bauteile;

namespace M006;

internal class Raum
{
	public Tuere Tuer { get; set; }

	public Fenster[] Fenster = new Fenster[10];

	public double Laenge, Breite;
}
