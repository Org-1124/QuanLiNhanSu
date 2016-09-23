using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;
namespace QuanLiNhanSu
{
    public partial class frmDoiMatKhaucs : Form
    {
        public frmDoiMatKhaucs(string tendangnhap)
        {
            InitializeComponent();
        }

        private void chHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = chHienMatKhau.Checked ? false : true;
            txtMatKhauMoi.UseSystemPasswordChar = chHienMatKhau.Checked ? false : true;
            txtMatKhau.UseSystemPasswordChar = chHienMatKhau.Checked ? false : true;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.TenDangNhap = txtTaiKhoan.Text;
            tk.MatKhau = txtMatKhauMoi.Text;
            DataTable dt = TaiKhoanDAO.HienThiYeuCauTK(txtTaiKhoan.Text);
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("Tài khoản không đúng");
                return;
            }
            if(txtMatKhau.Text != dt.Rows[0][1].ToString())
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
            TaiKhoanDAO.SuaTK(tk);
        }
    }
}
