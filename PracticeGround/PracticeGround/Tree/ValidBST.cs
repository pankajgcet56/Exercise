using System.Collections.Generic;

namespace PracticeGround.Tree;

public class TreeNode
{
    public int Val { get; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }
    
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

/// <summary>
/// Validates if a binary tree is a valid Binary Search Tree (BST).
/// </summary>
public class ValidBst
{
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

/// <summary>
/// Performs an in-order traversal of a binary tree.
/// In-order traversal visits left subtree, then root, then right subtree.
/// </summary>
public class InOrderTraversal
{
    /// <summary>
    /// Performs an in-order traversal of a binary tree and returns the values in traversal order.
    /// </summary>
    /// <param name="root">The root node of the binary tree</param>
    /// <returns>A list of node values in in-order traversal sequence</returns>
    public IList<int> InorderTraversal(TreeNode? root)
    {
        IList<int> result = new List<int>();
        InorderTraversalHelper(root, result);
        return result;
    }
    
    private void InorderTraversalHelper(TreeNode? node, IList<int> result)
    {
        if (node == null)
            return;
            
        InorderTraversalHelper(node.Left, result);
        result.Add(node.Val);
        InorderTraversalHelper(node.Right, result);
    }
}