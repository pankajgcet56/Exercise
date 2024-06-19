namespace PracticeGround.Week25_2024;

public class MyAtoiSol : ILeetCodeSolotion
{
    public void RunSolution()
    {
        string s = "-042";
        MyAtoi(s);
        // Console.WriteLine(MyAtoi(s));
    }
    
    public int MyAtoi(string s)
    {
        List<char> filterData = new List<char>();
        
        // Space from Start, or 0
        // Select Sign If Present

        bool isExit = false;
        foreach (var ch in s)
        {
            if(isExit) break;
            
            switch (ch)
            {
                case ' ':
                    if (filterData.Count > 0)
                        isExit = true;
                    break;
                case '+':
                    if (filterData.Count > 0)
                        isExit = true;
                    else
                    {
                        filterData.Add('+');
                    }
                    break;
                case '-':
                    if (filterData.Count > 0)
                        isExit = true;
                    else
                    {
                        filterData.Add('-');
                    }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    if(filterData.Count == 0)
                        filterData.Add('+');
                    if(ch == '0' && filterData.Count == 1)
                        break;
                    filterData.Add(ch);
                    break;
                default:
                    isExit = true;
                    break;
            }
        }
        Console.WriteLine("\n"+new string(filterData.ToArray()));
        
        return 0;
    }
}
