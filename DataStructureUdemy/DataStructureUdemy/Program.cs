// See https://aka.ms/new-console-template for more information

using System.Reflection;

namespace DataStructureUdemy;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var type = typeof(Problem);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p));
        foreach (var typeVal in types)
        {
            var bClass = (Problem)Activator.CreateInstance(typeVal)!;
            bClass?.Run();

        }
    }
}

public class Problem
{
    public virtual void Run()
    {
        // Console.WriteLine("This is Base Class");
    }
}