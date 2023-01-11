namespace M008;

class AccessModifier //Klassen und Member ohne Modifier sind internal
{
	public string Name { get; set; } //Überall sichtbar, auch außerhalb vom Projekt

	private int Alter { get; set; } //Nur innerhalb dieser Klasse sichtbar

	internal string Wohnort { get; set; } //Überall sichtbar, aber nur innerhalb vom Projekt


	protected string Lieblingsfarbe { get; set; } //Nur innerhalb der Klasse (~ private) und in Unterklassen (auch außerhalb vom Projekt)

	protected internal string Lieblingsnahrung { get; set; } //Kann überall innerhalb des Projekts (internal) und in Unterklassen außerhalb vom Projekt gesehen werden

	protected private DateTime Geburtsdatum { get; set; } //Kann nur in dieser Klasse und in Unterklassen nur im Projekt gesehen werden
}
