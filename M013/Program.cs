namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception("Test");

		try //Codeblock markieren + Rechtsklick -> Surround with -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exception sind die Fehler die auftreten können
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException
			if (x == 0)
				throw new TestException("Die Zahl darf nicht 0 sein"); //beliebige Exception werfen
		}
		catch (FormatException) //Keine Zahl (Buchstaben)
		{
			Console.WriteLine("Keine Zahl eingegeben");
		}
		catch (OverflowException e) //Zahl zu klein/groß
		{
			Console.WriteLine("Die Zahl ist zu klein/groß");
			Console.WriteLine();
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
		}
		catch (TestException e)
		{
			Console.WriteLine(e.Message);
			e.Test(); //Methode aus eigener Exception verwenden
		}
		catch (Exception e) //Alle anderen Fehler
		{
			Console.WriteLine($"Anderer Fehler: {e.Message}");
			//throw; //Fataler Fehler
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception //Eigene Exception muss von einer Exception Klasse erben
{
	public TestException(string? message) : base(message) { }

	public void Test()
	{

	}
}