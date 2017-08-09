namespace Ps.Clinic.ViewPopup
{
    partial class AsfForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsfForm));
            this.AsfAvListBox1 = new System.Windows.Forms.ComboBox();
            this.checkBoxIndex1 = new System.Windows.Forms.CheckBox();
            this.labelAudioInfo1 = new System.Windows.Forms.Label();
            this.labelVideoInfo1 = new System.Windows.Forms.Label();
            this.labelDescription1 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AsfAvListBox1
            // 
            this.AsfAvListBox1.Location = new System.Drawing.Point(12, 12);
            this.AsfAvListBox1.Name = "AsfAvListBox1";
            this.AsfAvListBox1.Size = new System.Drawing.Size(351, 21);
            this.AsfAvListBox1.TabIndex = 1;
            this.AsfAvListBox1.SelectedIndexChanged += new System.EventHandler(this.AsfAvListBox1_SelectedIndexChanged);
            // 
            // checkBoxIndex1
            // 
            this.checkBoxIndex1.Checked = true;
            this.checkBoxIndex1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIndex1.Location = new System.Drawing.Point(206, 37);
            this.checkBoxIndex1.Name = "checkBoxIndex1";
            this.checkBoxIndex1.Size = new System.Drawing.Size(56, 24);
            this.checkBoxIndex1.TabIndex = 8;
            this.checkBoxIndex1.Text = "Index";
            this.checkBoxIndex1.CheckedChanged += new System.EventHandler(this.checkBoxIndex1_CheckedChanged);
            // 
            // labelAudioInfo1
            // 
            this.labelAudioInfo1.Location = new System.Drawing.Point(38, 45);
            this.labelAudioInfo1.Name = "labelAudioInfo1";
            this.labelAudioInfo1.Size = new System.Drawing.Size(136, 16);
            this.labelAudioInfo1.TabIndex = 7;
            this.labelAudioInfo1.Text = "b";
            // 
            // labelVideoInfo1
            // 
            this.labelVideoInfo1.Location = new System.Drawing.Point(9, 81);
            this.labelVideoInfo1.Name = "labelVideoInfo1";
            this.labelVideoInfo1.Size = new System.Drawing.Size(185, 24);
            this.labelVideoInfo1.TabIndex = 10;
            this.labelVideoInfo1.Text = "a";
            // 
            // labelDescription1
            // 
            this.labelDescription1.Location = new System.Drawing.Point(9, 117);
            this.labelDescription1.Name = "labelDescription1";
            this.labelDescription1.Size = new System.Drawing.Size(354, 46);
            this.labelDescription1.TabIndex = 9;
            this.labelDescription1.Text = "c";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(190, 166);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOke
            // 
            this.butOke.Location = new System.Drawing.Point(109, 166);
            this.butOke.Name = "butOke";
            this.butOke.Size = new System.Drawing.Size(75, 23);
            this.butOke.TabIndex = 11;
            this.butOke.Text = "OK";
            this.butOke.Click += new System.EventHandler(this.butOke_Click);
            // 
            // AsfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 209);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOke);
            this.Controls.Add(this.labelVideoInfo1);
            this.Controls.Add(this.labelDescription1);
            this.Controls.Add(this.checkBoxIndex1);
            this.Controls.Add(this.labelAudioInfo1);
            this.Controls.Add(this.AsfAvListBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsfForm";
            this.Text = "AsfForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsfForm_FormClosing);
            this.Load += new System.EventHandler(this.AsfForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AsfAvListBox1;
        private System.Windows.Forms.CheckBox checkBoxIndex1;
        private System.Windows.Forms.Label labelAudioInfo1;
        private System.Windows.Forms.Label labelVideoInfo1;
        private System.Windows.Forms.Label labelDescription1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOke;
    }
}