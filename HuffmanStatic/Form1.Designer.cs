namespace HuffmanStatic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loadFileBtn = new Button();
            encodeFileBtn = new Button();
            loadEncodedFileBtn = new Button();
            decodeFileBtn = new Button();
            showCodesEncoderCkb = new CheckBox();
            showCodesDecoderCkb = new CheckBox();
            listBoxEncoder = new ListBox();
            listBoxDecoder = new ListBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // loadFileBtn
            // 
            loadFileBtn.Location = new Point(12, 124);
            loadFileBtn.Name = "loadFileBtn";
            loadFileBtn.Size = new Size(150, 50);
            loadFileBtn.TabIndex = 0;
            loadFileBtn.Text = "Load File";
            loadFileBtn.UseVisualStyleBackColor = true;
            loadFileBtn.Click += loadFileBtn_Click;
            // 
            // encodeFileBtn
            // 
            encodeFileBtn.Location = new Point(12, 180);
            encodeFileBtn.Name = "encodeFileBtn";
            encodeFileBtn.Size = new Size(150, 50);
            encodeFileBtn.TabIndex = 1;
            encodeFileBtn.Text = "Encode File";
            encodeFileBtn.UseVisualStyleBackColor = true;
            encodeFileBtn.Click += encodeFileBtn_Click;
            // 
            // loadEncodedFileBtn
            // 
            loadEncodedFileBtn.Location = new Point(466, 124);
            loadEncodedFileBtn.Name = "loadEncodedFileBtn";
            loadEncodedFileBtn.Size = new Size(150, 50);
            loadEncodedFileBtn.TabIndex = 2;
            loadEncodedFileBtn.Text = "Load Encoded File";
            loadEncodedFileBtn.UseVisualStyleBackColor = true;
            loadEncodedFileBtn.Click += loadEncodedFileBtn_Click;
            // 
            // decodeFileBtn
            // 
            decodeFileBtn.Location = new Point(466, 180);
            decodeFileBtn.Name = "decodeFileBtn";
            decodeFileBtn.Size = new Size(150, 50);
            decodeFileBtn.TabIndex = 3;
            decodeFileBtn.Text = "Decode File";
            decodeFileBtn.UseVisualStyleBackColor = true;
            decodeFileBtn.Click += decodeFileBtn_Click;
            // 
            // showCodesEncoderCkb
            // 
            showCodesEncoderCkb.AutoSize = true;
            showCodesEncoderCkb.Location = new Point(182, 124);
            showCodesEncoderCkb.Name = "showCodesEncoderCkb";
            showCodesEncoderCkb.Size = new Size(112, 24);
            showCodesEncoderCkb.TabIndex = 4;
            showCodesEncoderCkb.Text = "Show Codes";
            showCodesEncoderCkb.UseVisualStyleBackColor = true;
            // 
            // showCodesDecoderCkb
            // 
            showCodesDecoderCkb.AutoSize = true;
            showCodesDecoderCkb.Location = new Point(638, 124);
            showCodesDecoderCkb.Name = "showCodesDecoderCkb";
            showCodesDecoderCkb.Size = new Size(112, 24);
            showCodesDecoderCkb.TabIndex = 5;
            showCodesDecoderCkb.Text = "Show Codes";
            showCodesDecoderCkb.UseVisualStyleBackColor = true;
            // 
            // listBoxEncoder
            // 
            listBoxEncoder.FormattingEnabled = true;
            listBoxEncoder.ItemHeight = 20;
            listBoxEncoder.Location = new Point(182, 154);
            listBoxEncoder.Name = "listBoxEncoder";
            listBoxEncoder.Size = new Size(150, 284);
            listBoxEncoder.TabIndex = 6;
            // 
            // listBoxDecoder
            // 
            listBoxDecoder.FormattingEnabled = true;
            listBoxDecoder.ItemHeight = 20;
            listBoxDecoder.Location = new Point(638, 154);
            listBoxDecoder.Name = "listBoxDecoder";
            listBoxDecoder.Size = new Size(150, 284);
            listBoxDecoder.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 38);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 8;
            label1.Text = "CODER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(598, 38);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 9;
            label2.Text = "DECODER";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxDecoder);
            Controls.Add(listBoxEncoder);
            Controls.Add(showCodesDecoderCkb);
            Controls.Add(showCodesEncoderCkb);
            Controls.Add(decodeFileBtn);
            Controls.Add(loadEncodedFileBtn);
            Controls.Add(encodeFileBtn);
            Controls.Add(loadFileBtn);
            Name = "Form1";
            Text = "Huffman Static";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadFileBtn;
        private Button encodeFileBtn;
        private Button loadEncodedFileBtn;
        private Button decodeFileBtn;
        private CheckBox showCodesEncoderCkb;
        private CheckBox showCodesDecoderCkb;
        private ListBox listBoxEncoder;
        private ListBox listBoxDecoder;
        private Label label1;
        private Label label2;
    }
}