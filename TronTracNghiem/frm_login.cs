using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronTracNghiem.Tut;

namespace TronTracNghiem
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = null;
            str = ContentLoading.GetXmlContent_user();
            string[] strm = str.Split(' ');
            string _s1 = strm[0];
            string _s2 = strm[1];
            if ((_s1 == textBox1.Text) && (_s2 == textBox2.Text))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                @interface fr = new @interface();
                this.Visible = false;
                fr.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
            }

        }
    }
}
