/****************************************************************************
While the underlying libraries are covered by LGPL, this sample is released 
as public domain.  It is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  

Written by snarfle@sourceforge.net
*****************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

using DESCombineLib;
using DirectShow4Net;

namespace TestConverter
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        #region Form Controls

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbToScreen;
        private System.Windows.Forms.RadioButton rbToAVI;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label labOutput;
        private System.Windows.Forms.Label labProfile;
        private System.Windows.Forms.CheckBox cbShowXML;
        private System.Windows.Forms.TextBox tbVideo;
        private System.Windows.Forms.TextBox tbAudio;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labCompressor;
        private System.Windows.Forms.TextBox tbCompressor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbElapsed;
        private System.Windows.Forms.ProgressBar progressBar1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCompressor = new System.Windows.Forms.TextBox();
            this.rbToAVI = new System.Windows.Forms.RadioButton();
            this.rbToScreen = new System.Windows.Forms.RadioButton();
            this.labProfile = new System.Windows.Forms.Label();
            this.labCompressor = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.labOutput = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbShowXML = new System.Windows.Forms.CheckBox();
            this.tbVideo = new System.Windows.Forms.TextBox();
            this.tbAudio = new System.Windows.Forms.TextBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbElapsed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 43);
            this.button1.TabIndex = 30;
            this.button1.Text = "Doit";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(10, 482);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(355, 21);
            this.tbStatus.TabIndex = 2;
            this.tbStatus.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCompressor);
            this.groupBox1.Controls.Add(this.rbToAVI);
            this.groupBox1.Controls.Add(this.rbToScreen);
            this.groupBox1.Controls.Add(this.labProfile);
            this.groupBox1.Controls.Add(this.labCompressor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 77);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Render Method";
            // 
            // tbCompressor
            // 
            this.tbCompressor.Location = new System.Drawing.Point(211, 43);
            this.tbCompressor.Name = "tbCompressor";
            this.tbCompressor.ReadOnly = true;
            this.tbCompressor.Size = new System.Drawing.Size(173, 23);
            this.tbCompressor.TabIndex = 12;
            this.tbCompressor.Text = "Indeo?video 5.10 Compression Filter";
            this.tbCompressor.Visible = false;
            // 
            // rbToAVI
            // 
            this.rbToAVI.Location = new System.Drawing.Point(10, 43);
            this.rbToAVI.Name = "rbToAVI";
            this.rbToAVI.Size = new System.Drawing.Size(96, 26);
            this.rbToAVI.TabIndex = 12;
            this.rbToAVI.Text = "To AVI";
            this.rbToAVI.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbToScreen
            // 
            this.rbToScreen.Checked = true;
            this.rbToScreen.Location = new System.Drawing.Point(10, 17);
            this.rbToScreen.Name = "rbToScreen";
            this.rbToScreen.Size = new System.Drawing.Size(105, 26);
            this.rbToScreen.TabIndex = 11;
            this.rbToScreen.TabStop = true;
            this.rbToScreen.Text = "To Screen";
            this.rbToScreen.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // labProfile
            // 
            this.labProfile.Location = new System.Drawing.Point(211, 52);
            this.labProfile.Name = "labProfile";
            this.labProfile.Size = new System.Drawing.Size(58, 17);
            this.labProfile.TabIndex = 5;
            this.labProfile.Text = "Profile";
            this.labProfile.Visible = false;
            // 
            // labCompressor
            // 
            this.labCompressor.Location = new System.Drawing.Point(211, 26);
            this.labCompressor.Name = "labCompressor";
            this.labCompressor.Size = new System.Drawing.Size(120, 25);
            this.labCompressor.TabIndex = 7;
            this.labCompressor.Text = "Compressor";
            this.labCompressor.Visible = false;
            // 
            // tbOutput
            // 
            this.tbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(29, 241);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(278, 23);
            this.tbOutput.TabIndex = 20;
            this.tbOutput.Text = "output.avi";
            this.tbOutput.Visible = false;
            // 
            // labOutput
            // 
            this.labOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOutput.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labOutput.Location = new System.Drawing.Point(10, 215);
            this.labOutput.Name = "labOutput";
            this.labOutput.Size = new System.Drawing.Size(134, 25);
            this.labOutput.TabIndex = 5;
            this.labOutput.Text = "Output file name";
            this.labOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labOutput.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status";
            // 
            // btnOutput
            // 
            this.btnOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutput.Location = new System.Drawing.Point(317, 241);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(29, 25);
            this.btnOutput.TabIndex = 21;
            this.btnOutput.Text = "...";
            this.btnOutput.Visible = false;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.btnOutput);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.tbOutput);
            this.groupBox2.Controls.Add(this.labOutput);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbShowXML);
            this.groupBox2.Location = new System.Drawing.Point(6, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 302);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(355, 15);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(48, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Del";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(288, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(10, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(403, 88);
            this.listBox1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 25);
            this.label12.TabIndex = 23;
            this.label12.Text = "Files";
            // 
            // cbShowXML
            // 
            this.cbShowXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowXML.Location = new System.Drawing.Point(19, 276);
            this.cbShowXML.Name = "cbShowXML";
            this.cbShowXML.Size = new System.Drawing.Size(115, 20);
            this.cbShowXML.TabIndex = 22;
            this.cbShowXML.Text = "Show XML";
            // 
            // tbVideo
            // 
            this.tbVideo.Location = new System.Drawing.Point(326, 370);
            this.tbVideo.Name = "tbVideo";
            this.tbVideo.ReadOnly = true;
            this.tbVideo.Size = new System.Drawing.Size(106, 21);
            this.tbVideo.TabIndex = 12;
            this.tbVideo.TabStop = false;
            this.tbVideo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbAudio
            // 
            this.tbAudio.Location = new System.Drawing.Point(326, 396);
            this.tbAudio.Name = "tbAudio";
            this.tbAudio.ReadOnly = true;
            this.tbAudio.Size = new System.Drawing.Size(106, 21);
            this.tbAudio.TabIndex = 13;
            this.tbAudio.TabStop = false;
            this.tbAudio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(125, 396);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(57, 21);
            this.tbTime.TabIndex = 14;
            this.tbTime.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Media Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Video Bytes";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(221, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Audio Bytes";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbElapsed
            // 
            this.tbElapsed.Location = new System.Drawing.Point(125, 370);
            this.tbElapsed.Name = "tbElapsed";
            this.tbElapsed.ReadOnly = true;
            this.tbElapsed.Size = new System.Drawing.Size(57, 21);
            this.tbElapsed.TabIndex = 18;
            this.tbElapsed.TabStop = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 18);
            this.label13.TabIndex = 19;
            this.label13.Text = "Elapsed Time";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 431);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(345, 26);
            this.progressBar1.TabIndex = 99;
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(546, 576);
            this.Controls.Add(this.tbElapsed);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.tbAudio);
            this.Controls.Add(this.tbVideo);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Test Converter";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClose);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

#if USING_NET20
            // While I don't believe the cross thread accessing of 
            // controls I am doing in this program presents any risks, 
            // it does not follow MS best practices.  What's more,
            // in .NET 2.0, the debugger will complain.  Unless
            // you have these two statements.
            TextBox.CheckForIllegalCrossThreadCalls = false;
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
#endif
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private struct Chunk
        {
            public string sVideoFile;
            public string sAudioFile;
            public long lStart;
            public long lEnd;

            public Chunk(string v, string a, long s, long e)
            {
                if (v != null && v.Length == 0)
                {
                    v = null;
                }
                if (a != null && a.Length == 0)
                {
                    a = null;
                }
                sVideoFile = v;
                sAudioFile = a;
                lStart = s;
                lEnd = e;
            }

            public Chunk(string v, string a, string s, string e)
            {
                if (v != null && v.Length == 0)
                {
                    v = null;
                }
                if (a != null && a.Length == 0)
                {
                    a = null;
                }
                sVideoFile = v;
                sAudioFile = a;
                lStart = Convert.ToInt64(Convert.ToDouble(s) * DESCombine.UNITS);
                lEnd = Convert.ToInt64(Convert.ToDouble(e) * DESCombine.UNITS);
            }

            override public string ToString()
            {
                string sV;
                string sA;
                string e;

                if (sVideoFile != null && sVideoFile.Length > 0)
                {
                    FileInfo fV = new FileInfo(sVideoFile);
                    sV = fV.Name;
                }
                else
                {
                    sV = "<null>";
                }

                if (sAudioFile != null && sAudioFile.Length > 0)
                {
                    FileInfo fA = new FileInfo(sAudioFile);
                    sA = fA.Name;
                }
                else
                {
                    sA = "<null>";
                }

                if (lEnd > 0)
                {
                    e = ((float)lEnd / DESCombine.UNITS).ToString("###0.0");
                    e = e.PadLeft(6, ' ');
                }
                else
                {
                    e = "   -1  ";
                }

                string s = ((float)(lStart / DESCombine.UNITS)).ToString("###0.0");
                s = s.PadLeft(6, ' ');

                return string.Format("{0, -16} {1, -16} {2} {3}", sV, sA, s, e);
            }
        }

        DESCombine ds;

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (ds == null)
                {
                    MyCallback pVideo = new MyCallback(tbVideo, tbTime, tbElapsed, progressBar1);
                    MyCallback pAudio = new MyCallback(tbAudio);

                    // FPS, BPP, Width, Height
                    ds = new DESCombine(30, 24, 320, 240);

                    foreach (Chunk c in listBox1.Items)
                    {
                        if (c.sVideoFile == c.sAudioFile)
                        {
                            ds.AddAVFile(c.sVideoFile, c.lStart, c.lEnd);
                        }
                        else
                        {
                            if (c.sVideoFile != null)
                            {
                                ds.AddVideoFile(c.sVideoFile, c.lStart, c.lEnd);
                            }

                            if (c.sAudioFile != null)
                            {
                                ds.AddAudioFile(c.sAudioFile, c.lStart, c.lEnd);
                            }
                        }
                    }

                    if (rbToScreen.Checked)
                    {
                        ds.RenderToWindow(IntPtr.Zero, pVideo, pAudio);
                    }
                    else if (rbToAVI.Checked)
                    {
                        IBaseFilter ibfVideoCompressor = GetVideoCompressor(tbCompressor.Text);
                        ds.RenderToAVI(tbOutput.Text, ibfVideoCompressor, null, pVideo, pAudio);
                    }
                    else
                    {
                        MessageBox.Show("Programming error");
                    }

                    if (cbShowXML.Checked)
                    {
                        MessageBox.Show(ds.GetXML(), "XML representation of the DES graph");
                    }

                    ds.Completed += new EventHandler(Completed);
                    ds.FileCompleted += new EventHandler(FileCompleted);

                    ds.StartRendering();

                    groupBox2.Enabled = false;
                    progressBar1.Maximum = (int)(ds.MediaLength / (DESCombine.UNITS / 10));
                    progressBar1.Step = progressBar1.Maximum / 20;
                    progressBar1.Value = 0;
                    tbStatus.Text = "Running";
                    button1.Text = "Cancel";
                }
                else
                {
                    ds.Cancel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds.Dispose();
                ds = null;
            }
        }

        private IBaseFilter GetVideoCompressor(string sName)
        {
            IBaseFilter ibf = null;

            DsDevice[] dsd = DsDevice.GetDevicesOfCat(FilterCategory.VideoCompressorCategory);
            int x;

            for (x = 0; x < dsd.Length; x++)
            {
                if (dsd[x].Name == sName)
                {
                    Guid grf = typeof(IBaseFilter).GUID;
                    dsd[x].Mon.BindToObject(null, null, ref grf, out object o);
                    ibf = o as IBaseFilter;
                    break;
                }
            }

            return ibf;
        }

        private void Completed(object o, System.EventArgs e)
        {
            CompletedArgs ca = e as CompletedArgs;
            button1.Text = "Doit";
            tbStatus.Text = ca.Result.ToString();
            ds.Dispose();
            ds = null;
            groupBox2.Enabled = true;
            GC.Collect(); GC.WaitForPendingFinalizers();
        }

        private void FileCompleted(object o, System.EventArgs e)
        {
            FileCompletedArgs ca = e as FileCompletedArgs;
            tbStatus.Text = string.Format("Finished file: {0}", ca.FileName);
            Debug.WriteLine(string.Format("{0} {1}", ca.FileName, ca.Type));
        }

        private void btnOutput_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                OverwritePrompt = true,
                Filter = "All Files (*.*)|*.*"
            };
            DialogResult r = sfd.ShowDialog();
            if (r == DialogResult.OK)
            {
                this.tbOutput.Text = sfd.FileName;
            }
        }

        private void CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rbToScreen.Checked)
            {
                this.tbOutput.Visible = false;
                this.labOutput.Visible = false;
                this.labProfile.Visible = false;
                this.labCompressor.Visible = false;
                this.tbCompressor.Visible = false;
            }
            else if (rbToAVI.Checked)
            {
                this.tbOutput.Visible = true;
                this.labOutput.Visible = true;
                this.labProfile.Visible = false;
                this.labCompressor.Visible = true;
                this.tbCompressor.Visible = true;
            }
            else
            {
                MessageBox.Show("Programming error");
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            Form2 f = new Form2();
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                if (f.tbVideoFile.Text.Length == 0 || File.Exists(f.tbVideoFile.Text))
                {
                    if (f.tbAudioFile.Text.Length == 0 || File.Exists(f.tbAudioFile.Text))
                    {
                        if (f.tbVideoFile.Text.Length > 0 || f.tbAudioFile.Text.Length > 0)
                        {
                            Chunk c = new Chunk(
                                f.tbVideoFile.Text,
                                f.tbAudioFile.Text,
                                f.tbStart.Text,
                                f.tbEnd.Text);
                            int i = listBox1.Items.Add(c);
                            listBox1.SelectedIndex = i;
                        }
                        else
                        {
                            MessageBox.Show("No file provided");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Audio file does not exist", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Video file does not exist", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            int iSel = listBox1.SelectedIndex;
            if (iSel >= 0)
            {
                listBox1.Items.RemoveAt(iSel);

                if (listBox1.Items.Count > 0)
                {
                    if (iSel > 0)
                    {
                        listBox1.SelectedIndex = iSel - 1;
                    }
                    else
                    {
                        listBox1.SelectedIndex = 0;
                    }
                }
            }
        }

        private void FormClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ds != null)
            {
                ds.Cancel();
            }
        }
    }

    public class MyCallback : IDESCombineCB
    {
        private int m_FrameCount;
        private long m_TotBytes;
        private DateTime m_StartTime;
        private double m_LastSampleTime;
        private bool m_KeepTime;

        private TextBox m_tbBytes;
        private TextBox m_MediaTime;
        private TextBox m_ElapsedTime;
        private ProgressBar m_pb;

        public MyCallback(TextBox c)
        {
            this.m_FrameCount = 0;
            this.m_TotBytes = 0;
            this.m_KeepTime = false;

            this.m_tbBytes = c;
            this.m_MediaTime = null;
            this.m_ElapsedTime = null;
            this.m_pb = null;
        }
        public MyCallback(TextBox c, TextBox d, TextBox e, ProgressBar f)
        {
            this.m_FrameCount = 0;
            this.m_TotBytes = 0;
            this.m_KeepTime = false;

            this.m_tbBytes = c;
            this.m_MediaTime = d;
            this.m_ElapsedTime = e;
            this.m_pb = f;
        }
        ~MyCallback()
        {
            this.m_tbBytes.Text = this.m_TotBytes.ToString();
            if (this.m_MediaTime != null)
            {
                this.m_MediaTime.Text = this.m_LastSampleTime.ToString("0.00");
                this.m_ElapsedTime.Text = (DateTime.Now - this.m_StartTime).ToString();

                this.m_pb.Value = this.m_pb.Maximum;
            }
        }

        public void KeepTime()
        {
            this.m_KeepTime = true;
        }

        public int BufferCB(string sFilename, double sampleTime, System.IntPtr pBuffer, int bufferLen)
        {
            if (this.m_FrameCount == 0 && this.m_MediaTime != null)
            {
                this.m_StartTime = DateTime.Now;
            }

            if (this.m_KeepTime && this.m_MediaTime != null)
            {
                TimeSpan ts = DateTime.Now - this.m_StartTime;
                int iSleep = (int)((sampleTime - ts.TotalSeconds) * 1000);
                if (iSleep > 0)
                {
                    System.Threading.Thread.Sleep(iSleep);
                }
            }

            this.m_FrameCount++;
            this.m_TotBytes += bufferLen;

            if (this.m_FrameCount % 15 == 0)
            {
                this.m_tbBytes.Text = this.m_TotBytes.ToString();
                if (this.m_MediaTime != null)
                {
                    this.m_pb.Value = (int)(sampleTime * 10);
                    this.m_MediaTime.Text = sampleTime.ToString("0.00");
                    this.m_ElapsedTime.Text = (DateTime.Now - this.m_StartTime).ToString();
                }
            }
            this.m_LastSampleTime = sampleTime;

            return 0;
        }
    }

}
