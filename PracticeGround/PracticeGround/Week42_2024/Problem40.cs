namespace PracticeGround.Week40_2024;

public class Problem40 : ILeetCodeSolotion
{
    public void RunSolution()
    {
        int[] data = new[] { 1,4 };
        Console.WriteLine("Med ..."+Median(data));
        
    }

    private double Median(int[] data)
    {
        if (data == null)
            return -1;
        if (data.Length % 2 == 0)
        {
            int index1 = (data.Length / 2)-1;
            return (data[(data.Length / 2) - 1] + data[data.Length / 2])/2f;
        }
        else
        {
            return data[(data.Length / 2)];
        }
    }
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1 == null || nums2 == null)
            return -1;
        
        int[] data = new int[nums1.Length+nums2.Length];
        data = nums1.Concat(nums2).OrderBy(x=>x).ToArray();
        return Median(data);
    }
}