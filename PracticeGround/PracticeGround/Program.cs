using System.Security.Cryptography.X509Certificates;

namespace PracticeGround;

public class Program
{
    public static void Main()
    {
        // int C = 1000000000;
        int C = 1;
        C = 2147483643;
        
        C = 78379897;
        
        Console.WriteLine(JudgeSquareSum(C));
        Console.WriteLine(JudgeSquareSum1(C));
    }
    
    /// <summary>
    /// Linear Search for Target
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool JudgeSquareSum1(int c)
    {
        if (c < 0) return false;
        Dictionary<string, bool> dpChecks = new Dictionary<string, bool>();
        
        int x = (int)Math.Ceiling(Math.Sqrt(c));
        Console.WriteLine(x+" ===> "+c+" :: ");
        
        for (int i = 0; i <= x; i++)
        {
            for (int j = x; j >= 0; j--)
            {
                var tmp = i * i + j*j;
                if (c == tmp)
                {
                    Console.WriteLine("1st = "+i+", 2nd = "+j);
                    return true;
                }
            }
        }
        return false;
    }
    
    /// <summary>
    /// Binary Search for Item
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool JudgeSquareSum(int c)
    {
        if (c < 0) return false;
        Dictionary<string, bool> dpChecks = new Dictionary<string, bool>();
        
        int x = (int)Math.Ceiling(Math.Sqrt(c));
        Console.WriteLine(x+" ===> "+c+"  :: "+(int)Math.Log2(c));
        
        for (int i = 0; i <= x; i++)
        {
            // Do Binary search, from i to x 
            int z = x - (int)Math.Log2(c);
            if (z < 0)
                z = 0;
            for (int j = z; j <= x; j++)
            {
                var tmp = i * i + j*j;
                if (c == tmp)
                {
                    Console.WriteLine("1st = "+i+", 2nd = "+j);
                    return true;
                }
            }
        }
        return false;
    }
}