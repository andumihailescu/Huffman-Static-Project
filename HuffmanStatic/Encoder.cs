using Bit_Reader_Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace HuffmanStatic
{
    internal class Encoder
    {

        private BitReader bitReader;
        private BitWriter bitWriter;
        private long fileLength;
        private long fileLengthInBits;
        private int[] symbolFrequency;
        private Node root;

        private uint[] listOfEncodedSymbols;
        private int[] symbolSizeInBitsList;

        private string encoderInputFilePath;

        public Encoder() 
        {
            
        }

        public void InitializeEncoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            fileLength = bitReader.GetFileLengthInBytes();
            fileLengthInBits = fileLength * 8;
            symbolFrequency = new int[256];
            listOfEncodedSymbols = new uint[256];
            symbolSizeInBitsList = new int[256];
            encoderInputFilePath = inputFilePath;
        }

        public void CountFrequency()
        {
            int numberOfBits = 8;
            long numberOfRemainingBits = fileLengthInBits;

            do
            {
                if (numberOfBits > numberOfRemainingBits)
                {
                    numberOfBits = (int)numberOfRemainingBits;
                }

                uint value = bitReader.ReadNBits(numberOfBits);
                symbolFrequency[value]++;
                numberOfRemainingBits -= numberOfBits;

            } while(numberOfRemainingBits > 0);

            bitReader.CloseFile();
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


        public void EncodeFile()
        {
            CountFrequency();

            GenerateModel();

            int numberOfBits = 8;
            long numberOfRemainingBits = fileLengthInBits;

            bitReader = new BitReader(encoderInputFilePath);

            int encodedFileSizeInBits = 0;

            for (int i = 0; i < 256; i++)
            {
                //convert from int to uint!!!!
                Console.Write(Convert.ToChar(i) + ": ");
                bitWriter.WriteNBits(numberOfBits, (uint)symbolFrequency[i]);
                encodedFileSizeInBits += 8;
            }

            do
            {
                if (numberOfBits > numberOfRemainingBits)
                {
                    numberOfBits = (int)numberOfRemainingBits;
                }
                
                uint value = bitReader.ReadNBits(numberOfBits);
                int size = symbolSizeInBitsList[value];
                uint symbol = listOfEncodedSymbols[value];

                bitWriter.WriteNBits(size, symbol);
                encodedFileSizeInBits += size;
                numberOfRemainingBits -= numberOfBits;

            } while (numberOfRemainingBits > 0);

            if ((encodedFileSizeInBits % 8) != 0)
            {
                bitWriter.WriteNBits((int)(8 - encodedFileSizeInBits % 8), 0);
            }

            bitReader.CloseFile();
            bitWriter.CloseFile();

        }

        public void DisplaySymbolCodes(ListBox listBox)
        {
            listBox.Items.Clear();

            for(int i = 0; i < 256; i++)
            {
                if (symbolSizeInBitsList[i] != 0)
                {
                    char symbol = (char)i;
                    string value = "";
                    for(int j = 0; j < symbolSizeInBitsList[i]; j++)
                    {
                        value += ((listOfEncodedSymbols[i] >> (symbolSizeInBitsList[i] - j - 1)) & 1);
                    }
                    listBox.Items.Add(symbol + "= " + value);
                }
            }
        }

    }
}
