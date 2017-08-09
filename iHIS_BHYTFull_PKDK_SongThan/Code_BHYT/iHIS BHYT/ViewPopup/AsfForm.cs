using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DirectX.Capture;

namespace Ps.Clinic.ViewPopup
{
    public partial class AsfForm : DevExpress.XtraEditors.XtraForm
    {
        Capture capture = null;
        private bool formatchanged = false;
        private bool indexchanged = false;
        public AsfForm(Capture capture)
        {
            InitializeComponent();
            this.capture = capture;
        }

        private void butOke_Click(object sender, EventArgs e)
        {
            // Store form data
            if (formatchanged)
            {
                if ((this.AsfAvListBox1.SelectedIndex >= 0) &&
                    (this.AsfAvListBox1.SelectedIndex < this.capture.AsfFormat.NbrAsfItems()))
                {
                    this.capture.AsfFormat.CurrentAsfItem = this.AsfAvListBox1.SelectedIndex; // Valid index
                }

                formatchanged = false;
            }

            if (indexchanged)
            {
                this.capture.AsfFormat.UseIndex = this.checkBoxIndex1.Checked;
                indexchanged = false;
            }

            Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsfForm_Load(object sender, EventArgs e)
        {
            if ((this.capture == null) ||
                ((this.capture != null) && (this.capture.AsfFormat == null)))
            {
                MessageBox.Show("Windows Media format module not loaded, nothing to select!");
                Close();
            }
            else
            {
                this.AsfAvListBox1.Items.Clear();

                // Load relevant form data
                for (int i = 0; i < this.capture.AsfFormat.NbrAsfItems(); i++)
                {
                    this.AsfAvListBox1.Items.Add(this.capture.AsfFormat[i].Name.ToString());
                }

                if ((this.capture.AsfFormat.CurrentAsfItem >= 0) &&
                    (this.capture.AsfFormat.CurrentAsfItem < this.capture.AsfFormat.NbrAsfItems()))
                {
                    this.AsfAvListBox1.SelectedIndex = this.capture.AsfFormat.CurrentAsfItem;
                    this.formatchanged = false; // reset value, will be set by previous line ...
                }

                this.checkBoxIndex1.Checked = this.capture.AsfFormat.UseIndex;
            }
        }

        private void AsfForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture = null;
        }

        private void AsfAvListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mark selection change
            formatchanged = true;

            // Show Asf specific information
            if ((this.AsfAvListBox1.SelectedIndex >= 0) &&
                (this.AsfAvListBox1.SelectedIndex < this.capture.AsfFormat.NbrAsfItems()))
            {
                this.labelDescription1.Text = this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].Description.ToString();

                if (this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].Audio)
                {
                    int bitrate = this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].AudioBitrate / 1000;
                    this.labelAudioInfo1.Text = "Audio  (" + bitrate.ToString() + " kb/s)";
                }
                else
                {
                    this.labelAudioInfo1.Text = "";
                }

                if (this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].Video)
                {
                    int bitrate = this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].VideoBitrate / 1000;
                    if (bitrate == 0)
                    {
                        this.labelVideoInfo1.Text = "Video  (variable bitrate)";
                    }
                    else
                    {
                        this.labelVideoInfo1.Text = "Video  (" + bitrate.ToString() + " kb/s)";
                    }
                }
                else
                {
                    this.labelVideoInfo1.Text = "";
                }
            }
        }

        private void checkBoxIndex1_CheckedChanged(object sender, EventArgs e)
        {
            this.indexchanged = true;
        }
        
    }
}