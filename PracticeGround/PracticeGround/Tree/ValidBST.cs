namespace PracticeGround.Tree;

 public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
 {
     public readonly int Val = val;
     public readonly TreeNode? Left = left;
     public readonly TreeNode? Right = right;
 }
public class ValidBst
{
    private void TestClass()
    {
        TreeNode node = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        Console.WriteLine(node.Left);
    }
    public bool IsValidBst(TreeNode? root) 
    {
        return IsValidBst(root, long.MinValue, long.MaxValue);
    }
    
    private bool IsValidBst(TreeNode? root, long min, long max)
    {
        if (root == null)
            return true;
        if (root.Val <= min || root.Val >= max)
            return false;
        return IsValidBst(root.Left, min, root.Val) && 
               IsValidBst(root.Right, root.Val, max);
    }
}