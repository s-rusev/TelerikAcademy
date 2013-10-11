using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TreeStructure
{
    public class Tree
    {
        public Dictionary<int, Node> valueNodePairs;

        public Tree() 
        {
            valueNodePairs = new Dictionary<int, Node>();
        }

        public void SubTreeWithSum(Node root, List<Node> listOfSubTrees, int targetSum)
        {
            foreach (var item in root.GetChildren)
            {
                if (targetSum == GetSubTreeSum(item, item.Value))
                {
                    listOfSubTrees.Add(item);
                }

                SubTreeWithSum(item, listOfSubTrees, targetSum);
            }
        }

        public int GetSubTreeSum(Node subRoot, int sum)
        {
            foreach (var node in subRoot.GetChildren)
            {
                sum += GetSubTreeSum(node, node.Value);
            }

            return sum;
        }

        public void PrintTree(Node node)
        {
            foreach (var item in node.GetChildren)
            {
                Console.Write("{0} ", item.Value);
                PrintTree(item);
            }
        }

        public void PathsWithSum(Node root, List<List<Node>> listOfPaths, List<Node> pathSoFar, int currentSum, int targetSum)
        {
            if (currentSum == targetSum && CheckCurrentPathSum(pathSoFar, targetSum))
            {
                Node[] nodePath = new Node[pathSoFar.Count];
                pathSoFar.CopyTo(nodePath);
                listOfPaths.Add(new List<Node>(nodePath));
                pathSoFar.RemoveRange(1, pathSoFar.Count - 1);
            }

            foreach (var item in root.GetChildren)
            {
                pathSoFar.Add(item);
                PathsWithSum(item, listOfPaths, pathSoFar, currentSum + item.Value, targetSum);
                if (pathSoFar.Count > 1)
                {
                    pathSoFar.RemoveAt(pathSoFar.Count - 1);
                }
            }

        }

        private bool CheckCurrentPathSum(List<Node> path, int targetSum)
        {
            bool targetSumFound = false;
            int currentSum = 0;
            foreach (var item in path)
            {
                currentSum += item.Value;
            }

            if (currentSum == targetSum)
            {
                targetSumFound = true;
            }

            return targetSumFound;
        }

        public List<Node> LongestPath(Node root, ref int steps, ref int maxSteps)
        {
            List<Node> path = new List<Node>();
            steps++;
            if (maxSteps < steps)
            {
                maxSteps = steps;
                path.Add(root);
            }

            foreach (var item in root.GetChildren)
            {
                path.AddRange(LongestPath(item, ref steps, ref maxSteps));
            }
            steps--;

            return path;
        }

        public List<Node> FindLeafNodes(Node root)
        {
            List<Node> leafNodes = new List<Node>();
            List<Node> children = root.GetChildren;
            if (children.Count == 0)
            {
                leafNodes.Add(root);
            }

            foreach (var child in children)
            {
                leafNodes.AddRange(FindLeafNodes(child));
            }

            return leafNodes;
        }

        public List<Node> FindMiddleNodes(Node root)
        {
            List<Node> middleNodes = new List<Node>();
            List<Node> children = root.GetChildren;
            if (children.Count > 0 && root.HasParent == true)
            {
                middleNodes.Add(root);
            }

            foreach (var item in children)
            {
                middleNodes.AddRange(FindMiddleNodes(item));
            }

            return middleNodes;
        }

        public Node FindRoot()
        {
            foreach (var pair in valueNodePairs)
            {
                if (!pair.Value.HasParent)
                {
                    return pair.Value;
                }
            }

            throw new ArgumentException("No root in built tree.");
        }

        public void ParseTree()
        {
            string inputPairs = Console.ReadLine();
            int pairs = int.Parse(inputPairs);

            for (int i = 0; i < pairs - 1; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                int parentNodeValue = int.Parse(tokens[0]);
                int childNodeValue = int.Parse(tokens[1]);

                //2->3
                //3->4
                // ?4
                if (valueNodePairs.ContainsKey(parentNodeValue))
                {
                    Node node = valueNodePairs[parentNodeValue];
                    Node secondNode;

                    if (valueNodePairs.ContainsKey(childNodeValue))
                    {
                        //child already exists ->get the node with that value
                        secondNode = valueNodePairs[childNodeValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        //child doesn't exist -> create it and add it
                        secondNode = new Node(childNodeValue);
                        valueNodePairs.Add(childNodeValue, secondNode);
                    }

                    node.AddChild(secondNode);
                }
                else if (!valueNodePairs.ContainsKey(parentNodeValue))
                {
                    Node secondNode;
                    if (valueNodePairs.ContainsKey(childNodeValue))
                    {
                        //child exists and parent doesn't -> add the parent and 
                        //set the child parent property to true
                        secondNode = valueNodePairs[childNodeValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        //add the child 
                        secondNode = new Node(childNodeValue);
                        valueNodePairs.Add(childNodeValue, secondNode);
                    }

                    Node firstNode = new Node(parentNodeValue, secondNode);
                    valueNodePairs.Add(parentNodeValue, firstNode);
                }
            }
        }
    }
}
