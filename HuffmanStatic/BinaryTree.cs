using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanStatic
{
    internal class Node
    {
        private uint frequency;
        private uint symbol;
        private Node left, right;
        
        public uint GetFrequency() { return frequency; }
        public uint GetSymbol() { return symbol; }
        public Node GetLeft() { return left; }
        public Node GetRight() { return right; }
        
        public Node(uint frequency, uint symbol)
        {
            this.frequency = frequency;
            this.symbol = symbol;
            left = null;
            right = null;
        }

        public Node(uint frequency, Node left, Node right)
        {
            this.frequency = frequency;
            this.symbol = 0; ;
            this.left = left;
            this.right = right;
        }

    }
}
