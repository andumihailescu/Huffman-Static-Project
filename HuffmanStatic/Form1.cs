using Bit_Reader_Writer;
using System.Reflection;

namespace HuffmanStatic
{
    public partial class Form1 : Form
    {
        private Encoder encoder;
        private string encoderInputFilePath;
        private string encoderOutputFilePath;
        private Decoder decoder;
        private string decoderInputFilePath;
        private string decoderOutputFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\School\CIM\HuffmanStatic\Files";
            openFileDialog.ShowDialog();
            encoderInputFilePath = openFileDialog.FileName;
            encoderOutputFilePath = openFileDialog.FileName + ".hs";

            encoder = new Encoder();
        }

        private void encodeFileBtn_Click(object sender, EventArgs e)
        {
            encoder.InitializeEncoder(encoderInputFilePath, encoderOutputFilePath);
            encoder.EncodeFile();
            if (showCodesCkb.Checked)
            {
                DisplaySymbolCodes(this.codesListBox);
            }
        }

        private void loadEncodedFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\School\CIM\HuffmanStatic\Files";
            openFileDialog.Filter = "Text Files|*.hs|All Files|*.*";
            openFileDialog.ShowDialog();

            decoderInputFilePath = openFileDialog.FileName;
            DateTime currentDateTime = DateTime.Now;
            string formattedTimestamp = currentDateTime.ToString("dd-MM-yyyy-HH-mm");
            string[] parts = decoderInputFilePath.Split('.');
            string extension = parts[parts.Length - 2];

            decoderOutputFilePath = openFileDialog.FileName + "." + formattedTimestamp + "." + extension;

            decoder = new Decoder();
        }

        private void decodeFileBtn_Click(object sender, EventArgs e)
        {
            decoder.InitializeDecoder(decoderInputFilePath, decoderOutputFilePath);
            decoder.DecodeFile();
            if (showCodesCkb.Checked)
            {
                DisplaySymbolCodes(this.codesListBox);
            }
        }

        private void DisplaySymbolCodes(ListBox listBox)
        {
            listBox.Items.Clear();

            for (uint i = 0; i < 256; i++)
            {
                if (encoder.GetModel().GetSymbolSizeInBits(i) != 0)
                {
                    char symbol = (char)i;
                    string value = "";
                    for (uint j = 0; j < encoder.GetModel().GetSymbolSizeInBits(i); j++)
                    {
                        value += ((encoder.GetModel().GetEncodedSymbol(i) >> (int)(encoder.GetModel().GetSymbolSizeInBits(i) - j - 1)) & 1);
                    }
                    listBox.Items.Add(symbol + "= " + value);
                }
            }
        }

    }
}