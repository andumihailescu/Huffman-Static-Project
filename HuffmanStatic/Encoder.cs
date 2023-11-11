using Bit_Reader_Writer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        private uint[] symbolFrequency;
        private Model model;

        private string encoderInputFilePath;

        public Model GetModel() { return model; }

        public Encoder() 
        {
            
        }

        public void InitializeEncoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            fileLength = bitReader.GetFileLengthInBytes();
            fileLengthInBits = fileLength * 8;
            symbolFrequency = new uint[256];
            encoderInputFilePath = inputFilePath;
        }

        public void CountFrequency()
        {
            uint numberOfBits = 8;
            long numberOfRemainingBits = fileLengthInBits;

            do
            {
                if (numberOfBits > numberOfRemainingBits)
                {
                    numberOfBits = (uint)numberOfRemainingBits;
                }

                uint value = bitReader.ReadNBits(numberOfBits);
                symbolFrequency[value]++;
                numberOfRemainingBits -= numberOfBits;

            } while(numberOfRemainingBits > 0);

            bitReader.CloseFile();
        }

        public void CreateModel()
        {
            model = new Model();
            model.CreateBinaryTree(symbolFrequency);

            model.GenerateModel();
        }


        public void EncodeFile()
        {
            CountFrequency();

            CreateModel();

            uint numberOfBits = 8;
            long numberOfRemainingBits = fileLengthInBits;

            bitReader = new BitReader(encoderInputFilePath);

            uint encodedFileSizeInBits = 0;

            uint charactersUsedCounter = 0;

            for (int i = 0; i < 256; i++)
            {
                if (symbolFrequency[i] != 0)
                {
                    charactersUsedCounter++;
                }
            }

            bitWriter.WriteNBits(numberOfBits, charactersUsedCounter);
            encodedFileSizeInBits += numberOfBits;

            for (uint i = 0; i < 256; i++)
            {
                //convert from int to uint!!!!
                if (symbolFrequency[i] != 0)
                {
                    uint size = (uint)Math.Ceiling(Math.Log2(symbolFrequency[i] + 1));
                    bitWriter.WriteNBits(8, i);
                    bitWriter.WriteNBits(4, size);
                    bitWriter.WriteNBits(size, symbolFrequency[i]);
                    encodedFileSizeInBits = encodedFileSizeInBits + 8 + 4 + size;
                }
                
            }

            do
            {
                if (numberOfBits > numberOfRemainingBits)
                {
                    numberOfBits = (uint)numberOfRemainingBits;
                }
                
                uint value = bitReader.ReadNBits(numberOfBits);
                uint size = model.GetSymbolSizeInBits(value);
                uint symbol = model.GetEncodedSymbol(value);

                bitWriter.WriteNBits(size, symbol);
                encodedFileSizeInBits += size;
                numberOfRemainingBits -= numberOfBits;

            } while (numberOfRemainingBits > 0);

            if ((encodedFileSizeInBits % 8) != 0)
            {
                bitWriter.WriteNBits((8 - encodedFileSizeInBits % 8), 0);
            }

            bitReader.CloseFile();
            bitWriter.CloseFile();

        }

        

    }
}
