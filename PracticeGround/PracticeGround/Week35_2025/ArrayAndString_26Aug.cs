namespace PracticeGround.Week35_2025;

public class ArrayAndString_26Aug : ILeetCodeSolotion
{
    public void RunSolution()
    {
        Console.WriteLine("Pankaj Sol");
        string testdaat = " ";
        Console.WriteLine(LengthOfLongestSubstring(testdaat));
    }
    
    public int LengthOfLongestSubstring(string s)
    {
        int maxLen = 0;
        HashSet<char> hashSet = new();

        foreach (var cha in s)
        {
            if (hashSet.Add(cha) || cha.Equals(' '))
            {
                continue;
            }
            else
            {
                Console.WriteLine("MaxLen = "+maxLen+", MapLen = "+hashSet.Count);
                if (hashSet.Count > maxLen)
                {
                    maxLen = hashSet.Count;
                }

                hashSet.Clear();
                hashSet.Add(cha);
            }
        }
        return maxLen;
    }
}