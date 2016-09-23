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
    public partial class frmXoaTaiKhoan : Form
    {
        public frmXoaTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.TenDangNhap = txtTenTaiKhoan.Text;
            tk.MatKhau = txtMatKhau.Text;
            DataTable dt =  TaiKhoanDAO.LoadDataTK();
            bool kt = false;
            for(int i = 0;i<dt.Rows.Count;i++)
            {
                if(dt.Rows[i][0].ToString()==tk.TenDangNhap&&dt.Rows[i][1].ToString()==tk.MatKhau)
                {
                    kt = true;
                    break;
                }
            }
            if(kt==true)
            {
               if(TaiKhoanDAO.XoaTK(tk))
               {
                    MessageBox.Show("Xóa tài khoản thành công");
               }
               else
               {
                    MessageBox.Show("Xóa tài khoản thất bại");
               }
            }
            else
            {
                MessageBox.Show("Mật khẩu hoặc tài khoản không đúng");
            }
        }
    }
}
