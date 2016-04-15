using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TronTracNghiem
{
    public partial class addquestion : Form
    {
        public addquestion()
        {
            InitializeComponent();
        }
        public bool Check()
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "")) return true;
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Check() == false)
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            //StreamWriter fout = File.AppendText("bode.txt");
            FileStream fo = new FileStream("bode.txt", FileMode.Create);
            StreamWriter fout = new StreamWriter(fo, Encoding.UTF8);
            fout.WriteLine(textBox1.Text);
            fout.WriteLine(textBox2.Text);
            fout.WriteLine(textBox3.Text);
            fout.WriteLine(textBox4.Text);
            fout.WriteLine(textBox5.Text);
            fout.Close();
        }
    }
}
