using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace TronTracNghiem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[,] a = new string[10000, 10000];
        long socau = 0;
        private void load_data(string s)
        {
            StreamReader rd = new StreamReader(s);

            string tmp;

            do
            {
                tmp = rd.ReadLine();
                if (tmp != "")
                {
                    socau++;
                    a[socau, 0] = tmp;
                    for (int i = 1; i <= 4; i++)
                    {
                        a[socau, i] = rd.ReadLine();
                    }
                }
                else break;

            }
            while (tmp != null);
            rd.Close();
            label1.Text = "Tổng số câu trắc nghiệm hiện có : " + (socau - 1).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Xuli(int value,int stt)
        {
            char[] alpha=new char[5];
            alpha[1]='A';
            alpha[2]='B';
            alpha[3]='C';
            alpha[4]='D';
            for(int i=0;i<=4;i++)
            {
                if (i == 0) richTextBox1.AppendText("Câu "+stt+": "+a[value, 0] + "\n");
                else richTextBox1.AppendText(alpha[i]+"." +" "+a[value, i]+"\n");
            }
            richTextBox1.AppendText("\n");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear(); 
            RandomNumberGenerator.Create();
            Random rd = new Random();
            bool[] free = new bool[101];
            for (int i = 0; i <= 100; i++) free[i] = false;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Chưa nhập số câu hỏi", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            int  n = Convert.ToInt32(textBox1.Text);
            if (n > socau-1)
            {
                MessageBox.Show("Không đủ số lượng câu hỏi", "Thông báp", MessageBoxButtons.OK);
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                bool check = false;
                while (check != true) 
                {
                    int tmp = rd.Next(1, n+1);
                    if (free[tmp] == false)
                    {
                        Xuli(tmp,i);
                        free[tmp] = true;
                        check = true;
                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Word.Application objWord = new Word.Application();
            objWord.Visible = true;
            Word.Document objDoc;
            object objMissing = System.Reflection.Missing.Value;
            objDoc = objWord.Documents.Add(ref objMissing, ref objMissing, ref objMissing, ref objMissing);
            objWord.Selection.TypeText(richTextBox1.Text);
            objWord = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = opf.FileName;
                
                string path = System.IO.Path.GetFileName(opf.FileName);
                load_data(path);
            }
        }

    }
}
