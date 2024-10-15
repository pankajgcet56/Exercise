namespace PracticeGround.Week40_2024;

public class ProblemTwoPointers : ILeetCodeSolotion
{
    public void RunSolution()
    {
        Console.WriteLine(MinimumSteps_DirectSwap("100"));
    }
    
    private long MinimumSteps_DirectSwap(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        
        char[] finalStr = new char[s.Length];
        int left = 0;
        int right = s.Length - 1;
        
        foreach (var c in s)
        {
            if (c == '1')
            {
                finalStr[right] = c;
                right--;
            }

            if (c == '0')
            {
                finalStr[left] = c;
                left++;
            }
        }
        string s1 = new string(finalStr);
        string s2 = s.Substring(0, left);
        Console.WriteLine(s1+" Left= "+left+", Right= "+right);
        long count = 0;
        foreach (var c in s2)
        {
            if (c == '1')
            {
                count++;
            }
        }
        return count;
    }
}