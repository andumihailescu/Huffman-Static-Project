using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanStatic
{
    internal class Model
    {
        private Node root;
        private uint[] listOfEncodedSymbols;
        private uint[] symbolSizeInBitsList;

        public Model()
        {
            listOfEncodedSymbols = new uint[256];
            symbolSizeInBitsList = new uint[256];
        }

        public Node GetRoot() { return root; }

        public void CreateBinaryTree(uint[] symbolFrequency)
        {
            List<Node> leaves = new List<Node>();
            for (uint i = 0; i < 256; i++)
            {
                if (symbolFrequency[i] > 0)
                {
                    leaves.Add(new Node(symbolFrequency[i], i));
                }
            }

            while (leaves.Count > 1)
            {
                leaves = leaves.OrderBy(o => o.GetFrequency()).ToList();
                uint frequencySum = leaves[0].GetFrequency() + leaves[1].GetFrequency();
                Node node = new Node(frequencySum, leaves[0], leaves[1]);
                leaves.RemoveAt(0);
                leaves.RemoveAt(0);
                leaves.Insert(0, node);
            }

            root = leaves[0];

        }

        public void DepthFirstSearch(Node node, uint currentCode, uint currentSize)
        {

            if (node.GetLeft() == null && node.GetRight() == null)
            {
                listOfEncodedSymbols[node.GetSymbol()] = currentCode;
                symbolSizeInBitsList[node.GetSymbol()] = currentSize;

                return;
            }

            DepthFirstSearch(node.GetLeft(), (currentCode << 1) + 0, currentSize + 1);
            DepthFirstSearch(node.GetRight(), (currentCode << 1) + 1, currentSize + 1);
        }

        public void GenerateModel()
        {
            DepthFirstSearch(root, 0, 0);
        }

        public uint GetEncodedSymbol(uint index)
        {
            return listOfEncodedSymbols[index];
        }
        public uint GetSymbolSizeInBits(uint index)
        {
            return symbolSizeInBitsList[index];
        }
    }
}
