using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class frmtrogiup : Form
    {
        public frmtrogiup()
        {
            InitializeComponent();
        }

        private void angroupbox()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Xem thông tin") { angroupbox(); groupBox1.Visible = true; }
            if (e.Node.Text == "Xóa thông tin") { angroupbox(); groupBox1.Visible = true; groupBox2.Visible = true; }
            if (e.Node.Text == "Sửa thông tin") { angroupbox(); groupBox1.Visible = true; groupBox2.Visible = true; groupBox3.Visible = true; }
            if (e.Node.Text == "Thêm thông tin") { angroupbox(); groupBox1.Visible = true; groupBox2.Visible = true; groupBox3.Visible = true; groupBox4.Visible = true; }
            if (e.Node.Text == "Tìm kiếm") { angroupbox(); groupBox1.Visible = true; groupBox2.Visible = true; groupBox3.Visible = true; groupBox4.Visible = true; groupBox5.Visible = true; }
            if (e.Node.Text == "Phòng ban") { angroupbox(); groupBox1.Visible = true; groupBox2.Visible = true; groupBox3.Visible = true; groupBox4.Visible = true; groupBox5.Visible = true; groupBox6.Visible = true; }
        }
    }
}
