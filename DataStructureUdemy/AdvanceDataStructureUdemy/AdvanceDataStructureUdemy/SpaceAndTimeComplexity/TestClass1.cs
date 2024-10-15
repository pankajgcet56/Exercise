namespace DataStructureUdemy.SpaceAndTimeComplexity;
using System.Diagnostics;
public class TestClass1 : Problem
{
    private int n = int.MaxValue/1000;
    private List<int> data;
    public TestClass1()
    {
        this.RunIndex = float.MaxValue;
        data = new List<int>();
    }

    public override void Run()
    {
        var random = new Random();
        var watch = new Stopwatch();
        for (int i = 0; i < n; i++)
        {
            data.Add(random.Next(int.MaxValue));
        }
        watch.Start();
        data.Sort();
        watch.Stop();
        Console.WriteLine("Ticks = "+watch.ElapsedTicks+", Ms = "+watch.ElapsedMilliseconds);
    }
}