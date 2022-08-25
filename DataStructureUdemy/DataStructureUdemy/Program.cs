// See https://aka.ms/new-console-template for more information

using System.Reflection;

namespace DataStructureUdemy;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main Start");
        var type = typeof(Problem);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p));
        var baseClass = new Problem();
        foreach (var typeVal in types)
        {
            baseClass = (Problem)Activator.CreateInstance(typeVal)!;
        }
        baseClass?.Run();
    }
}

public class Problem
{
    public virtual void Run()
    {
        
    }
}