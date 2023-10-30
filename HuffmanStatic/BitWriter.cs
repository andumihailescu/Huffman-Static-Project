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
        private byte BufferWriter; // It can be a byte or an array of items (each element in the array will represent a BIT)
        private int NumberOfBitsToWrite;
        private FileStream outputFileStream;
        public BitWriter(string outputFilePath) // file path of the output file
        {
            outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
            BufferWriter = 0;
            NumberOfBitsToWrite = 8;// initialize to 0 or 1 or 7 or 8;
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

        //The value type can be byte or int or even a boolean. But always it will take only the last bit of the value
        private void WriteBit(byte value)
        {
            BufferWriter += (byte)(value << (8 - NumberOfBitsToWrite));
            NumberOfBitsToWrite--;

            //write last bit from value into BufferWriter and increase / decrease the counter of NumberOfBitsWrite
            if (IsBufferFull())
            {
                NumberOfBitsToWrite = 8;// initialize to 0 or 1 or 7 or 8;
                //Write BufferWriter into the output file
                outputFileStream.WriteByte(BufferWriter);
                Console.WriteLine(BufferWriter);
                BufferWriter = 0;
            }
        }
        public void WriteNBits(int nr, uint value) //nr will be a value [1..32]. Value must be an unsigned number which can be store at least on 32 bits.E.g. in C# UINT32
        {
            for(int i = 0; i < nr; i++)
            {
                // WriteBit(...)
                byte bit = (byte)((value >> i) & 1);
                WriteBit(bit);
            }
        }
    }
}
