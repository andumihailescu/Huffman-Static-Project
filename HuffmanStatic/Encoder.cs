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
            symbolFrequency = new int[256];
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
                int size = model.GetSymbolSizeInBits(value);
                uint symbol = model.GetEncodedSymbol(value);

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

        

    }
}
