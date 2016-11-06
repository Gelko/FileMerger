using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader deReader = new StreamReader(textBox1.Text, Encoding.GetEncoding("iso-8859-1"));
            StreamReader engReader = new StreamReader(textBox2.Text, Encoding.GetEncoding("iso-8859-1"));

            string engWord = engReader.ReadLine();
            string destStr = string.Empty;
            string deWord = string.Empty;

            while (engWord != null)
            {
                if (engWord == string.Empty)
                {
                    deWord = deReader.ReadLine();
                    destStr += deWord + Environment.NewLine + Environment.NewLine;
                    engReader.ReadLine();
                }
                else
                {
                    destStr += engWord + Environment.NewLine;
                }
                engWord = engReader.ReadLine();
            }

            textBox3.Text = destStr;
            deReader.Close();
            engReader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = openFileDialog2.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox3.Text);
                }
            }

        }
    }
}
