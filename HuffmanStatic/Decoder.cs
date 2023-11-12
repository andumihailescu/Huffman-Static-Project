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
        private uint[] symbolFrequency;
        private Model model;

        private uint numberOfSymbols;

        private const uint oneBit = 1;
        private const uint oneByte = 8;
        private const uint frequencySpaceInBits = 4;

        public Model GetModel() { return model; }

        public Decoder()
        { 
        
        }

        public void InitializeDecoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            symbolFrequency = new uint[256];
        }

        public void GetFileHeader()
        {
            uint charactersUsedCounter = bitReader.ReadNBits(oneByte);

            for (int i = 0; i < charactersUsedCounter; i++)
            {
                uint character = bitReader.ReadNBits(oneByte);
                uint size = bitReader.ReadNBits(frequencySpaceInBits);
                uint value = bitReader.ReadNBits(size);
                symbolFrequency[character] += value;
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
                    bitWriter.WriteNBits(oneByte, node.GetSymbol());
                    node = model.GetRoot();
                    numberOfSymbols--;
                }

            } while (numberOfSymbols > 0);
            bitReader.CloseFile();
            bitWriter.CloseFile();
        }
    }
}
