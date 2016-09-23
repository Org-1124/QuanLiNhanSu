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
    public partial class FrmThemTaiKhoan : Form
    {
        public FrmThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void chHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar  =  chHienMatKhau.Checked ? false : true;
            txtXacNhan.UseSystemPasswordChar = chHienMatKhau.Checked ? false : true;
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text!=txtXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp");
            }
        }
        public void TaoTaiKhoan()
        {

        }
    }
}
