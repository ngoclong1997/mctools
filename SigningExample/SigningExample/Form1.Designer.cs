namespace SigningExample
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.sign = new System.Windows.Forms.Button();
            this.verify = new System.Windows.Forms.Button();
            this.browse1 = new System.Windows.Forms.Button();
            this.tbPath2 = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tbSignOutput = new System.Windows.Forms.TextBox();
            this.outputSign = new System.Windows.Forms.Button();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(12, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(285, 20);
            this.tbPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(303, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Sign File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // sign
            // 
            this.sign.Location = new System.Drawing.Point(12, 67);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(75, 23);
            this.sign.TabIndex = 2;
            this.sign.Text = "Sign";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // verify
            // 
            this.verify.Location = new System.Drawing.Point(303, 97);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(75, 23);
            this.verify.TabIndex = 5;
            this.verify.Text = "Verify";
            this.verify.UseVisualStyleBackColor = true;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            // 
            // browse1
            // 
            this.browse1.Location = new System.Drawing.Point(93, 67);
            this.browse1.Name = "browse1";
            this.browse1.Size = new System.Drawing.Size(75, 23);
            this.browse1.TabIndex = 4;
            this.browse1.Text = "Verify File";
            this.browse1.UseVisualStyleBackColor = true;
            this.browse1.Click += new System.EventHandler(this.browse1_Click);
            // 
            // tbPath2
            // 
            this.tbPath2.Enabled = false;
            this.tbPath2.Location = new System.Drawing.Point(12, 99);
            this.tbPath2.Name = "tbPath2";
            this.tbPath2.Size = new System.Drawing.Size(285, 20);
            this.tbPath2.TabIndex = 3;
            this.tbPath2.TextChanged += new System.EventHandler(this.tbPath2_TextChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // tbSignOutput
            // 
            this.tbSignOutput.Enabled = false;
            this.tbSignOutput.Location = new System.Drawing.Point(12, 41);
            this.tbSignOutput.Name = "tbSignOutput";
            this.tbSignOutput.Size = new System.Drawing.Size(285, 20);
            this.tbSignOutput.TabIndex = 6;
            // 
            // outputSign
            // 
            this.outputSign.Location = new System.Drawing.Point(303, 39);
            this.outputSign.Name = "outputSign";
            this.outputSign.Size = new System.Drawing.Size(75, 23);
            this.outputSign.TabIndex = 7;
            this.outputSign.Text = "Sign File";
            this.outputSign.UseVisualStyleBackColor = true;
            this.outputSign.Click += new System.EventHandler(this.outputSign_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 212);
            this.Controls.Add(this.outputSign);
            this.Controls.Add(this.tbSignOutput);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.browse1);
            this.Controls.Add(this.tbPath2);
            this.Controls.Add(this.sign);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.Button browse1;
        private System.Windows.Forms.TextBox tbPath2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox tbSignOutput;
        private System.Windows.Forms.Button outputSign;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
    }
}

