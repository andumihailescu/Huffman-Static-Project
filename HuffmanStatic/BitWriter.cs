using System;
using System.IO;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_Reader_Writer
{
    internal class BitWriter
    {
        private byte BufferWriter;
        private int NumberOfBitsToWrite;
        private FileStream outputFileStream;
        public BitWriter(string outputFilePath)
        {
            outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
            BufferWriter = 0;
            NumberOfBitsToWrite = 8;
        }


        public void CloseFile()
        { 
            outputFileStream.Flush();
            outputFileStream.Close();
            outputFileStream.Dispose();
        }
        private bool IsBufferFull()
        {
            return NumberOfBitsToWrite == 0;
        }

        private void WriteBit(byte value)
        {
            if (NumberOfBitsToWrite != 8)
            {
                BufferWriter = (byte)(BufferWriter << 1);
            }
            BufferWriter += value;
            NumberOfBitsToWrite--;

            if (IsBufferFull())
            {
                NumberOfBitsToWrite = 8;
                outputFileStream.WriteByte(BufferWriter);
                Console.WriteLine(BufferWriter);
                BufferWriter = 0;
            }
        }
        public void WriteNBits(int nr, uint value) //nr will be a value [1..32]. Value must be an unsigned number which can be store at least on 32 bits.E.g. in C# UINT32
        {
            for(int i = 0; i < nr; i++)
            {
                byte bit = (byte)((value >> (nr - i - 1)) & 1);
                WriteBit(bit);
            }
        }
    }
}
