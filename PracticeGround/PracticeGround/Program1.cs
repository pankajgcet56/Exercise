// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

public class Program1
{
    public static void MainProgramOld()
    {
        // If Data Is Not Sorted
        // data.Sort(); // Sort Time = O(n*log(n))
      Console.WriteLine(IsValidDataSet());
    }

    public static bool IsValidDataSet()
    {
        
        int  maxCount = 6;
        int period = 7;
        List<int> data = new List<int>() {1,2,3,4,9,10,12,15,20,25,29};
 
        Queue<int> currentEvents = new Queue<int>(period);
        currentEvents.Enqueue(data[0]);

        // Solving with Help of Sliding Window 
        
        for(int i=1; i< data.Count;++i)
        {
            currentEvents.Enqueue(data[i]);
            int delta = currentEvents.Last()-period; // Max Events can Be In Window
            if(delta >= currentEvents.Peek())
            {
                while(currentEvents.Peek()<=delta)
                {
                    currentEvents.Dequeue();
                }
            }
            if(currentEvents.Count > maxCount)
                return false;
        }
        return true;
    }
    
    public static void OldMain(string[] args)
    {
        
        int[] data = { 1, 2, 3, 4, 5, };
        int target = 4;
        var res = Math.Floor(Math.Log(8,2))+1;
        List<int?> data2 = new List<int?>();
        
        Console.WriteLine(res);
        string input = "The 789number is 12345";
        // Define the regular expression pattern
        string pattern = @"\d+"; // This pattern matches one or more digits

        // Use Regex.Match to find the first occurrence of the pattern
        Match match = Regex.Match(input, pattern);

        // Check if a match was found
        if (match.Success)
        {
            // Extract the matched number
            string numberString = match.Value;
            // Parse the string to an integer
            int number = int.Parse(numberString);
            Console.WriteLine("Number extracted: " + number);
        }
        else
        {
            Console.WriteLine("No number found in the string.");
        }
    }
}

/**
 * Definition for a binary tree node.*/
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
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        return Math.Max(1 + MaxDepth(root.left), 1 + MaxDepth(root.right));
    }

    public bool IsSymmetric(TreeNode root) 
    {
        string NodeStr(TreeNode? node) => (node == null) ? "Null" : node.val.ToString();
        
        bool CompareTwoNode(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null) return true;
            if ((node1 != null && node2 != null) && node1.val == node2.val) return true;
            return false;
        }

        bool IsSubtreeEqual(TreeNode leftNode, TreeNode rightNode)
        {
            if (leftNode ==null && rightNode == null) return true;
            if (leftNode == null || rightNode == null) return false;
            bool isBothEqual = CompareTwoNode(leftNode, rightNode);
            bool leftRight = IsSubtreeEqual(leftNode.right, rightNode.left);
            bool rightleft = IsSubtreeEqual(leftNode.left, rightNode.right);
            Console.WriteLine(string.Format("Left={0}, Right={1}, isBothEqual={2}, leftRight={3}, rightleft={4}",
                NodeStr(leftNode),NodeStr(rightNode),isBothEqual,leftRight,rightleft));
            return CompareTwoNode(leftNode, rightNode) && IsSubtreeEqual(leftNode.right,rightNode.left) && IsSubtreeEqual(leftNode.left, rightNode.right);
        }
        if (root == null) return true;
        
        return IsSubtreeEqual(root.left,root.right);
    }
    private string NodeStr(TreeNode? node) => (node == null) ? "Null" : node.val.ToString(); 
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
        // Invert Child 
        TreeNode leftN = root.left;
        TreeNode rightN = root.right;

        root.left = rightN;
        root.right = leftN;
        
        root.right= InvertTree(leftN);
        root.left = InvertTree(rightN);
        string rootStr = NodeStr(root);
        string leftStr = NodeStr(root.left);
        string rightStr = NodeStr(root.right);
        Console.WriteLine(string.Format("Root = {0} Left = {1} Right = {2}",rootStr,leftStr,rightStr));
        return root;
    }
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        // Check If Nodes are Same 
        // Check if Child are Same
        bool isNodeSame = (p == null && q == null) || ((p!=null && q!=null) && p.val == q.val);
        bool isLeftSame = (p.left == null && q.left == null) ||((p.left!=null && q.left!=null) && IsSameTree(p.left, q.left));
        bool isRightSame =(p.right == null && q.right == null) || ((p.right!=null && q.right!=null) && IsSameTree(q.right, q.right));
        string p1 = (p != null) ? p.val.ToString() : "Null";
        string q1 = (q != null) ? q.val.ToString() : "Null";
        Console.WriteLine(string.Format("P = {0}, Q = {1} + IsSameNode = {2}, isLeftSame = {3},isRightSame = {2},",p1,q1,isNodeSame,isLeftSame,isRightSame)); 
        return isNodeSame && isLeftSame && isRightSame;
    }
  }
 

public class Logger
{
    private readonly HashSet<string> _hashSet = new HashSet<string>();
    private readonly Dictionary<string, int> _data = new Dictionary<string, int>();
    public Logger() 
    {    
    }
    
    public bool ShouldPrintMessage(int timestamp, string message)
    {
        Console.Write($""+timestamp+"->"+message);
        if (_hashSet.Add(message))
        {
            _data.Add(message,timestamp+10);
            Console.WriteLine(" : "+true);
            return true;
        }

        if (_data[message] <= timestamp)
        {
            Console.Write($" ,"+message+" = "+_data[message]);
            _data[message] = timestamp +10;
            Console.WriteLine(" : "+true);
            return true;
        }
        Console.WriteLine(" : "+false);
        return false;
    }
}