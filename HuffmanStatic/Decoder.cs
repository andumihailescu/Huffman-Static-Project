using Bit_Reader_Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanStatic
{
    internal class Decoder
    {
        private BitReader bitReader;
        private BitWriter bitWriter;
        private int[] symbolFrequency;
        private Model model;

        private uint numberOfSymbols;

        public Model GetModel() { return model; }

        public Decoder()
        { 
        
        }

        public void InitializeDecoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            symbolFrequency = new int[256];
        }

        public void GetFileHeader()
        {
            int numberOfBits = 8;

            uint charactersUsedCounter = bitReader.ReadNBits(numberOfBits);

            for (int i = 0; i < charactersUsedCounter; i++)
            {
                uint character = bitReader.ReadNBits(8);
                uint size = bitReader.ReadNBits(4);
                uint value = bitReader.ReadNBits((int)size);
                symbolFrequency[character] += (int)value;
                numberOfSymbols += value;
            }
        }

        public void CreateModel()
        {
            model = new Model();
            model.CreateBinaryTree(symbolFrequency);

            model.GenerateModel();
        }

        public void DecodeFile()
        {
            GetFileHeader();

            CreateModel();

            int numberOfBits = 8;
            int oneBit = 1;
            Node node = model.GetRoot();

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
                    node = model.GetRoot();
                    numberOfSymbols--;
                }

            } while (numberOfSymbols > 0);

            bitReader.CloseFile();
            bitWriter.CloseFile();
        }
    }
}
