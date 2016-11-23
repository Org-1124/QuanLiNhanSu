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
    public partial class frmDangKi : Form
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public frmDangKi()
        {
            InitializeComponent();

        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan checktk = db.TaiKhoans.SingleOrDefault(n => n.TenDangNhap == txtTenDangNhap.Text);
            if(checktk!=null)
            {
                MessageBox.Show("Tài khoản đã tồn tại , mời bạn làm lại");
                return;
            }
            TaiKhoan tk = new TaiKhoan();
            tk.IDTaiKhoan = db.TaiKhoans.Select(n => n.IDTaiKhoan).Max() + 1;
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            db.TaiKhoans.InsertOnSubmit(tk);
            db.SubmitChanges();
            MessageBox.Show("Tạo tài khoản thành công!");
            this.Close();
        }
    }
}
