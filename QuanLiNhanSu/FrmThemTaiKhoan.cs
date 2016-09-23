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
            if(txtMatKhau.Text!=txtXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp");
                return;
            }
            if(TaoTaiKhoan())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo không thành công");
            }
        }
        public bool TaoTaiKhoan()
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.TenDangNhap = txtTaiKhoan.Text;
            tk.MatKhau = txtMatKhau.Text;
            if(TaiKhoanDAO.ThemTK(tk))
            {
                MessageBox.Show("Tao tai khoản thành công");
                this.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Tạo tài khoản không thành công");
                return false;
            }
        }
    }
}
