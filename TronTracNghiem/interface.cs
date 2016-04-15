using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading.Tasks;
using System.Reflection;
using TronTracNghiem.Tut;

namespace TronTracNghiem
{
    public partial class @interface : Form
    {
        public @interface()
        {
            InitializeComponent();
            string s;
            s = ContentLoading.GetXmlContent_user().ToString();
            string[] str = s.Split(' ');
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 fr = new Form1();
            fr.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            edit_data fr = new edit_data();
            fr.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            infomation fr = new infomation();
            fr.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
