using Bit_Reader_Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanStatic
{
    internal class Decoder
    {
        private BitReader bitReader;
        private BitWriter bitWriter;
        private int[] symbolFrequency;
        private uint[] listOfEncodedSymbols;
        private int[] symbolSizeInBitsList;
        private Node root;

        private int numberOfSymbols = 0;

        public Decoder()
        { 
        
        }

        public void InitializeDecoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            symbolFrequency = new int[256];
            listOfEncodedSymbols = new uint[256];
            symbolSizeInBitsList = new int[256];
        }

        public void GetFileHeader()
        {
            int numberOfBits = 8;

            for (int i = 0; i < 256; i++)
            {
                uint value = bitReader.ReadNBits(numberOfBits);
                symbolFrequency[i] += (int)value;
                if (value != 0)
                {
                    numberOfSymbols += (int)value;
                }
            }
        }

        public void CreateBinaryTree()
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

            /*Node huffmanTree = leafs[0]; // Assuming there is only one node left in the list

            Console.WriteLine("Huffman Tree Structure:");
            DisplayTree(huffmanTree);*/

            root = leafs[0];

        }

        /*public void DisplayTree(Node node, int depth = 0)
               {
                   if (node == null)
                       return;
                   Console.WriteLine(new string(' ', depth * 2) + $"{node.GetSymbol()} ({node.GetFrequency()})");

                   DisplayTree(node.GetLeft(), depth + 1);
                   DisplayTree(node.GetRight(), depth + 1);
               }*/

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
            CreateBinaryTree();

            DepthFirstSearch(root, 0, 0);
        }

        public void DecodeFile()
        {
            GetFileHeader();

            GenerateModel();

            int numberOfBits = 8;
            int oneBit = 1;
            Node node = root;

            do
            {
                
                if (node.GetLeft() != null && node.GetRight() != null)
                {
                    byte value = (byte)bitReader.ReadNBits(oneBit);
                    if (value == 0)
                    {
                        node = node.GetLeft();
                    }
                    else
                    {
                        node = node.GetRight();
                    }
                }
                else
                {
                    bitWriter.WriteNBits(numberOfBits, (uint)node.GetSymbol());
                    node = root;
                    numberOfSymbols--;
                }

            } while (numberOfSymbols > 0);

            bitReader.CloseFile();
            bitWriter.CloseFile();
        }

        public void DisplaySymbolCodes(ListBox listBox)
        {
            listBox.Items.Clear();

            for (int i = 0; i < 256; i++)
            {
                if (symbolSizeInBitsList[i] != 0)
                {
                    char symbol = (char)i;
                    string value = "";
                    for (int j = 0; j < symbolSizeInBitsList[i]; j++)
                    {
                        value += ((listOfEncodedSymbols[i] >> (symbolSizeInBitsList[i] - j - 1)) & 1);
                    }
                    listBox.Items.Add(symbol + "= " + value);
                }
            }
        }
    }
}
