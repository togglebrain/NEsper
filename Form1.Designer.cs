namespace NesperTest
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
            this.lblPredict = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtRecd = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPredict
            // 
            this.lblPredict.AutoSize = true;
            this.lblPredict.Location = new System.Drawing.Point(40, 135);
            this.lblPredict.Name = "lblPredict";
            this.lblPredict.Size = new System.Drawing.Size(68, 13);
            this.lblPredict.TabIndex = 1;
            this.lblPredict.Text = "Processing...";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Minimize",
            "Maximize",
            "Lock",
            "Code",
            "Scroll",
            "Delete"});
            this.comboBox1.Location = new System.Drawing.Point(43, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtRecd
            // 
            this.txtRecd.Enabled = false;
            this.txtRecd.Location = new System.Drawing.Point(43, 75);
            this.txtRecd.Multiline = true;
            this.txtRecd.Name = "txtRecd";
            this.txtRecd.Size = new System.Drawing.Size(181, 57);
            this.txtRecd.TabIndex = 6;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Coffee",
            "Blink",
            "Stare"});
            this.comboBox2.Location = new System.Drawing.Point(43, 44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(181, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 162);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtRecd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblPredict);
            this.Name = "Form1";
            this.Text = "CEP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPredict;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtRecd;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

