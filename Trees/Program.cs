using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    

    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node left { get; set; }
            public Node right{ get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        static bool isUniValTree(Node node)
        {
            if (node == null)
                return true;

            var isUniValLeft = isUniValTree(node.left);
            var isUniValRight = isUniValTree(node.right);

            if (isUniValLeft && isUniValRight &&
                (node.left == null || node.left.Value == node.Value) &&
                (node.right == null || node.right.Value == node.Value))
            {
                numofUniValTrees++;
                return true;
            }

            return false;
        }

        public static int CountUnivalSubtrees(Node root)
        {
            if (root == null) return 0;

            var isUnival = (root.left == null || root.left.Value == root.Value) &&
                           (root.right == null || root.right.Value == root.Value);


            return CountUnivalSubtrees(root.left) +
                   CountUnivalSubtrees(root.right) +
                   Convert.ToInt32(isUnival);

        }

        static bool IsValidBST(Node node)
        {
            var currentNode = node;
            Node prevVisitedNode = null;
            while (stack.Count > 0 || currentNode!=null)
            {
                var tempNode = currentNode;
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.left;
                }

                var poppedNode = stack.Pop();
                if (poppedNode.Value <= prevVisitedNode.Value)
                    return false;

                prevVisitedNode = poppedNode;
                currentNode = poppedNode.right;

            }

            return true;

        }

        private static int numofUniValTrees;

        static void InOrder(Node node)
        {
            if (node == null)
                return;

            InOrder(node.left);
            Console.WriteLine($"Value is {node.Value}");
            InOrder(node.right);
        }

        static void InOrderWithoutRecursion()
        {
            var node = root;
            TraverseLeftOnlyAndPushOnStack(node);
            Node currentStackELement = null;
            do
            {
                currentStackELement = stack.Peek();
                stack.Pop();
                Console.WriteLine($"{currentStackELement.Value}");
                if (currentStackELement.right != null)
                    TraverseLeftOnlyAndPushOnStack(currentStackELement.right);

            } while (stack.Count > 0 || currentStackELement.right != null);
        }

        static void InOrderWithoutRecursion1()
        {
            var node = root;
            while (node != null || stack.Any())
            {
                TraverseLeftOnlyAndPushOnStack(node);
                node = stack.Peek();
                stack.Pop();
                Console.WriteLine($"{node.Value}");
                node = node.right;
            }
        }

        static bool HasPathSum(Node node, int SUM)
        {
            if (node == null)
                return false;
            var currentNode = node;
            var currentSum = 0;
            Node lastPoppedNode = null;
            while (stack.Any() || currentNode != null)
            {
                var tempNode = currentNode;
                while (tempNode!=null)
                {
                    stack.Push(tempNode);
                    currentSum += tempNode.Value;
                    tempNode = tempNode.left;
                }

                if(currentSum == SUM && isLeafNode(stack.Peek()))
                    break;

                if (stack.Peek().right == null || stack.Peek().right == lastPoppedNode)
                {
                    lastPoppedNode = stack.Pop();
                    currentSum -= lastPoppedNode.Value;
                    currentNode = null;
                }
                else
                {
                    currentNode = stack.Peek().right;
                }

            }

            return !isEmptyTree() && lastPoppedNode != root && currentSum == SUM;

            bool isEmptyTree()
            {
                return root == null;
            }

            bool isLeafNode(Node node1)
            {
                return node1 == null || (node1.right == null && node1.left == null);
            }

        }

        static bool HasPathSumWithRecursion(Node node, int SUM)
        {
            if (root == null)
                return false;

            if (isLeafNode(node))
            {
                return node.Value == SUM;
            }

            return HasPathSumWithRecursion(node.left, SUM - node.Value) ||
                   HasPathSumWithRecursion(node.right, SUM - node.Value);

            bool isLeafNode(Node node1)
            {
                return node1 == null || (node1.right == null && node1.left == null);
            }
        }

        static void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine($"Value is {node.Value}");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        static void PreOrderWithoutRecursion()
        {
            var node = root;
            while (node != null || stack.Any())
            {
                
                //TraverseLeftOnlyAndPushOnStack(node);
                var currentNode = node;
                while (currentNode != null)
                {
                    Console.WriteLine($"{currentNode.Value}");
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                node = stack.Peek();
                stack.Pop();
                
                node = node.right;
            }
        }

        static void PostOrder(Node node)
        {
            if (node == null)
                return;

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine($"Value is {node.Value}");
        }

        static void PostOrderWithoutRecursion()
        {
            var currentNode = root;
            Node lastNode = null;
            while (true)
            {
                while (currentNode!=null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Peek();

                if (currentNode != null && currentNode.right != null)
                    currentNode = currentNode.right;
                else
                {
                    Node prevNode = null;
                    while (true)
                    {
                        lastNode = stack.Peek();
                        if (lastNode.right == null || lastNode.right == prevNode)
                        {
                            Console.WriteLine($"Value is {lastNode.Value}");
                            stack.Pop();
                            prevNode = lastNode;
                            if(!stack.Any())
                                break;
                        }
                        else
                        {
                            currentNode = lastNode.right;
                            break;
                        }
                    }

                    if(prevNode == root)
                        break;

                    
                }

            }

            
        }

        public static IList<int> PostorderTraversal(Node root)
        {
            var output = new List<int>();
            var currentNode = root;
            var stack = new Stack<Node>();
            Node prevPoppedNode = null;
            while (stack.Count > 0 || currentNode != null)
            {
                var tempNode = currentNode;
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.left;
                }

                var lastNode = stack.Peek();
                if (lastNode.right == null || lastNode.right == prevPoppedNode)
                {
                    stack.Pop();
                    output.Add(lastNode.Value);
                    prevPoppedNode = lastNode;
                }

                if (lastNode == root && stack.Count == 0)
                    break;

                if(stack.Peek() == lastNode)
                 currentNode = lastNode.right;
                else
                {
                    currentNode = null;
                }

            }

            return output;
        }



        static Node TraverseLeftOnlyAndPushOnStack(Node parentNode)
        {
            if (parentNode == null)
                return null;

            Node currentNode = parentNode;
            Node previousNode = null;
            while (currentNode != null)
            {
                stack.Push(currentNode);
                previousNode = currentNode;
                currentNode = currentNode.left;
            }

            return previousNode;
        }

        static void DifferentOrder(Node node)
        {
            if(node == null) return;

            var queue = new Queue<Node>();
            queue.Enqueue(node);
            
            while (queue.Count>0)
            {
                var temp = queue.Peek();
                queue.Dequeue();

                Console.WriteLine($"Value is {temp.Value}");
                if (temp.left != null)
                    queue.Enqueue(temp.left);

                if (temp.right != null)
                    queue.Enqueue(temp.right);
            }
            
        }

        //Do a levelorder/BFS traversal and if a node has a left node available then insert the newnode or if the
        //node has a rightnode available then insert a newnode
        static void Insert(int value)
        {
            var newNode = new Node(value);
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(currentNode);
            while (queue.Any())
            {
                var temp = queue.Peek();
                queue.Dequeue();
                if (temp.left == null)
                    temp.left = newNode;
                else if (temp.right == null)
                {
                    temp.right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(temp.left);
                    queue.Enqueue(temp.right);
                }

                //Console.WriteLine($"Queue size {queue.Count}");
            }
        }

        static IList<IList<int>> LevelOrderTraversal()
        {
            var output = new List<IList<int>>();
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            Node firstNextLevelNode = root;
            while (queue.Any())
            {
                var firstNode = queue.Dequeue();
                IList<int> currentList = null;
                if (firstNode == firstNextLevelNode)
                {
                    currentList = new List<int>();
                    output.Add(currentList);
                }
                else
                {
                    currentList = output[output.Count - 1];
                }

                currentList.Add(firstNode.Value);
                

                if (firstNode.left != null && firstNode.right != null)
                {
                    queue.Enqueue(firstNode.left);
                    queue.Enqueue(firstNode.right);
                    if(firstNextLevelNode == null || firstNode == firstNextLevelNode)
                    firstNextLevelNode = firstNode.left;
                }
                else if (firstNode.left != null)
                {
                    queue.Enqueue(firstNode.left);
                    if (firstNextLevelNode == null || firstNode == firstNextLevelNode)
                        firstNextLevelNode = firstNode.left;
                }
                else if (firstNode.right != null)
                {
                    queue.Enqueue(firstNode.right);
                    if (firstNextLevelNode == null || firstNode == firstNextLevelNode)
                        firstNextLevelNode = firstNode.right;
                }
                else
                {
                    if (firstNextLevelNode == null || firstNode == firstNextLevelNode)
                        firstNextLevelNode = null;
                }

                

            }

            return output;
        }

        static IList<IList<int>> LevelOrderTraversal1()
        {
            var output = new List<IList<int>>();
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var lst = new List<int>();
                output.Add(lst);
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var firstNodeInQueue = queue.Dequeue();
                    lst.Add(firstNodeInQueue.Value);
                    if (firstNodeInQueue.left != null)
                        queue.Enqueue(firstNodeInQueue.left);
                    if (firstNodeInQueue.right != null)
                        queue.Enqueue(firstNodeInQueue.right);

                }


            }

            return output;
        }

        static void Delete(int key)
        {
            var currentNode = root;
            Node nodeToBeDeleted = null;
            Node poppedNode = null;
            while (stack.Any() || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    if (currentNode.Value == key)
                        nodeToBeDeleted = currentNode;
                    currentNode = currentNode.left;
                }

                poppedNode = stack.Pop();
                currentNode = poppedNode.right;
                
            }

            var bottomMostAndRightMostNode = poppedNode;
            nodeToBeDeleted.Value = poppedNode.Value;
            DeleteBottomMostAndRightMostNode(bottomMostAndRightMostNode);

        }

        static void DeleteBottomMostAndRightMostNode(Node bottomMostAndRightMostNode)
        {
            var currentNode = root;
            Node poppedNode = null;
            while (stack.Any() || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                poppedNode = stack.Pop();
                if (poppedNode.left == bottomMostAndRightMostNode)
                {
                    poppedNode.left = null;
                    break;
                }
                else if(poppedNode.right == bottomMostAndRightMostNode)
                {
                    poppedNode.right = null;
                    break;
                }
                else
                {
                    currentNode = poppedNode.right;
                }

            }
        }

        static bool IsSymmetric(Node leftNode, Node rightNode)
        {
            if (leftNode == null && rightNode == null)
                return true;
            else if (leftNode == null || rightNode == null)
                return false;
            return leftNode.Value == rightNode.Value &&
                   IsSymmetric(leftNode.left, rightNode.right) &&
                   IsSymmetric(leftNode.right, rightNode.left);

        }

        static bool IsSymmetric(Node node)
        {
            if (node == null)
                return true;

            return IsSymmetric(node.left, node.right);
        }

        static int FindMaximumDepthofBinaryTree(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(FindMaximumDepthofBinaryTree(node.left), FindMaximumDepthofBinaryTree(node.right)) + 1;
        }

        /*Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.*/
        static List<Node> FindPathSum(Node node, int SUM)
        {
            if (node.Value > SUM)
                return new List<Node>();

            stack.Push(node);
            Node lastPoppedNode = null;
            var currentSum = node.Value;
            while(stack.Any() || currentSum != SUM)
            {
                var peekNode = stack.Peek();
                if  (
                      lastPoppedNode == null || 
                      (peekNode.left != null && peekNode.left != lastPoppedNode && peekNode.right != null && peekNode.right != lastPoppedNode)
                    )
                {
                    if(peekNode.left.Value + currentSum <= SUM)
                    {
                        stack.Push(peekNode.left);
                        currentSum += peekNode.left.Value;
                    }
                    
                }
                else if(peekNode.left == lastPoppedNode)
                {
                    if (peekNode.right.Value + currentSum <= SUM)
                    {
                        stack.Push(peekNode.right);
                        currentSum += peekNode.right.Value;
                    }
                    else
                    {
                        lastPoppedNode = stack.Pop();
                        currentSum -= lastPoppedNode.Value;
                    }
                }
                else if (peekNode.right == lastPoppedNode)
                {
                    lastPoppedNode = stack.Pop();
                    currentSum -= lastPoppedNode.Value;
                }
            }

            var path = new List<Node>(stack.Count);
            var i = stack.Count - 1;
            while(stack.Any())
            {
                path[i] = stack.Pop();
                i--;
            }

            return path;
        }

        static Node root;

        static Stack<Node> stack = new Stack<Node>();

        static List<List<int?>> ConvertArrayToLevelLists(int?[] array)
        {
            Node root = null;
            if (array.Length == 0)
                return new List<List<int?>>();

            var levelLists = new List<List<int?>>();
            var previousList = new List<int?>() {array[0]};
            levelLists.Add(previousList);
            var lastIndex = 0;

            while (lastIndex < array.Length - 1)
            {
                var newList = new List<int?>();
                var count = previousList.Count(p => p.HasValue)*2;
                if (count + lastIndex + 1 > array.Length - 1)
                    count = array.Length - lastIndex - 1;
                newList.AddRange(array.ToList().GetRange(lastIndex + 1, count));
                lastIndex = lastIndex + count;
                previousList = newList;
                levelLists.Add(newList);
            }

            return levelLists;
        }

        static Node ConvertArrayToTree(int?[] array)
        {
            var levelLists = ConvertArrayToLevelLists(array);
            if (levelLists == null || !levelLists.Any())
                return null;

            root = new Node(levelLists[0][0].Value);
            var lastNodeList = new List<Node>() {root};
            for (var i = 1; i < levelLists.Count; i++)
            {
                //var listWithOutNull = levelLists[i - 1].Where(l => l.HasValue).ToList();
                var nextLevelList = levelLists[i];
                var cnt = lastNodeList.Count;
                var newNodeList = new List<Node>();
                for (int j = 0; j < cnt; j++)
                {

                    var node = lastNodeList[j];
                    if (2*j <= nextLevelList.Count - 1 && nextLevelList[2 * j].HasValue)
                    {
                        node.left = new Node(nextLevelList[2 * j].Value);
                        newNodeList.Add(node.left);
                    }

                    if ((2 * j + 1) <= nextLevelList.Count - 1 && nextLevelList[2 * j + 1].HasValue)
                    {
                        node.right = new Node(nextLevelList[2 * j + 1].Value);
                        newNodeList.Add(node.right);
                    }


                    

                }

                lastNodeList = newNodeList;
            }

            return root;
        }

        public static Node deserialize(string data)
        {
            
            var substr = data.Substring(1, data.Length - 2);
            if (string.IsNullOrEmpty(substr)) return null;
            var ints = substr.Split(',').Select(s => (s == "null")? (int?)null : Convert.ToInt32(s)).ToArray();
            return ConvertArrayToTree(ints);
        }

        public static Node BuildTree1(int[] preOrder, int[] inOrder)
        {
            return BuildTree1(preOrder.ToList(), inOrder.ToList());
        }

        public static Node BuildTree1(List<int> preOrder, List<int> inOrder)
        {
            if (preOrder.Count == 0)
                return null;

            var rootNode = new Node(preOrder[0]);
            var leftRightSubArr = GetInOrderSubArray(rootNode.Value, inOrder);
            var preOrderLeftSubArr = GetPreOrderSubArray(leftRightSubArr.LeftSubArray, preOrder);
            var preOrderRightSubArr = GetPreOrderSubArray(leftRightSubArr.RightSubArray, preOrder);
            rootNode.left = BuildTree1(preOrderLeftSubArr, leftRightSubArr.LeftSubArray);
            rootNode.right = BuildTree1(preOrderRightSubArr, leftRightSubArr.RightSubArray);

            return rootNode;

            LeftRightSubArrays GetInOrderSubArray(int val, List<int> arr)
            {
                var leftRightSubArrays = new LeftRightSubArrays()
                {
                    LeftSubArray = new List<int>(),
                    RightSubArray = new List<int>()
                };
                var isLeft = true;
                for (var i = 0; i < arr.Count; i++)
                {
                    if(arr[i] != val && isLeft)
                        leftRightSubArrays.LeftSubArray.Add(arr[i]);
                    else if(arr[i] == val)
                    {
                        isLeft = false;
                    }
                    else
                    {
                        leftRightSubArrays.RightSubArray.Add(arr[i]);
                    }
                }

                return leftRightSubArrays;
            }

            List<int> GetPreOrderSubArray(List<int> inOrderSubArr, List<int> arr)
            {
                var hasSet = new HashSet<int>();
                var subList = new List<int>();
                inOrderSubArr.ToList().ForEach(i => hasSet.Add(i));
                arr.ForEach(p =>
                {
                    if (hasSet.Contains(p))
                        subList.Add(p);
                });

                return subList;
            }

        }

        

        private class LeftRightSubArrays
        {
            public List<int> LeftSubArray { get; set; }
            public List<int> RightSubArray { get; set; }
        }

        public static Node BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTree(inorder.ToList(), postorder.ToList());
        }

        public static Node BuildTree(List<int> inorder, List<int> postorder)
        {
            if (inorder.Count == 0)
                return null;

            var rootNode = new Node(postorder[postorder.Count - 1]);
            var leftRightInOrderSubArrays = GetInOrderSubArrays(rootNode.Value);
            var leftRightPostOrderSubArrays = GetPostOrderSubArrays(leftRightInOrderSubArrays);
            rootNode.left = BuildTree(leftRightInOrderSubArrays.LeftSubArray, leftRightPostOrderSubArrays.LeftSubArray);
            rootNode.right = BuildTree(leftRightInOrderSubArrays.RightSubArray, leftRightPostOrderSubArrays.RightSubArray);

            return rootNode;

            LeftRightSubArrays GetInOrderSubArrays(int val)
            {
                var leftList = new List<int>();
                var rightList = new List<int>();
                var elemFound = false;
                for (int i = 0; i < inorder.Count; i++)
                {
                    if (inorder[i] == val)
                        elemFound = true;
                    if(!elemFound)
                        leftList.Add(inorder[i]);
                    else if(inorder[i] != val)
                        rightList.Add(inorder[i]);
                }

                return new LeftRightSubArrays()
                {
                    LeftSubArray = leftList,
                    RightSubArray = rightList
                };

            }

            LeftRightSubArrays GetPostOrderSubArrays(LeftRightSubArrays inOrderSubArrays)
            {
                return new LeftRightSubArrays()
                {
                    LeftSubArray = GetPostOrderSubArray(inOrderSubArrays.LeftSubArray),
                    RightSubArray = GetPostOrderSubArray(inOrderSubArrays.RightSubArray)
                };
            }

            List<int> GetPostOrderSubArray(List<int> inOrderList)
            {
                var hasSet = new HashSet<int>();
                var subList = new List<int>();
                inOrderList.ForEach(i => hasSet.Add(i));
                postorder.ForEach(p =>
                {
                    if(hasSet.Contains(p))
                        subList.Add(p);
                });

                return subList;
            }

        }

        public static Node BuildTree3(int[] inOrder, int[] preOrder)
        {
            var inOrderDictionary = new Dictionary<int, int>();
            int idx = 0;
            foreach (var i in inOrder)
                inOrderDictionary.Add(i, idx++);

            return Helper3(0, inOrder.Length, preOrder, inOrderDictionary);
        }

        public static int preOrderPosition = 0;

        public static Node Helper3(int start, int end, int[] preOrder, Dictionary<int, int> inOrderDictionary)
        {
            if (start == end)
                return null;
            var rootNode = new Node(preOrder[preOrderPosition]);

            var rootPosition = inOrderDictionary[rootNode.Value];
            preOrderPosition++;
            rootNode.left = Helper3(start, rootPosition, preOrder, inOrderDictionary);
            rootNode.right = Helper3(rootPosition + 1, end, preOrder, inOrderDictionary);

            return rootNode;
        }

        public static int postOrderPosition = 4;
        public static Node BuildTree4(int[] inorder, int[] postorder)
        {
            var inOrderDictionary = new Dictionary<int, int>();
            int idx = 0;
            foreach (var i in inorder)
                inOrderDictionary.Add(i, idx++);

            return Helper4(0, postorder.Length, postorder, inOrderDictionary);
        }

        public static Node Helper4(int start, int end, int[] postOrder, Dictionary<int, int> inOrderDictionary)
        {
            if (start == end)
                return null;

            var rootNode = new Node(postOrder[postOrderPosition]);
            var rootPosition = inOrderDictionary[rootNode.Value];
            postOrderPosition--;
            
            rootNode.right = Helper4(rootPosition + 1, end, postOrder, inOrderDictionary);
            rootNode.left = Helper4(start, rootPosition, postOrder, inOrderDictionary);

            return rootNode;
        }

        public static bool IsSubTree(Node root, Node subTreeToCompare)
        {
            if (AreTreesEqual(root, subTreeToCompare))
                return true;
            else if (root != null && IsSubTree(root.left, subTreeToCompare))
                return true;
            else if (root != null && IsSubTree(root.right, subTreeToCompare))
                return true;

            return false;
        }

        public static bool AreTreesEqual(Node subTree, Node subTreeToCompare)
        {
            if (
                (subTree != null && subTreeToCompare != null && subTree.Value != subTreeToCompare.Value) ||
                (subTree == null && subTreeToCompare != null) ||
                (subTree != null && subTreeToCompare == null)

            )
                return false;
            else if (subTree == null && subTreeToCompare == null)
                return true;

            return AreTreesEqual(subTree.left, subTreeToCompare.left) &&
                   AreTreesEqual(subTree.right, subTreeToCompare.right);

        }

        public static Node LowestCommonAncestor(Node root, Node p, Node q)
        {
            var currentNode = root;
            var firstNodeFound = false;
            Node prevNode = null;
            var hashSet = new HashSet<Node>();
            while (stack.Any() || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    if (!firstNodeFound)
                    {
                        hashSet.Add(currentNode);
                        if (IsOneofTheTwo())
                            firstNodeFound = true;
                    }
                    else if (IsOneofTheTwo())
                    {
                        return FindLca();
                    }

                    currentNode = currentNode.left;
                }

                var stackPeekRight = stack.Peek().right;
                if (stackPeekRight == null || stack.Peek().right == prevNode)
                {
                    prevNode = stack.Pop();
                    if (!firstNodeFound)
                    {
                        hashSet.Remove(prevNode);
                    }
                }
                else
                {
                    currentNode = stack.Peek().right;
                }
            }

            bool IsOneofTheTwo()
            {
                return currentNode == p || currentNode == q;
            }

            Node FindLca()
            {
                Node poppedNode = null;
                while (!hashSet.Contains(poppedNode = stack.Pop())) ;
                return poppedNode;

            }

            return null;
        }

        //public static string serialize(Node root)
        //{
        //    var queue = new Queue<Node>();
        //    int? firstNullIndexAtEnd = null;
        //    queue.Enqueue(root);
        //    var str = string.Empty;
        //    while(queue.Any())
        //    {
        //        var node = queue.Dequeue();
        //        if (str != string.Empty)
        //            str += ", ";
        //        if (node == null)
        //            str += "null";
        //        else
        //        {
        //            str += node.Value;
        //            queue.Enqueue(node.left);
        //            queue.Enqueue(node.right);
        //        }
        //    }

        //    return str;
        //}

        public static string serialize(Node root)
        {
            var queue = new Queue<Node>();
            int? firstNullIndexAtEnd = null;
            queue.Enqueue(root);
            var nodes = new List<Node>();
            while (queue.Any())
            {
                var node = queue.Dequeue();
                nodes.Add(node);
                if (node == null && !firstNullIndexAtEnd.HasValue)
                {
                    firstNullIndexAtEnd = nodes.Count - 1;
                }
                else if(node != null)
                    firstNullIndexAtEnd = null;

                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }

            return PrintStr();

            string PrintStr()
            {
                var str = string.Empty;
                var lastIndex = (firstNullIndexAtEnd.HasValue) ? firstNullIndexAtEnd.Value : nodes.Count;
                for(var i = 0; i< lastIndex; i++)
                {
                    if (i > 0)
                        str += ",";
                    if (nodes[i] == null)
                        str += "null";
                    else
                        str += nodes[i].Value;
                }

                return "[" + str + "]";
            }

            
        }

        static void Main(string[] args)
        {
            //example 1
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.left = new Node(50);
            //root.left.right = new Node(12);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);

            //example 2
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.right = new Node(6);
            //root.left.left.right.left = new Node(18);
            //root.left.left.right.right = new Node(19);
            //root.left.left.right.left.right = new Node(25);
            //root.left.right = new Node(12);
            //root.left.right.left = new Node(13);
            //root.left.right.right = new Node(14);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);
            //var isSumPresent = HasPathSum(root, 47);

            //root = new Node(1);
            //root.left = new Node(2);
            //var isSumPresent = HasPathSum(root, 1);

            //root = ConvertArrayToTree(new int?[]
            //{
            //    7, 82, 82, -79, 98, 98, -79, -79, null, -28, -24, -28, -24, null, -79, null, 97, 65, -4, null, 3, -4,
            //    65, 3, null, 97
            //});

            //var numberofUniValTrees = CountUnivalSubtrees(root);
            //var d = FindMaximumDepthofBinaryTree(root);

            //Console.ReadLine();
            //LevelOrderTraversal1();
            //PreOrder(root);
            //PreOrderWithoutRecursion();
            //PostOrder(root);
            //Console.WriteLine("Without Recursion");
            //PostOrderWithoutRecursion();
            //Console.WriteLine("Before Insert Inorder");
            //InOrder(root);
            //InOrderWithoutRecursion();
            //InOrderWithoutRecursion1();
            //DifferentOrder(root);
            //Insert(55);
            //Console.WriteLine("After Insert Inorder");
            //InOrder1(root);
            //var maxdepth = FindMaximumDepthofBinaryTree(root);


            //example 3:left sides tree only
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.left = new Node(50);
            //PostOrder(root);
            //PostOrderWithoutRecursion();
            //InOrder(root);
            //InOrderWithoutRecursion();
            //DifferentOrder(root);

            //example 4:right side tree only
            //root = new Node(10);
            //root.right = new Node(11);
            //root.right.right = new Node(7);
            //root.right.right.right = new Node(50);
            //PostOrder(root);
            //PostOrderWithoutRecursion();
            //InOrder(root);
            //InOrderWithoutRecursion();
            //DifferentOrder(root);

            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.right = new Node(12);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);
            //InOrder(root);

            //int key = 11;
            //Delete(key);
            //InOrder(root);

            //Only for unival tree test
            //root = new Node(44);
            //root.left = new Node(32);
            //root.left.left = new Node(32);
            //root.left.left.left = new Node(24);
            //root.left.left.left.left = new Node(24);
            //root.left.left.left.right = new Node(24);

            //root.left.left.right = new Node(26);
            //root.left.left.right.left = new Node(26);
            //root.left.left.right.right = new Node(26);

            //root.right = new Node(55);
            //root.right.left = new Node(48);
            //root.right.left.left = new Node(48);
            //root.right.left.right = new Node(48);

            //root.right.left.left.left = new Node(48);
            //root.right.left.left.right = new Node(48);

            //root.right.left.right.left = new Node(48);
            //root.right.left.right.right = new Node(48);

            //root.right.right = new Node(51);
            //root.right.right.left = new Node(51);
            //root.right.right.right = new Node(51);
            //var isunival = isUniValTree(root);
            //Console.WriteLine($"Number of Unival Trees {numofUniValTrees}");

            //root = new Node(3);
            //root.left = new Node(1);
            //root.left.right = new Node(2);
            //var a = PostorderTraversal(root);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(2);

            //root.left.left = new Node(3);
            //root.right.right =  new Node(3);

            //root.left.right = new Node(4);
            //root.right.left = new Node(4);

            //root.left.left.left = new Node(5);
            //root.right.right.right = new Node(5);

            //root.left.left.right = new Node(6);
            //root.right.right.left = new Node(6);

            //root.left.right.left = new Node(7);
            //root.right.left.right = new Node(7);

            //root.left.right.right = new Node(8);
            //root.right.left.left = new Node(8);
            //var isSymmetric = IsSymmetric(root);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(2);

            //root.left.left = new Node(3);
            //root.right.right = new Node(3);

            //root.left.right = new Node(20);
            //root.right.left = new Node(4);

            //root.left.left.left = new Node(5);
            //root.right.right.right = new Node(5);

            //root.left.left.right = new Node(6);
            //root.right.right.left = new Node(6);

            //root.left.right.left = new Node(7);
            //root.right.left.right = new Node(7);

            //root.left.right.right = new Node(8);
            //root.right.left.left = new Node(8);

            //isSymmetric = IsSymmetric(root);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(3);
            //var isSymmetric = IsSymmetric(root);

            //Construct Tree for inorder and postorder
            //var inorder = new int[] { 9, 3, 15, 20, 7 };
            //var postorder = new[] { 9, 15, 7, 20, 3 };
            //var inorder = new int[] {9, 3};
            //var postorder = new int[] {9, 3};
            //root = BuildTree(inorder, postorder);
            //root = BuildTree4(inorder, postorder);

            //Construct Tree for inorder and preorder
            //var inorder = new int[] { 9, 3, 15, 20, 7 };
            //var preorder = new[] {3, 9, 20, 15, 7 };
            //root = BuildTree1(preorder, inorder);

            //root = BuildTree3(inorder, preorder);

            //root = new Node(3);
            //root.left = new Node(4);
            //root.right = new Node(5);

            //root.left.left = new Node(1);
            //root.left.right = new Node(2);
            //root.left.left.left = new Node(8);

            //root = new Node(3);
            //root.left = new Node(8);
            //root.right = new Node(9);

            //root.left.left = new Node(4);
            //root.left.left.left = new Node(1);
            //root.left.left.right = new Node(3);

            //root.right.right = new Node(4);
            //root.right.right.left = new Node(1);
            //root.right.right.right = new Node(2);

            //var subtreeToCompareNode = new Node(4);
            //subtreeToCompareNode.left = new Node(1);
            //subtreeToCompareNode.right = new Node(2);
            //var areEqual = IsSubTree(root, subtreeToCompareNode);

            //var list = new List<int?>()
            //{
            //    3,
            //    5,
            //    1,
            //    6,
            //    2,
            //    0,
            //    8,
            //    11,
            //    15,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    100,
            //    35
            //};
            //root = ConvertArrayToTree(list.ToArray());
            //var lcaNode = LowestCommonAncestor(root, root.right.left, root.right.right);

            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.right.left = new Node(4);
            root.right.right = new Node(5);
            var str = serialize(root);
            var node = deserialize("[1,2]");
            Console.ReadLine();
        }
    }
}
