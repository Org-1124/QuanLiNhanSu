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
    enum LuaChon
    {
        Them,
        Sua,
        Xoa
    }
    public partial class frmTaiKhoan : Form
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        void LoadDataTaiKhoan()
        {
            dgvTaiKhoan.DataSource = db.TaiKhoans.Select(n => n);
            dgvTaiKhoan.Columns["IDTaiKhoan"].HeaderText = "Mã tài khoản";
            dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Xoa;
            AnButton();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = db.TaiKhoans;
            ChiDoc();
            HienButton();
        }
        private void AnButton()
        {
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnThem.Visible = false;
        }
        private void HienButton()
        {
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnThem.Visible = true;
        }
        private void ChiDoc()
        {
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtIDTaiKhoan.ReadOnly = true;
        }
        private void ChoViet()
        {
            txtIDTaiKhoan.ReadOnly = false;
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
        }
        LuaChon lc;
        private void btnThem_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Them;
            AnButton();
            ChoViet();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        void ThemTaiKhoan()
        {
            TaiKhoan tk = new TaiKhoan();
            if (dgvTaiKhoan.Rows.Count <= 1) tk.IDTaiKhoan = 1;
            else tk.IDTaiKhoan = db.TaiKhoans.Select(n => n.IDTaiKhoan).Max() + 1;
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            db.TaiKhoans.InsertOnSubmit(tk);
            db.SubmitChanges();
            LoadDataTaiKhoan();
        }

        void SuaTaiKhoan()
        {
            TaiKhoan tk = db.TaiKhoans.Where(n => n.IDTaiKhoan == int.Parse(txtIDTaiKhoan.Text)).First();
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            db.SubmitChanges();
            LoadDataTaiKhoan();
        }

        void XoaTaiKhoan()
        {
            TaiKhoan tk = db.TaiKhoans.Where(n => n.IDTaiKhoan == int.Parse(txtIDTaiKhoan.Text)).First();
            db.TaiKhoans.DeleteOnSubmit(tk);
            db.SubmitChanges();
            LoadDataTaiKhoan();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch(lc)
            {
                case LuaChon.Them:
                    if(txtTenDangNhap.Text==""||txtMatKhau.Text=="")
                    {
                        MessageBox.Show("Yêu cầu bạn điền đầy đủ thông tin");
                        return;
                    }
                    ThemTaiKhoan();
                    break;
                case LuaChon.Sua:
                    if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
                    {
                        MessageBox.Show("Yêu cầu bạn điền đầy đủ thông tin");
                        return;
                    }
                    SuaTaiKhoan();
                    break;
                case LuaChon.Xoa:
                    XoaTaiKhoan();
                    break;
            }
            ChiDoc();
            HienButton();
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTaiKhoan.SelectedRows[0];
            txtIDTaiKhoan.Text = row.Cells["IDTaiKhoan"].Value?.ToString();
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienButton();            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Sua;
            ChoViet();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = db.TaiKhoans.Where(n => n.TenDangNhap.Contains(txtTimKiem.Text));
        }
    }
}
