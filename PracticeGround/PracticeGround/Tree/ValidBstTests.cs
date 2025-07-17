using Xunit;

namespace PracticeGround.Tree;

public class ValidBstTests
{
    private readonly ValidBst _validator = new();

    [Fact]
    public void IsValidBst_NullRoot_ReturnsTrue()
    {
        Assert.True(_validator.IsValidBst(null));
    }

    [Fact]
    public void IsValidBst_SingleNode_ReturnsTrue()
    {
        var root = new TreeNode(5);
        Assert.True(_validator.IsValidBst(root));
    }

    [Fact]
    public void IsValidBst_ValidBst_ReturnsTrue()
    {
        var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        Assert.True(_validator.IsValidBst(root));
    }

    [Fact]
    public void IsValidBst_InvalidBst_LeftChildGreater_ReturnsFalse()
    {
        var root = new TreeNode(2, new TreeNode(3), new TreeNode(4));
        Assert.False(_validator.IsValidBst(root));
    }

    [Fact]
    public void IsValidBst_InvalidBst_RightChildSmaller_ReturnsFalse()
    {
        var root = new TreeNode(5, new TreeNode(3), new TreeNode(2));
        Assert.False(_validator.IsValidBst(root));
    }

    [Fact]
    public void IsValidBst_InvalidBst_EqualValues_ReturnsFalse()
    {
        var root = new TreeNode(2, new TreeNode(2), new TreeNode(3));
        Assert.False(_validator.IsValidBst(root));
    }

    [Fact]
    public void IsValidBst_ComplexValidBst_ReturnsTrue()
    {
        var root = new TreeNode(5, 
            new TreeNode(3, new TreeNode(2), new TreeNode(4)), 
            new TreeNode(7, new TreeNode(6), new TreeNode(8)));
        Assert.True(_validator.IsValidBst(root));
    }

    [Fact]
    public void IsValidBst_ViolatesBstProperty_ReturnsFalse()
    {
        // This should fail: left subtree has value 6 which is > root value 5
        var root = new TreeNode(5, 
            new TreeNode(4, null, new TreeNode(6)), 
            new TreeNode(7));
        Assert.False(_validator.IsValidBst(root));
    }
}