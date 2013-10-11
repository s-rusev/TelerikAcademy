using System;
using System.Collections.Generic;
using System.Collections;

namespace _03.TreeStructure
{
    public class TreeStructureDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter number of tree pairs and after that all pairs parent-child:");
            Tree tree = new Tree();
            tree.ParseTree();

            Console.WriteLine("All nodes and their children: ");
            foreach (var pair in tree.valueNodePairs)
            {
                Console.Write("{0}: ", pair.Key);
                foreach (var child in pair.Value.GetChildren)
                {
                    Console.Write("{0} ", child.Value);
                }
                Console.WriteLine();
            }

            // root
            Node root = tree.FindRoot();
            Console.WriteLine("Root value: {0}", root.Value);

            // leafs
            Console.WriteLine("Leafs: ");
            List<Node> leafs = tree.FindLeafNodes(root);
            foreach (var item in leafs)
            {
                Console.WriteLine(item.Value);
            }

            // middle nodes
            Console.WriteLine("Middle nodes: ");
            IEnumerable<Node> middleNodes = tree.FindMiddleNodes(root);
            foreach (var item in middleNodes)
            {
                Console.WriteLine(item.Value);
            }

            // longest path
            int steps = -1;
            int maxSteps = 0;
            List<Node> path = new List<Node>(new Node[] { root });
            path.AddRange(tree.LongestPath(root, ref steps, ref maxSteps));

            Console.WriteLine("Longest path is: (with {0} steps)", maxSteps);
            foreach (var item in path)
            {
                Console.WriteLine(item.Value);
            }

            // all paths with sum targetSum
            Console.WriteLine("Enter target sum to find all paths with that sum:");
            string inputTargetSumPath = Console.ReadLine();
            int targetSum = int.Parse(inputTargetSumPath);

            List<List<Node>> listOfPaths = new List<List<Node>>();
            tree.PathsWithSum(root, listOfPaths, new List<Node>(new Node[] { root }), root.Value, targetSum);
            
            Console.WriteLine("Paths with sum of {0}:", targetSum);
            foreach (var foundPath in listOfPaths)
            {
                foreach (var node in foundPath)
                {
                    Console.Write("{0} ", node.Value);
                }
                Console.WriteLine();
            }

            // all subtrees with sum targetSum
            Console.WriteLine("Enter target sum to find all sub-trees with that sum:");
            string inputTargetSumSubTree = Console.ReadLine();
            int targetSumSubTree = int.Parse(inputTargetSumSubTree);

            List<Node> listOfSubTrees = new List<Node>();
            tree.SubTreeWithSum(root, listOfSubTrees, targetSumSubTree);

            Console.WriteLine("Sub trees with sum of {0}:", targetSumSubTree);
            foreach (var foundTree in listOfSubTrees)
            {
                Console.Write("{0} ", foundTree.Value);
                tree.PrintTree(foundTree);
                Console.WriteLine();
            }
        }
    }
}