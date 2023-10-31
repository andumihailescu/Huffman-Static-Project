using Bit_Reader_Writer;

namespace HuffmanStatic
{
    public partial class Form1 : Form
    {
        private Encoder encoder;
        private string encoderInputFilePath;
        private string encoderOutputFilePath;

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
            if (showCodesEncoderCkb.Checked)
            {
                encoder.DisplaySymbolCodes(this.listBoxEncoder);
            }
        }

        private void loadEncodedFileBtn_Click(object sender, EventArgs e)
        {

        }

        private void decodeFileBtn_Click(object sender, EventArgs e)
        {

        }
    }
}