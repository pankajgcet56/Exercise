namespace PracticeGround;

public class OldProgram
{
    
    
    public static int Search(int[] nums, int target)
    {
        int startIndex = 0;
        int lastIndex = nums.Length-1;
        while (lastIndex >= startIndex)
        {
            int mid = (lastIndex + startIndex) / 2;
            int midVal = nums[mid];
            Console.WriteLine("StartIndex = "+startIndex+", MidIndex = "+mid+", LastIndex = "+lastIndex);
            if (midVal > target)
            {
                lastIndex = mid-1;
            }
            else if(midVal<target)
            {
                startIndex = mid + 1;
            }
            else
            {
                return mid;
            }
        }
        return -1;
    }
    public static int FindDuplicate(int[] nums)
    {
        HashSet<int> hashSet = new HashSet<int>();
        foreach (var val in nums)
        {
            if (!hashSet.Add(val)) return val;
            
        }
        return 0;
    }
    public static int[] SearchRange(int[] nums, int target)
    {
        List<int> res = new List<int>();
        res.Add(-1);res.Add(-1);
        bool isSearchDone = false;
        int startIndex = 0;
        int endIndex = nums.Length-1;
        if (startIndex == endIndex && nums[startIndex] == target)
        {
            res[1]=res[0] = startIndex;
        }
        while (endIndex > startIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            int mid = nums[midIndex];
            if (mid > target)
            {
                endIndex = midIndex;
                Console.WriteLine("StartIndex = "+startIndex +", End Index = "+endIndex);
            }
            else if(mid < target)
            {
                if (midIndex == startIndex)
                {
                    if (nums[endIndex] == target)
                    {
                        res[1]=res[0] = endIndex;
                        break;
                    }
                    
                    midIndex++;
                }
                startIndex = midIndex;
                Console.WriteLine("StartIndex = "+startIndex +", End Index = "+endIndex);
            }
            else
            {
                res[1]=res[0] = midIndex;
                Console.WriteLine("Found : "+target+", AT : "+midIndex);
                int downCount = midIndex;
                int upCount = midIndex;
                while (nums[downCount] == target && downCount>startIndex)
                {
                    downCount--;
                }
                while (nums[upCount] == target && upCount<endIndex)
                {
                    upCount++;
                }

                res[0] = nums[downCount] == target? downCount : downCount+1;
                res[1] = nums[upCount] == target ? upCount : upCount - 1;
                break;
            }
        }
        return res.ToArray();
    }

    public int SearchOld(int[] nums, int target) {

        int mid = nums.Length/2;
        // Finding Pivot
        int findIndex = FindNum(nums,target,0,nums.Length);
        Console.WriteLine(findIndex);
        return findIndex;
    }

    private int FindNum(int[] nums, int target, int startIndex, int endIndex)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (right >= left)
        {
            int leftData = nums[left];
            int rightData = nums[right];
            int mid = (left + right) / 2;
            int midData = nums[mid];
            if (mid == target) return mid;
            // If Target is between Mid Data and Left --> go Left
            // else go right
        }
        return -1;
    }

    private int PivoteIndex(int[] nums,int startIndex, int lastIndex)
    {
        // int mid = (lastIndex+startIndex)/2;
        // if(num[mid]>num[nums.Length])
        // {
        //     PivoteIndex(num,mid,lastIndex);
        // }
        // elseif(num[mid]< num[nums.Length])
        // {

        // }
        return 0;
    }
    public static int MaxFrequencyElements(int[] nums)
    {
        // Key : Num, Value : Frequency 
        Dictionary<int, int> data = new Dictionary<int, int>();
        int maxCount = 0;
        foreach (var num in nums)
        {
            if (data.ContainsKey(num))
            {
                data[num] += 1;
                maxCount = maxCount > data[num] ? maxCount : data[num];
            }
            else
            {
                data.Add(num,1);
                maxCount = maxCount == 0 ? 1 : maxCount;
            }
        }

        int res = 0;
        foreach (var kvp in data)
        {
            if (kvp.Value == maxCount)
            {
                res += kvp.Value;
            }
        }
        return res;
    }
    
    public static int KEmptySlots(int[] bulbs, int k) 
    {   
        int n = bulbs.Length;
        int res = int.MaxValue;
        for(int i =0;i<n-k-1;++i)
        {
            int maxOp = Math.Max(bulbs[i],bulbs[i+k+1]);
            Console.WriteLine(", Max = "+maxOp);
            bool isWindowDone = true;
            for (int j=i+1; j<i+k+1; ++j)
            {
                if(maxOp > bulbs[j])
                {
                    Console.WriteLine("I = "+i+", J = "+j+", k = "+k);
                    isWindowDone = false;
                    break;
                }
            }
            if(isWindowDone)
            {
                Console.WriteLine("res = "+res+", Min = "+", Max = "+maxOp);
                int minimum = Math.Min(res,maxOp);
                res = minimum;
                Console.WriteLine(res);
            }
        }
        return res == int.MaxValue?-1:res;
    }
}

/**
 * Definition for a binary tree node.
 */
 public class TreeNode 
{
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
     {
             this.val = val;
             this.left = left;
             this.right = right;
     }
 }
public class Solution 
{
    private bool CheckTwoTreeAreSame(TreeNode root1, TreeNode root2)
    {
        if (root2 != root1) return false;
        return CheckTwoTreeAreSame(root1.left, root2.left) && CheckTwoTreeAreSame(root1.right,root2.right);
    }
    public IList<TreeNode> GenerateTrees(int n)
    {
        return null;
    }
    
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> res = new List<int>();
        Helper(root, res);
        return res;
    }
    private void Helper(TreeNode root, IList<int> res)
    {
        if(root == null) return;
        Helper(root.left,res);
        res.Add(root.val);
        Helper(root.right,res);
    }
}