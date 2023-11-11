﻿using System;
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
        private int[] symbolSizeInBitsList;

        public Model()
        {
            listOfEncodedSymbols = new uint[256];
            symbolSizeInBitsList = new int[256];
        }

        public Node GetRoot() { return root; }

        public void CreateBinaryTree(int[] symbolFrequency)
        {
            List<Node> leafs = new List<Node>();
            for (int i = 0; i < 256; i++)
            {
                if (symbolFrequency[i] > 0)
                {
                    leafs.Add(new Node(symbolFrequency[i], i));
                }
            }

            while (leafs.Count > 1)
            {
                leafs = leafs.OrderBy(o => o.GetFrequency()).ToList();
                int frequencySum = leafs[0].GetFrequency() + leafs[1].GetFrequency();
                Node node = new Node(frequencySum, leafs[0], leafs[1]);
                leafs.RemoveAt(0);
                leafs.RemoveAt(0);
                leafs.Insert(0, node);
            }

            root = leafs[0];

        }

        public void DepthFirstSearch(Node node, uint currentCode, int currentSize)
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
        public int GetSymbolSizeInBits(uint index)
        {
            return symbolSizeInBitsList[index];
        }
    }
}
