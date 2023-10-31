using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Bit_Reader_Writer
{
    internal class BitReader
    {
        private byte BufferReader;
        private int NumberOfBitsToRead;
        private FileStream inputFileStream;

        public BitReader(string inputFilePath)
        {
            inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            NumberOfBitsToRead = 0;
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

        private byte ReadBit()
        {
            if (IsBufferEmpty())
            {
                BufferReader = (byte)inputFileStream.ReadByte();
                NumberOfBitsToRead = 8;
            }
            byte result = (byte)((BufferReader >> (NumberOfBitsToRead - 1)) & 1);
            NumberOfBitsToRead--;
            return result;
        }
        public uint ReadNBits(int nr) //nr will be a value [1..32]
        {
            uint result = 0;
            for (int i = 0; i < nr; i++)
            {
                byte bit = ReadBit();
                if (i != 0)
                {
                    result = result << 1;
                }
                result += (uint)(bit);
            }
            return result;
        }
    }
}

