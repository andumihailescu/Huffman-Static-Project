using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_Reader_Writer
{
    internal class BitReader
    {
        private byte BufferReader; // The type can be a byte or an array of items(each element in the array will represent a BIT)
        private int NumberOfBitsToRead;
        private FileStream inputFileStream;
        private long NumberOfAvailableBits;

        public BitReader(string inputFilePath) // filePath = the file path to the input file
        {
            inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            //NumberOfAvailableBits = this.inputFileStream.Length * 8;
            NumberOfBitsToRead = 0;// initialize to 0 or 1 or 7 or 8;It is a counter to see if the buffer is empty or not
        }

        public long GetFileLengthInBytes()
        {
            return inputFileStream.Length;
        }

        private bool IsBufferEmpty()
        {
            if (NumberOfBitsToRead == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CloseFile()
        {
            inputFileStream.Flush();
            inputFileStream.Close();
            inputFileStream.Dispose();
        }

        //The return type can be byte or int or even a boolean. Always this methods returns 1 bit - 0 or 1
        private byte ReadBit()
        {
            if (IsBufferEmpty())
            {
                //Read 1 byte (8bits) from input file and put in inside BufferReader
                BufferReader = (byte)inputFileStream.ReadByte();
                //Reset NumberOfBitsToRead
                NumberOfBitsToRead = 8;
            }
            //take 1 bit from the buffer and put in into result
            byte result = (byte)((BufferReader >> (8 - NumberOfBitsToRead)) & 1);
            //Probably decrease number of available bits
            NumberOfBitsToRead--;
            //NumberOfAvailableBits--;
            return result;
        }
        public uint ReadNBits(int nr) //nr will be a value [1..32]
        {
            uint result = 0;
            for (int i = 0; i < nr; i++)
            {
                // bit = ReadBit();
                byte bit = ReadBit();
                // add bit to result
                result += (uint)(bit << i);
            }
            return result;
        }
    }
}

