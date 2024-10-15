namespace PracticeGround.Week40_2024;

public class Problem41 : ILeetCodeSolotion
{
    public void RunSolution()
    {
        Main2(null);
    }
    
    static void Main2(string[] args)
    {
        int[] arr = { 1, 1, 2, 2, 3, 4, 4, 5 };
        int length = RemoveDuplicates(arr);

        Console.Write("Array after removing duplicates: ");
        for (int i = 0; i < length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }

    static int RemoveDuplicates(int[] arr)
    {
        if (arr.Length == 0)
            return 0;

        int currentIndex = 0; // Initialize currentIndex to track unique elements
        int nextIndex = 1; // nextIndex to scan through the array

        // Process the array until nextIndex reaches the end
        while (nextIndex < arr.Length)
        {
            if (arr[nextIndex] != arr[currentIndex])
            {
                // If a new unique element is found, move currentIndex and set its value
                currentIndex++;
                arr[currentIndex] = arr[nextIndex];
            }
            nextIndex++;
        }

        return currentIndex + 1; // Return the length of the array with unique elements
    }
}