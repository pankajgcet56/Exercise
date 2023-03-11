using System.Collections;

public class MainApp
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.MapGet("/", () => "Hello World!");
        Console.WriteLine("Pankaj");
        app.Run();
    }
}