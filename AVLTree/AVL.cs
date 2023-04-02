using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class AVL<T> where T : IComparable<T>
    {
        private class Node
        {
            public T data;
            public int Factor
            {
                get
                {
                    int l = left?.Height ?? 0;
                    int r  = right?.Height ?? 0;
                    return r-l;
                }
            }
            public int Height { get
                {
                    int l = left?.Height ?? 0;
                    int r = right?.Height ?? 0;
                    return 1 + (l > r ? l : r); 
                } 
            }
            public Node left;
            public Node right;
            public Node(T data) 
            {
                this.data = data;
            }

            public override string ToString()
            {
                return string.Format("{0}", data);
            }
            public string ToStringInfo()
            {
                return string.Format("|{0} ({1}) {2}|", left?.ToString() ?? "null",Factor, right?.ToString() ?? "null");
            }
        }
        Node root;

        public AVL()
        {

        }
        public void Add(T data)
        {
            Node node = new Node(data);

            root = recursiveInsert(root, node);

        }

        private Node recursiveInsert(Node current, Node node)
        {
            if (current == null)
            {
                return node;
            }
            else if (current.data.CompareTo(node.data) < 0)
                current.right = recursiveInsert(current.right, node);
            else
                current.left = recursiveInsert(current.left, node);

            return balanceTree(current);
        }

        private Node balanceTree(Node current)
        {
            int factor = current.Factor;
            if (factor < -1)
            {
                if (current.left.Factor < 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (factor > 1)
            {
                if (current.right.Factor < 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }


        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

        public bool Contains(T key)
        {
            return Find(key, root) != null;            
        }
        private Node Find(T target, Node current)
        {
            if (current == null)
            {
                return null;
            }
            else if (target.CompareTo(current.data) < 0)
            {
                return Find(target, current.left);
            }
            else if (target.CompareTo(current.data) > 0)
            {
                return Find(target, current.right);
            }
            else
                return current;

        }
        public bool Remove(T target)
        {
            bool isFind = false;
            root = recursiveDelete(target, root, ref isFind);
            return isFind;
        }
        private Node recursiveDelete(T target, Node current, ref bool isFind)
        {
            if (current == null)
            {
                return current;
            }
            else if (target.CompareTo(current.data) < 0)
            {
                current.left = recursiveDelete(target, current.left, ref isFind);
            }
            else if (target.CompareTo(current.data) > 0)
            {
                current.right = recursiveDelete(target, current.right, ref isFind);
            }
            else
            {
                isFind = true;
                if (current.left != null)
                {
                    T swap;
                    current.left = swapMax(current.left,out swap);
                    current.data = swap;
                }
                else
                {                   
                    return current.right;
                }
            }
            if (isFind == true)
            {
                return balanceTree(current);
            }else
            {
                return current;
            }
            

        }
        private Node swapMax(Node current, out T swap)
        {
            if (current.right == null)
            {
                swap = current.data;
                return current.left;
            }
            else
            {
                current.right = swapMax(current.right, out swap);
                return balanceTree(current);
            }
        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            StringBuilder stringBuilder = new();
            int h = root.Height;
            
            
            if (h > 1)
            {
                List<StringBuilder> lSB = new List<StringBuilder>();
                for (int i = 0; i < h; i++)
                {
                    lSB.Add(new StringBuilder());
                }
                lSB[0].AppendFormat("|{0}({1})|", root.data, root.Factor);
                lSB[1].Append(root.ToStringInfo());
                if (h > 2)
                {
                    List<Node> lNode = new();
                    lNode.Add(root);
                    for (int i = 2; i < h; i++)
                    {
                        List<Node> lNodeTmp = new();
                        lNode.ForEach(x => { lNodeTmp.Add(x.left); lNodeTmp.Add(x.right); });
                        lNode = lNodeTmp;
                        lNode.ForEach(x => lSB[i].Append(x.ToStringInfo()));
                    }
                }              
                int pivotLen = lSB[lSB.Count - 1].Length / 2;
                lSB.ForEach(x => x.Insert(0, new string(' ', pivotLen - (x.Length / 2))));
                lSB.ForEach(x => stringBuilder.AppendLine(x.ToString()));
            }
            else
            {
                stringBuilder.AppendFormat("|{0}({1})|", root.data, root.Factor); ;
            }

            Console.WriteLine(stringBuilder);
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                Console.WriteLine("Data: {0}, Factor: {3}, Height: {4}| Left: {1} Right: {2}", current, nodeToString(current.left),nodeToString(current.right),current.Factor, current.Height);
                Console.Write("L: ");
                InOrderDisplayTree(current.left);
                Console.Write("R: ");
                InOrderDisplayTree(current.right);
            }
            else
            {
                Console.WriteLine("Null");
            }
        }

        private string nodeToString(Node current)
        {
            return current != null ? current.ToString() : "Null";
        }
    }
}
