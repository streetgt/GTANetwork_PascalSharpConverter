namespace WindowsFormsApp1
{
    partial class ConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.githubURL = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(349, 20);
            this.txtInput.TabIndex = 0;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(367, 9);
            this.btnInput.Name = "btnInput";
            this.btnInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Input";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 39);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(430, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 69);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 180);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // githubURL
            // 
            this.githubURL.AutoSize = true;
            this.githubURL.Location = new System.Drawing.Point(404, 256);
            this.githubURL.Name = "githubURL";
            this.githubURL.Size = new System.Drawing.Size(38, 13);
            this.githubURL.TabIndex = 4;
            this.githubURL.TabStop = true;
            this.githubURL.Text = "Github";
            this.githubURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubURL_LinkClicked);
            // 
            // ConverterForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 278);
            this.Controls.Add(this.githubURL);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ConverterForm";
            this.ShowIcon = false;
            this.Text = "GTANetwork - Pascal Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.LinkLabel githubURL;
    }
}

