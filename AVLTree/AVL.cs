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
            public Node left = null;
            public Node right = null;
            public Node(T data) 
            {
                this.data = data;
            }

            public string FitData()
            {
                string s = data.ToString();
                int l = s.Length;
                if (l > 5)
                {
                    s = s.Remove(5);
                }else if(l < 5)
                {
                    s = s.PadRight((5+l)/2, ' ');
                    s = s.PadLeft(5, ' ');
                }
                return s;
            }
            public string ToStringInfo()
            {

                return string.Format("|{0}({1}){2}|", left?.FitData() ?? " null",Factor.ToString().PadLeft(2), right?.FitData() ?? " null");
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
            int maxLen = (int)Math.Pow(2, (h - 2)) * 16;
            if (h > 1)
            {
                List<StringBuilder> lSB = new List<StringBuilder>();
                for (int i = 0; i < h; i++)
                {
                    lSB.Add(new StringBuilder());
                }
                string sRoot = string.Format("|{0}({1})|", root.data, root.Factor);
                lSB[0].AppendFormat("{0}{1}", new string(' ', (maxLen - sRoot.Length) / 2),sRoot);
                lSB[1].Append(root.ToStringInfo());
                if (h > 2)
                {
                    lSB[1].Insert(0, new string(' ', (maxLen - 16) / 2));
                    List<Node> lNode = new(){root};
                    for (int i = 2; i < h; i++)
                    {
                        List<Node> lNodeTmp = new();
                        lNode.ForEach(x => { lNodeTmp.Add(x.left); lNodeTmp.Add(x.right); });
                        lNode = lNodeTmp;
                        int distance = (maxLen - (lNode.Count * 16)) / (lNode.Count * 2);
                        lNode.ForEach(x => {

                            lSB[i].Append(new string(' ', distance));
                            lSB[i].Append(x?.ToStringInfo() ?? new string(' ', 16));
                            lSB[i].Append(new string(' ', distance));
                        }
                        );
                    }
                }
                lSB.ForEach(x => stringBuilder.AppendLine(x.ToString()));
            }
            else
            {
                stringBuilder.AppendFormat("|{0}({1})|", root.data, root.Factor); ;
            }

            Console.WriteLine(stringBuilder);
        }
    }
}
