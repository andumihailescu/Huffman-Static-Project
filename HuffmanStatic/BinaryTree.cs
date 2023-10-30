using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanStatic
{
    internal class Node
    {
        private int frequency;
        private int symbol;
        private Node left, right;

        public int GetFrequency() { return frequency; }
        public int GetSymbol() { return symbol; }
        public Node GetLeft() { return left; }
        public Node GetRight() { return right; }

        public Node()
        {

        }

        public Node(int frequency, int symbol)
        {
            this.frequency = frequency;
            this.symbol = symbol;
            left = null;
            right = null;
        }

        public Node(int frequency, Node left, Node right)
        {
            this.frequency = frequency;
            this.symbol = 0; ;
            this.left = left;
            this.right = right;
        }
    }
    
    internal class BinaryTree
    {
        public BinaryTree()
        {
        
        }
    }
}
