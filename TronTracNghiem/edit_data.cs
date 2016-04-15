using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TronTracNghiem
{
    public partial class edit_data : Form
    {
        public edit_data()
        {
            InitializeComponent();
        }
        string[,] a = new string[10000, 10000];
        long socau = 0;
        int point;
        string path;
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
        }
        private void edit_data_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if(opf.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = opf.FileName;
                load_data(textBox1.Text);
                path = System.IO.Path.GetFileName(opf.FileName);
            }
            for (int i = 1; i < socau; i++) listBox1.Items.Add(a[i, 0]);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        bool check()
        {
            if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "")&&(textBox5.Text != "") ) return true;
            else return false;
        }
        private void themcauhoi()
        {
            if (check() == false || path==null)
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //socau++;
            a[socau, 0] = textBox2.Text;
            a[socau, 1] = textBox3.Text;
            a[socau, 2] = textBox4.Text;
            a[socau, 3] = textBox5.Text;
            a[socau, 4] = textBox6.Text;
            listBox1.Items.Add(a[socau, 0]);
            socau++;
            ghifile();

        }
        private void suacauhoi()
        {
            /*textBox2.Text = a[point, 0];
            textBox3.Text = a[point, 1];
            textBox4.Text = a[point, 2];
            textBox5.Text = a[point, 3];
            textBox6.Text = a[point, 4];*/
            if (path == null)
            {
                MessageBox.Show("Chưa chọn câu hỏi cần sửa hoặc chọn bộ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            a[point, 0] = textBox2.Text;
            a[point, 1] = textBox3.Text;
            a[point, 2] = textBox4.Text;
            a[point, 3] = textBox5.Text;
            a[point, 4] = textBox6.Text;
            ghifile();
        }
        private void thembode()
        {
            if (tenbode.Text == "")
            {
                MessageBox.Show("Đặt tên bộ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            a[0, 0] = textBox2.Text;
            a[0, 1] = textBox3.Text;
            a[0, 2] = textBox4.Text;
            a[0, 3] = textBox5.Text;
            a[0, 4] = textBox6.Text;
            listBox1.Items.Add(a[0, 0]);

            string path = tenbode.Text + ".txt"; 
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter rd = new StreamWriter(fs, Encoding.UTF8);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j <= 4; j++) rd.WriteLine(a[i, j]);
            }
            rd.Close();
            MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ((them.Checked == false) && (sua.Checked == false) && (checkBox1.Checked == false))
            {
                MessageBox.Show("Bạn chưa chọn chức năng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (them.Checked == true)
            {
                themcauhoi();
                
            }
            if (sua.Checked == true)
            {
                suacauhoi();
                
            }
            if (checkBox1.Checked == true)
            {
                thembode();
                
            }
        }
        private void ghifile()
        {
            
            //StreamWriter rd = new StreamWriter(textBox1.Text);
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter rd = new StreamWriter(fs, Encoding.UTF8);
            for(int i=1;i<socau;i++)
            {
                for(int j=0;j<=4;j++) rd.WriteLine(a[i, j]);
            }
            rd.Close();
            MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void them_CheckedChanged(object sender, EventArgs e)
        {
            if (them.Checked == true) { sua.Checked = false; checkBox1.Checked = false; }
            
        }

        private void sua_CheckedChanged(object sender, EventArgs e)
        {
            if (sua.Checked == true)
            {
                them.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int point;
            point = listBox1.SelectedIndex+1;
            //label6.Text = point.ToString();
            textBox2.Text = a[point, 0];
            textBox3.Text = a[point, 1];
            textBox4.Text = a[point, 2];
            textBox5.Text = a[point, 3];
            textBox6.Text = a[point, 4];
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sua.Checked = false;
                them.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int take = listBox1.SelectedIndex;
            if (take == -1)
            {
                MessageBox.Show("Chưa chọn câu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            take++;
            int i;
            for(i=take+1;i<socau;i++)
            {
                a[i - 1,0] = a[i, 0];
                a[i - 1, 1] = a[i, 1];
                a[i - 1, 2] = a[i, 2];
                a[i - 1, 3] = a[i, 3];
                a[i - 1, 4] = a[i, 4];
            }
            socau--;
            ghifile();
            MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBox1.Items.Clear();
            for (i = 1; i < socau; i++) listBox1.Items.Add(a[i, 0]);
        }
    }
}
