using System;
using System.Data;

namespace Lab_05
{
    class Node
    {
        public string key;
        public double value;
        public Node left, right;

        public Node(string item)
        {
            key = item;
            left = right = null;
        }
    }

    class BinaryTree
    {
        public Node root;
        public int left, right;

        public BinaryTree() { root = null; }

        public void printInorder(Node node)
        {
            if (node == null)
                return;
            printInorder(node.left);
            Console.Write(node.key + " ");
            printInorder(node.right);
        }

        public void printPreorder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.key + " ");
            printPreorder(node.left);
            printPreorder(node.right);
        }

        public void printPostorder(Node node)
        {
            if (node == null)
                return;
            printPostorder(node.left);
            printPostorder(node.right);
            Console.Write(node.key + " ");
        }

        public void calcPostorder(Node node)
        {
            if (node == null)
                return;
            double value = 0;
            calcPostorder(node.left);
            calcPostorder(node.right);
            if (double.TryParse(node.key, out value))
                node.value = double.Parse(node.key);
            if (node.left != null && node.right != null)
            {
                node.value = Convert.ToDouble(new DataTable().Compute(node.left.value + node.key + node.right.value, ""));
                //Console.Write(node.value + " ");
            }
        }

        public void printPostorder() { printPostorder(root); }
        public void printInorder() { printInorder(root); }
        public void printPreorder() { printPreorder(root); }
        public void calcPostorder() { calcPostorder(root); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node("a");
            tree.root.left = new Node("b");
            tree.root.right = new Node("c");
            tree.root.left.left = new Node("d");
            tree.root.left.right = new Node("e");
            tree.root.right.right = new Node("f");

            Console.WriteLine("Обход дерева в прямом порядке ");
            tree.printPreorder();

            Console.WriteLine("\nОбход дерева в обратном порядке ");
            tree.printInorder();

            Console.WriteLine("\nОбход дерева в концевом порядке ");
            tree.printPostorder();

            BinaryTree tree1 = new BinaryTree();
            tree1.root = new Node("/");
            tree1.root.left = new Node("*");
            tree1.root.right = new Node("3");
            tree1.root.left.left = new Node("+");
            tree1.root.left.right = new Node("-");
            tree1.root.left.left.left = new Node("2");
            tree1.root.left.left.right = new Node("3");
            tree1.root.left.right.left = new Node("7");
            tree1.root.left.right.right = new Node("4");

            //Console.WriteLine("\n");
            //tree1.printPostorder();
            Console.WriteLine("\nОтвет ");
            tree1.calcPostorder();
            Console.WriteLine(tree1.root.value);

        }
    }
}
