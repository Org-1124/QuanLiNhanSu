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
    public partial class frmDangNhap : Form
    {
        QuanLyNhanSuDataContext database = new QuanLyNhanSuDataContext();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = database.TaiKhoans.SingleOrDefault(n => n.TenDangNhap == txtTenDangNhap.Text && n.MatKhau == txtMatKhau.Text);
            if(tk==null)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai mời đăng nhập lại");
                return;
            }
            else
            {
                frmMain f = new frmMain();
                f.Show();
                this.Hide();
            }

        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            frmDangKi f = new frmDangKi();
            f.ShowDialog();
        }
    }
}
