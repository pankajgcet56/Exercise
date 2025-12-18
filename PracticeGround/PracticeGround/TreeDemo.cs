using PracticeGround.Tree;

namespace PracticeGround;

public class TreeDemo
{
    public static void MainDemo()
    {
        var validator = new ValidBst();
        var traversal = new InOrderTraversal();

        // Valid BST
        var validBst = new PracticeGround.Tree.TreeNode(5, 
            new PracticeGround.Tree.TreeNode(3, new PracticeGround.Tree.TreeNode(2), new PracticeGround.Tree.TreeNode(4)), 
            new PracticeGround.Tree.TreeNode(7, new PracticeGround.Tree.TreeNode(6), new PracticeGround.Tree.TreeNode(8)));
        
        Console.WriteLine("=== Valid BST ===");
        Console.WriteLine($"Tree: [2,3,4,5,6,7,8]");
        Console.WriteLine($"Is Valid BST: {validator.IsValidBst(validBst)}");
        Console.WriteLine($"In-Order: [{string.Join(",", traversal.InorderTraversal(validBst))}]");

        // Invalid BST
        var invalidBst = new PracticeGround.Tree.TreeNode(5, 
            new PracticeGround.Tree.TreeNode(4, null, new PracticeGround.Tree.TreeNode(6)), 
            new PracticeGround.Tree.TreeNode(7));
        
        Console.WriteLine("\n=== Invalid BST ===");
        Console.WriteLine($"Tree: [4,6,5,7] (6 in left subtree of 5)");
        Console.WriteLine($"Is Valid BST: {validator.IsValidBst(invalidBst)}");
        Console.WriteLine($"In-Order: [{string.Join(",", traversal.InorderTraversal(invalidBst))}]");
    }
}