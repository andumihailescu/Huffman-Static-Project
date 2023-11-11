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
            showCodesCkb = new CheckBox();
            codesListBox = new ListBox();
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
            loadEncodedFileBtn.Location = new Point(215, 124);
            loadEncodedFileBtn.Name = "loadEncodedFileBtn";
            loadEncodedFileBtn.Size = new Size(150, 50);
            loadEncodedFileBtn.TabIndex = 2;
            loadEncodedFileBtn.Text = "Load Encoded File";
            loadEncodedFileBtn.UseVisualStyleBackColor = true;
            loadEncodedFileBtn.Click += loadEncodedFileBtn_Click;
            // 
            // decodeFileBtn
            // 
            decodeFileBtn.Location = new Point(215, 180);
            decodeFileBtn.Name = "decodeFileBtn";
            decodeFileBtn.Size = new Size(150, 50);
            decodeFileBtn.TabIndex = 3;
            decodeFileBtn.Text = "Decode File";
            decodeFileBtn.UseVisualStyleBackColor = true;
            decodeFileBtn.Click += decodeFileBtn_Click;
            // 
            // showCodesCkb
            // 
            showCodesCkb.AutoSize = true;
            showCodesCkb.Location = new Point(420, 47);
            showCodesCkb.Name = "showCodesCkb";
            showCodesCkb.Size = new Size(112, 24);
            showCodesCkb.TabIndex = 4;
            showCodesCkb.Text = "Show Codes";
            showCodesCkb.UseVisualStyleBackColor = true;
            // 
            // codesListBox
            // 
            codesListBox.FormattingEnabled = true;
            codesListBox.ItemHeight = 20;
            codesListBox.Location = new Point(420, 77);
            codesListBox.Name = "codesListBox";
            codesListBox.Size = new Size(150, 364);
            codesListBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 51);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 8;
            label1.Text = "CODER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 47);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 9;
            label2.Text = "DECODER";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 453);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(codesListBox);
            Controls.Add(showCodesCkb);
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
        private CheckBox showCodesCkb;
        private ListBox codesListBox;
        private Label label1;
        private Label label2;
    }
}