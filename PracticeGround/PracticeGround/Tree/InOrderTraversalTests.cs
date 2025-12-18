using System.Collections.Generic;
using Xunit;

namespace PracticeGround.Tree.Tests;

public class InOrderTraversalTests
{
    private readonly InOrderTraversal _traversal = new();

    [Fact]
    public void InorderTraversal_NullRoot_ReturnsEmptyList()
    {
        var result = _traversal.InorderTraversal(null);
        Assert.Empty(result);
    }

    [Fact]
    public void InorderTraversal_SingleNode_ReturnsSingleValue()
    {
        var root = new TreeNode(5);
        var result = _traversal.InorderTraversal(root);
        
        Assert.Single(result);
        Assert.Equal(5, result[0]);
    }

    [Fact]
    public void InorderTraversal_BalancedTree_ReturnsInOrderValues()
    {
        var root = new TreeNode(2, 
            new TreeNode(1), 
            new TreeNode(3));
            
        var result = _traversal.InorderTraversal(root);
        
        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }

    [Fact]
    public void InorderTraversal_ComplexTree_ReturnsInOrderValues()
    {
        var root = new TreeNode(4,
            new TreeNode(2, 
                new TreeNode(1), 
                new TreeNode(3)),
            new TreeNode(6, 
                new TreeNode(5), 
                new TreeNode(7)));
                
        var result = _traversal.InorderTraversal(root);
        
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, result);
    }

    [Fact]
    public void InorderTraversal_LeftSkewedTree_ReturnsInOrderValues()
    {
        var root = new TreeNode(4,
            new TreeNode(3,
                new TreeNode(2,
                    new TreeNode(1),
                    null),
                null),
            null);
                
        var result = _traversal.InorderTraversal(root);
        
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, result);
    }

    [Fact]
    public void InorderTraversal_RightSkewedTree_ReturnsInOrderValues()
    {
        var root = new TreeNode(1,
            null,
            new TreeNode(2,
                null,
                new TreeNode(3,
                    null,
                    new TreeNode(4))));
                
        var result = _traversal.InorderTraversal(root);
        
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, result);
    }
}