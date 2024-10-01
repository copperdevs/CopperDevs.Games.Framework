namespace CopperDevs.Games.Framework.Testing;

public static class Program
{
    public static void Main()
    {
        var settings = new EngineSettings();
        
        using var game = new Game(settings);
        game.Run();
    }
}