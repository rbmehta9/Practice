using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class BinarySearchRecursion
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            var treeNode = SearchBST(root.left, val);
            if (root.val == val)
                return root;
            else if (treeNode?.val == val)
                return treeNode;
            else
                treeNode = SearchBST(root.right, val);

            return treeNode;
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        //public TreeNode SearchBST(TreeNode root, int val)
        //{
        //    if (root == null || root.val == val)
        //        return root;

        //    var treeNode = SearchBST(root.left, val);
        //    if (treeNode?.val != val)
        //        treeNode = SearchBST(root.right, val);
        //    return treeNode;
        //}
    }
}
