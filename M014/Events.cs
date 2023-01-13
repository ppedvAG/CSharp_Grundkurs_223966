namespace M014;

internal class Events
{
	//event: Statischer Punkt an den Methoden angehängt werden können (kann nicht erstellt werden)
	static event EventHandler TestEvent;

	//EventHandler: Delegate das sender und args vorgibt (hauptsächlich in WPF, ASP, Xamarin, ... zu finden)
	static event EventHandler<TestEventArgs> ArgsEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Methode anhängen
		TestEvent(null, EventArgs.Empty); //Event ausführen

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent(null, new TestEventArgs() { Status = "Erfolg" });
	}

	private static void Events_TestEvent(object? sender, EventArgs e) => Console.WriteLine("TestEvent wurde ausgeführt");

	private static void Events_ArgsEvent(object? sender, TestEventArgs e) => Console.WriteLine(e.Status);
}

internal class TestEventArgs : EventArgs
{
	public string Status { get; set; }
}