using Cheeseburger_Chucker2;

class Program
{
    [STAThread]
    static int Main()
    {
        Console.WriteLine("Hello World");

        using Game1 game = new();
        game.Run();

        return 0;
    }
}