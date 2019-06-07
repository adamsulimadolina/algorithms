using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace BinaryTree6
{
    class Node
    {
        private int value;
        public Node left;
        public Node right;
        public void setValue(int x)
        {
            value = x;
        }
        public int getValue()
        {
            return value;
        }
    }
    class BinaryTree
    {
        private Node root;
        public void setRoot(Node n)
        {
            root = n;
        }
        public Node getRoot()
        {
            return root;
        }
        public Node insert(Node root, int value)
        {
            if(root==null)
            {
                root = new Node();
                root.setValue(value);
            }
            else if (value < root.getValue())
            {
                root.left = insert(root.left, value);
            }
            else if(value > root.getValue())
            {
                root.right = insert(root.right, value);
            }
            return root;
        }
        public void Travel(Node root, StreamWriter file)
        {
            if (root == null)
            {
                return;
            }
            file.Write("{0}, ", root.getValue());
            Travel(root.left, file);
            Travel(root.right, file);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            BinaryTree bnt = new BinaryTree();
            StreamReader read = new StreamReader("In0206.txt");
            StreamWriter write = new StreamWriter("Out0206.txt");
            int[] tab = new int[1];
            string line;
            while ((line = read.ReadLine()) != null)
            {
                string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                tab = new int[tmp.Length];
                for (int j = 0; j < tmp.Length; j++)
                {
                    tab[j] = int.Parse(tmp[j]);
                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                root = bnt.insert(root, tab[i]);
            }
            bnt.Travel(root, write);
            write.Close();
            read.Close();
            
        }
    }
}
