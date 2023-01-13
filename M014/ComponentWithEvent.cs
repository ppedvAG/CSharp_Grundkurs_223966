namespace M014;

internal class ComponentWithEvent
{
	static void Main(string[] args)
	{
		Component comp = new();
		comp.ProcessCompleted += () => Console.WriteLine("Prozess fertig");
		comp.Progress += (x) => Console.WriteLine($"Fortschritt: {x}");
		comp.StartProcess();
	}
}

public class Component
{
	public event Action ProcessCompleted;

	public event Action<int> Progress;

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			Progress(i);
		}
		ProcessCompleted();
	}
}