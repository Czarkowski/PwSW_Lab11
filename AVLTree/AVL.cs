using System;

namespace AVLTree
{
    public class AVL<T> where T : IComparable<T>
    {
        private class Node
        {
            public T data;
            public int factor;
            public Node left;
            public Node right;
            public Node(T data)
            {
                this.data = data;
            }
        }
        Node root;
        public AVL()
        {

        }
        public void Add(T data)
        {
            Node node = new Node(data);
            if (root == null)
            {
                root = node;
            }
            else
            {
                root = recursiveInsert(root, node);
            }
        }

        private Node recursiveInsert(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }
            else if(current.data.CompareTo(node.data)<0)
            {
                current.right = recursiveInsert(current.right, node);
                current = 
            }
            else
            {
                current.left = recursiveInsert(current.left, node);
                current =
            }
            return current;
        }
        private Node balanceTree(Node current)
        {
            int bFactor = balanceFactor(current);
            if (bFactor > 1)
            {
                if (balanceFactor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if(bFactor < -1)
            {
                if (balanceFactor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RateteRR(current);
                }
            }

        }
        private int balanceFactor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);                
                height = (l > r ? l : r) + 1;
            }
            return height;
        }
        pri
    }
}
