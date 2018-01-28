using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace vgmstreamtool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Process STFN = new Process();


        private void button1_Click(object sender, EventArgs e)
        {
            STFN.StartInfo.FileName = @"vgmstream\vgmstream.exe";
            try
            {
                OpenFileDialog O = new OpenFileDialog();
                O.Title = "请选择要转换的文件（支持选择多个文件进行转换，选择一个文件则进行保存）";
                O.Multiselect = true;
                if (O.ShowDialog() == DialogResult.OK)
                {
                    if (O.FileNames.Length == 1)
                    {
                        A(O.FileName);
                    }
                    else
                    {
                        for (int i = 0; i < O.FileNames.Length; i++)
                        {
                            Process P = new Process();
                            P.StartInfo.FileName = @"vgmstream\vgmstream.exe";
                            P.StartInfo.Arguments = "-o \"" + O.FileNames[i] + ".wav\" " + "\"" + O.FileNames[i] + "\"";
                            P.StartInfo.CreateNoWindow = true;
                            P.StartInfo.UseShellExecute = false;
                            P.Start();
                            P.WaitForExit();
                        }
                        MessageBox.Show("批量转换完成");
                    }
                }
            }
            catch (Exception E) { MessageBox.Show(E.Message, "错误"); }


            void A(string input)//调用vgmstream转换单个文件
            {
                STFN.StartInfo.FileName = @"vgmstream\vgmstream.exe";
                { }
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "WAV文件（*.wav）|*.wav";
                SFD.Title = "保存文件";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    Process P = new Process();
                    P.StartInfo.FileName = @"vgmstream\vgmstream.exe";
                    P.StartInfo.Arguments = "-o \"" + SFD.FileName + "\" " + "\"" + input + "\"";
                    P.StartInfo.CreateNoWindow = true;
                    P.StartInfo.UseShellExecute = false;
                    P.Start();
                    P.WaitForExit();
                    if (File.Exists(SFD.FileName))
                        MessageBox.Show("转换完成");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(@"vgmstream\readme.txt");
        }
    }
}
