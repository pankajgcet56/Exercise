using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace PracticeGround;

public class Program
{
    public static void Main()
    {
        string sourceDirectory = GetSolutionDirectory();

        Type interfaceType = typeof(ILeetCodeSolotion);
        var latestModifiedClass = GetLatestModifiedClassImplementingInterface(interfaceType, sourceDirectory);

        if (latestModifiedClass != null)
        {
            Console.WriteLine($"Running File: {latestModifiedClass.Name}.cs");
            ILeetCodeSolotion instance = Activator.CreateInstance(latestModifiedClass) as ILeetCodeSolotion;
            instance.RunSolution();
        }
        else
        {
            Console.WriteLine($"No classes implementing {interfaceType.Name} found.");
        }
    }

    public static List<string> GetFileTypes()
    {
        string directoryPath = GetSolutionDirectory();
        string[] fileTypes = ["*.cs"]; // Specify the file types you want to search for
        List<string> files = [];
        if (Directory.Exists(directoryPath))
        {
            foreach (string fileType in fileTypes)
            {
                files.AddRange(Directory.GetFiles(directoryPath, fileType, SearchOption.AllDirectories));
            }

            // Console.WriteLine("Files in directory and subdirectories:");
            // foreach (string file in files)
            // {
            //     // Console.WriteLine(file);
            // }
        }
        else
        {
            Console.WriteLine("Directory does not exist.");
        }

        return files;
    }
    public static Type GetLatestModifiedClassImplementingInterface(Type interfaceType, string sourceDirectory)
    {
        var implementingTypes = GetImplementingTypes(interfaceType);
        DateTime latestModificationTime = DateTime.MinValue;
        Type latestModifiedClass = null;

        var files = GetFileTypes();

        string ContainsPath(string className)
        {
            foreach (var file in files)
            {
                if (file.Contains(className))
                    return file;
            }

            return "";
        }

        foreach (var type in implementingTypes)
        {
            string filePath = ContainsPath(type.Name);
            if (!string.IsNullOrEmpty(filePath))
            {
                DateTime lastModified = File.GetLastWriteTime(filePath);
                if (lastModified > latestModificationTime)
                {
                    latestModificationTime = lastModified;
                    latestModifiedClass = type;
                }
            }
        }

        return latestModifiedClass;
    }

    public static IEnumerable<Type> GetImplementingTypes(Type interfaceType)
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && interfaceType.IsAssignableFrom(t));
    }
    
    public static string GetSolutionDirectory()
    {
        string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        while (currentDirectory != null)
        {
            if (Directory.GetFiles(currentDirectory, "*.sln").Length > 0)
            {
                return currentDirectory;
            }

            currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
        }

        return null;
    }
    /// <summary>
    /// Linear Search for Target
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool JudgeSquareSum1(int c)
    {
        // int C = 1000000000;
        int C = 1;
        C = 2147483643;
        
        C = 78379897;
        
        // Console.WriteLine(JudgeSquareSum(C));
        // Console.WriteLine(JudgeSquareSum1(C));
        
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